# FinShare 💼📊 (In-Progress)

Welcome to FinShare, a personal project developed to enhance my skills in ASP.NET Core Web API.

### Features Implemented and Concepts Learned So Far: 📝

- **Controllers and Actions**
  - StockController: Manages CRUD operations for stock entities, demonstrating the creation of RESTful APIs.
    - **GetAll()**: Fetches all stock records and returns them as DTOs.
    - **GetById(int id)**: Fetches a specific stock record by its ID and returns it as a DTO.
    - **Create(CreateStockRequestDto stockDto)**: Creates a new stock record from the provided DTO and saves it in the database.
    - **Update(int id, UpdateStockRequestDto updateDto)**: Updates an existing stock record identified by its ID with the provided DTO.
    - **Delete(int id)**: Deletes an existing stock record identified by its ID.
- **DTOs (Data Transfer Objects)**
  - Implemented DTOs to encapsulate data and reduce the number of parameters passed to methods, improving code maintainability.
- **Entity Framework Core**
  - Utilized EF Core for data access and ORM (Object-Relational Mapping) to interact with the SQL Server database.
  - Configured DbContext and connection strings to establish a connection with the SQL Server database.
- **Dependency Injection**
  - Implemented dependency injection to inject DbContext into the controller, following the best practices for ASP.NET Core.
- **Asynchronous Programming**
  - Utilized asynchronous methods (e.g., `async` and `await`) to ensure non-blocking operations for database access, improving application performance.

### Getting Started 💻

Follow these steps to run the project locally on a Windows or compatible environment. Ensure that the .NET SDK and other dependencies are installed.

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/TaimoorAleem/FinShare
   ```
2. **Navigate to the Project Directory:**
   ```bash
   cd path/to/project
   ```
3. **Restore Dependencies:**
   ```bash
   dotnet restore
   ```
4. **Apply Migrations and Update the Database:**
   ```bash
   dotnet ef database update
   ```
5. **Start the Application:**
   ```bash
   dotnet run
   ```
6. Access the API: Open your browser and navigate to http://localhost:5000 to interact with the API. You can use tools like Swagger for testing the endpoints.
