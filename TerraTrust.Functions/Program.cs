using Azure.Storage.Blobs;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QuestPDF.Infrastructure;

QuestPDF.Settings.License = LicenseType.Community;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        var storage = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
        services.AddSingleton(new BlobServiceClient(storage));
        
    })
    .Build();

host.Run();