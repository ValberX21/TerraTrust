using Azure.Messaging.ServiceBus;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Text;
using System.Text.Json;
using TerraTrust.Messaging.Contratcs;

namespace TerraTrust.Functions.Functions
{
    public class CreatePDFBLOB
    {
        private readonly BlobServiceClient _blobServiceClient;
        private const string QueueName = "create-property";

        private readonly ILogger<CreatePDFBLOB> _logger;

        public CreatePDFBLOB(BlobServiceClient blobService, ILogger<CreatePDFBLOB> logger)
        {
            _blobServiceClient = blobService;
            _logger = logger;   
        }    

        [Function("CreatePDFBLOB")]
        public async Task Run(
            [ServiceBusTrigger(QueueName, Connection = "ServiceBusConnection")]
            ServiceBusReceivedMessage message)
        {
            var body = message.Body.ToString();
            var msg = JsonSerializer.Deserialize<CreatePropertyMessage>(body);

            _logger.LogInformation("Received message. CorrelationId={CorrelationId}, Size={Size} bytes",
                message.CorrelationId, body?.Length ?? 0);

            try
            {
                //Generate PDF
                byte[] pdfBytes = Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(2, Unit.Centimetre);
                        page.DefaultTextStyle(x => x.FontSize(12));
                        page.Header().Text("Property Report").SemiBold().FontSize(20);
                        page.Content().Column(col =>
                        {
                            col.Item().Text($"Property ID: {msg.Id}");
                            col.Item().Text($"Name: {msg.Name}");
                            col.Item().Text($"Type: {msg.Type}");
                            col.Item().Text($"Owner: {msg.OwnerName}");
                            col.Item().Text($"Generated at: {DateTimeOffset.UtcNow:yyyy-MM-dd HH:mm:ss} UTC");
                        });
                        page.Footer().AlignCenter().Text(txt =>
                        {
                            txt.Span("Page "); txt.CurrentPageNumber(); txt.Span(" / "); txt.TotalPages();
                        });
                    });
                }).GeneratePdf();

                var container = _blobServiceClient.GetBlobContainerClient("properties");
                await container.CreateIfNotExistsAsync();
                var blob = container.GetBlobClient($"{msg.Id}.pdf");

                using var ms = new MemoryStream(pdfBytes);
                var uploadOptions = new BlobUploadOptions
                {
                    HttpHeaders = new BlobHttpHeaders { ContentType = "application/pdf" },
                    Metadata = new Dictionary<string, string>
                    {
                        ["propertyId"] = msg.Id.ToString(),
                        ["name"] = msg.Name
                    }
                };

                await blob.UploadAsync(ms, uploadOptions);

                _logger.LogInformation("PDF created and uploaded to blob storage. BlobUrl={BlobUrl}",
                    blob.Uri);

            }catch(Exception ex)
            {
               _logger.LogError(ex, "Error processing message. CorrelationId={CorrelationId}",
                    message.CorrelationId);
            }
          
        }
    }
}
