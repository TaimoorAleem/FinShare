# FinShare 💼📊

Welcome to FinShare, a personal project developed to enhance my skills in ASP.NET Core Web API.

### Features Implemented and Concepts Learned So Far: 📝

- **ASP.NET Core Setup**
  - **Program Configuration**: Set up ASP.NET Core application in `Program.cs`, including service configuration, middleware setup, and API documentation using Swagger.
  - **Dependency Injection**: Configured `ApplicationDBContext` for database operations and integrated it into the service container.

- **Entity Framework Core (EF Core)**
  - **Database Context**: Created `ApplicationDBContext` to manage database interactions with SQL Server.
  - **Migrations**: Added initial migrations to define and update the database schema.

- **Data Transfer Objects (DTOs) and Mappers**
  - **DTOs**: Defined `StockDTO` to represent stock data in API responses.
  - **Mappers**: Implemented `StockMappers` to convert between `Stock` models and `StockDTO`, facilitating clean data transformation.

- **API Controllers and Actions**
  - **StockController**: Developed actions for CRUD operations:
    - **GetAll**: Retrieves and returns a list of all stocks as DTOs.
    - **GetById**: Fetches a stock by its ID and handles scenarios where the stock is not found.
    - **Create**: Adds a new stock entry to the database based on provided data and returns the created stock as a DTO.

- **Error Handling and Debugging**
  - **Exception Handling**: Addressed and resolved issues related to serialization and disposal of objects, ensuring a stable API.

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
