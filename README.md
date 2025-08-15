# TerraTrust 🏢

**TerraTrust** is a real estate property management platform designed to streamline the process of creating, updating, and managing property records.  
It implements a **CQRS + MediatR architecture** with a clean separation of concerns, aiming for scalability and maintainability.

![.NET](https://img.shields.io/badge/.NET-9.0-blue)
![Angular](https://img.shields.io/badge/Angular-18-DD0031)
![Architecture](https://img.shields.io/badge/Architecture-CQRS%20%2B%20MediatR-green)

---

## 📑 Table of Contents
- [Overview](#overview)
- [Features](#features)
- [Architecture](#architecture)
- [Tech Stack](#tech-stack)
- [Installation](#installation)
- [Usage](#usage)
- [API Documentation](#api-documentation)
- [Testing](#testing)
- [Deployment](#deployment)

---

## 📌 Overview
TerraTrust is built to manage real estate properties in a structured and event-driven way.  
The system supports:
- Property creation, update, deletion
- Event handling with MediatR
- Pagination and filtering for large datasets
- Easy integration with front-end applications

The backend follows **Clean Architecture principles** and is optimized for future scalability.

---

## ✨ Features
- ✅ **CQRS + MediatR** for request/command handling
- ✅ **Event-driven** domain events
- ✅ **Pagination and filtering** for property listing
- ✅ **API-first** design (ready for integration with Angular frontend)
- ✅ **Swagger UI** documentation
- ✅ **Repository pattern** for data access

---

## 🏗 Architecture

Angular Frontend → ASP.NET Core API → Application Layer → Domain Layer → Infrastructure Layer → SQL Server

## 🛠 Tech Stack
- ✅ **Backend: .NET 7, ASP.NET Core, MediatR, CQRS
- ✅ **Frontend: Angular 18
- ✅ **Database: SQL Server
- ✅ **Documentation: Swagger
- ✅ **Testing: NUnit/xUnit
- ✅ **Repository pattern** for data access

## 🚀 Installation
Prerequisites
- NET 7 SDK
- Node.js 18+
- SQL Server

## 📚 API Documentation
https://localhost:5001/swagger

Example endpoint:
GET /api/properties?page=1&pageSize=10

          
<img src="https://github.com/ValberX21/TerraTrust/blob/master/TerraTrust.Core/img/terratrustapi.png" width="600" height="300"/>

