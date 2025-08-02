# 🔐 ProductArmorAPI

> A secure and modern ASP.NET Core Web API for managing products — with built-in authentication, authorization, and refresh token system.

![.NET Core](https://img.shields.io/badge/.NET-9.0-purple)
![License](https://img.shields.io/badge/license-MIT-green)
![Status](https://img.shields.io/badge/status-Active-blue)

---

## 🚀 Overview

**ProductArmorAPI** is a RESTful Web API designed to simulate a secure backend for managing products. It features:

- ✅ Secure login and registration using **JWT access tokens**
- 🔁 Refresh token-based **session renewal**
- 🛡️ Role-based **authorization** (Admin/User)
- 📦 Product CRUD operations
- 🔄 Token refresh endpoint to minimize login frequency
- 🧱 Clean architecture with Repository, Service layers

---


---

## 🛠️ Tech Stack

| Layer         | Technology         |
|---------------|--------------------|
| Framework     | ASP.NET Core 9.0   |
| Auth          | JWT + Refresh Token |
| DB            | Entity Framework + SQL Server |
| Mapping       | AutoMapper         |
| Architecture  | Repository-Service pattern |
| Hosting       | Localhost / Ready for Azure |

---

## 🔑 Key Features

### 👤 Authentication
- Secure login/registration
- JWT tokens with claims
- Password hashing

### 🔄 Refresh Tokens
- Refresh endpoint for renewing JWTs
- Stored securely in DB
- Tokens invalidated on logout

### 👥 Authorization
- User & Admin role control
- Certain endpoints protected with `[Authorize(Roles = "...")]`

### 📦 Product Management
- Create, read, update, delete products
- Each product contains:
  - Product name
  - Price
  - Company name
  - Seller name
  - Availability status

---

## 🚧 Endpoints Snapshot

| Endpoint                | Method | Auth Required | Role |
|-------------------------|--------|----------------|------|
| `/api/account/register` | POST   | ❌             | -    |
| `/api/account/login`    | POST   | ❌             | -    |
| `/api/account/refresh`  | POST   | ✅             | -    |
| `/api/products`         | GET    | ✅             | Any  |
| `/api/products/{id}`    | PUT    | ✅             | Admin|
| `/api/products`         | POST   | ✅             | Admin|
| `/api/products/{id}`    | DELETE | ✅             | Admin|

---

## 🧪 Run Locally

1. Clone the repo  
   `git clone https://github.com/amarsanthosh/dotnet_projects.git`

2. Navigate to the API folder  
   `cd dotnet_projects/api`

3. Install dependencies  
   `dotnet restore`

4. Update `appsettings.json` with your local DB string.

5. Run the project  
   `dotnet run`

---

## 📄 Resume / Portfolio Summary

> **ProductArmorAPI** is a secure product management backend built using ASP.NET Core. It demonstrates real-world implementation of JWT authentication, refresh tokens, and role-based access control. Designed with clean architecture principles and layered abstractions for easy scaling and testing.

---

## 🤝 License

This project is licensed under the MIT License.

---

## 🧠 Author

Developed by [Amar Santhosh](https://github.com/amarsanthosh)  
Follow for more: [@amarsanthosh](https://github.com/amarsanthosh)

