# 🧱 Clean Architecture Template

A clean, modular starting point for building scalable, maintainable applications using the **Clean Architecture** pattern.

---

## 🧠 What is Clean Architecture?

**Clean Architecture** is a software design pattern that separates concerns into distinct layers, each with a clear responsibility. It emphasizes independence from frameworks, UI, databases, and external agencies — allowing business rules to remain at the core of the system.

---

## 🧩 Layered Structure

This template organizes code into four main layers:

/Domain

/Application

/Infrastructure

/API

### 🔹 Domain Layer

- **Purpose**: Contains the core business logic and domain entities.
- **Contents**: 
  - Entities (e.g. `Product.cs`)
  - Interfaces/Contracts (e.g. `IProductRepository.cs`)
- **Notes**: This layer is completely isolated. It depends on nothing.

---

### 🔹 Application Layer

- **Purpose**: Orchestrates application logic and use cases.
- **Depends on**: `Domain`
- **Contents**: 
  - Application services (e.g. `ProductService.cs`)
  - Interfaces for service-level contracts

---

### 🔹 Infrastructure Layer

- **Purpose**: Handles external systems like databases, file systems, or external APIs.
- **Depends on**: `Domain`
- **Contents**:
  - Concrete implementations of domain interfaces (e.g. `ProductRepository.cs`)
  - Data access logic

---

### 🔹 API Layer

- **Purpose**: Exposes the application to the outside world via HTTP.
- **Depends on**: `Application`, `Infrastructure`
- **Contents**:
  - Controllers (e.g. `ProductsController.cs`)
  - DTOs for request/response models
  - API configuration

---
