# PurchaseOrder API – G3G

Welcome to the **PurchaseOrder API** project for **G3G**. This service provides basic CRUD functionality for managing purchase orders, with a focus on extensibility, clean architecture, and integration with SAP via a mocked ServiceLayer.

---

## 🧾 Features

The API exposes the following endpoints via the `PurchaseOrderController`:

- **Create**:  
  Accepts a `PurchaseOrder` and stores it in a staging table before sending it to the (mocked) SAP ServiceLayer.

- **Get All**:  
  Retrieves all stored purchase orders.

- **Get By ID**:  
  Retrieves a specific purchase order by its ID.

- **Update**:  
  Updates a specific purchase order.

- **Delete**:  
  Deletes a specific purchase order.

---

## ✅ Expected Improvements

You are expected to perform the following tasks to improve the project:

1. **Pull the project from GitHub**
2. **Secure the API** using industry standards (e.g., API key, OAuth, JWT)
3. **Apply SOLID principles**  
   - Single Responsibility  
   - Open/Closed  
   - Liskov Substitution  
   - Interface Segregation  
   - Dependency Inversion
4. **Write Unit and Functional Tests**
   - Use mocking libraries for dependencies
   - Cover all core functionalities
5. **Implement read database pattern**
   - Use CQRS or a similar approach to separate read/write logic
6. **Formalize the sending of data to the ServiceLayer (mocked)**
7. **Create a Pull Request** with your changes

---

## 🧪 Evaluation Criteria

You will be evaluated based on:

- **Readability**  
  - Clear, well-structured code and comments  
- **Extensibility**  
  - Easily adaptable to future enhancements  
- **Performance**  
  - Efficient data handling and service interactions  
- **Error Handling**  
  - Graceful handling of all exceptions and failure points

---

## 🛠️ Technologies

- .NET (Core 8 depending on project version)
- ASP.NET Web API
- Entity Framework for SQL / Mongodb Driver for MongoDB / CosmosClient for CosmosDB
- xUnit for testing
- Moq or similar mocking frameworks

---

## 📦 Getting Started

```bash
git clone https://github.com/your-org/purchase-order-api.git
cd purchase-order-api
dotnet build
dotnet run
```

---

## 🧪 Running Tests

```bash
dotnet test
```

---

## 🔐 Security

Authentication and authorization mechanisms should be added to ensure only trusted clients can access the API. Use `JWT` or other industry-standard authentication approaches.

---

## 🚀 Submitting Your Work

1. Push your changes to a new branch.
2. Open a pull request against the `main` branch.
3. Make sure all tests pass and the code follows the style guide.