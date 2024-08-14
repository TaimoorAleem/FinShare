# FinShare 💼📊

Welcome to FinShare, a personal project I've developed to enhance my skills in ASP.NET Core Web API. This is a comprehensive backend-only application that provides robust APIs for managing stock portfolios and commenting on stocks, enabling users to efficiently manage and share their financial investments.

### Features Implemented: 📝

- **Controllers and Actions**
  - **StockController** (and **CommentController** which is also similar): Manages CRUD operations for stock entities, demonstrating the use of RESTful APIs.
    - GetAll(QueryObject query): Fetches all stock records based on optional filters and sorting parameters, returning them as DTOs.
    - GetById(int id): Fetches a specific stock record by its ID and returns it as a DTO.
    - Create(CreateStockRequestDto stockDto): Creates a new stock record from the provided DTO and saves it in the database.
    - Update(int id, UpdateStockRequestDto updateDto): Updates an existing stock record identified by its ID with the provided DTO.
    - Delete(int id): Deletes an existing stock record identified by its ID.
  - **PortfolioController:** Manages the user's stock portfolio.
    - GetPortfolio(): Retrieves the logged-in user's portfolio.
    - AddToPortfolio(string symbol): Adds a stock to the logged-in user's portfolio.
    - DeleteFromPortfolio(string symbol): Removes a stock from the logged-in user's portfolio.

- **DTOs (Data Transfer Objects)**
  - Implemented DTOs to encapsulate data and reduce the number of parameters passed to methods, improving code maintainability.
    
- **Entity Framework Core**
  - Utilized EF Core for data access and ORM (Object-Relational Mapping) to interact with the SQL Server database.
  - Configured DbContext and connection strings to establish a connection with the SQL Server database.
    
- **Dependency Injection**
  - Implemented dependency injection to inject DbContext into the controller, following the best practices for ASP.NET Core.
    
- **Asynchronous Programming**
  - Utilized asynchronous methods (e.g., `async` and `await`) to ensure non-blocking operations for database access, improving application performance.
    
- **Repository Pattern**
  - Applied the repository pattern to abstract data access logic, separating it from business logic and providing a clean API for data operations. This approach promotes a more maintainable and testable codebase.
    
- **Filtering**
  - Implemented filtering functionality in the GetAllAsync methods to allow users to filter records based on specific criteria, enabling more granular data retrieval based on user-defined parameters.
    
- **Dynamic Sorting**
  - Enhanced the GetAllAsync method in the StockController to support dynamic sorting by multiple fields. Sorting order can be specified as ascending or descending.

- **JWT Authentication**
  - Added JWT authentication to secure endpoints. Users must be authenticated to access certain resources.
  - Updated Swagger configuration to support JWT Bearer token authorization.

- **Relationships Between Models**:
  - A **Many-To-Many** relationship between User and Stock through the Portfolio entity. The Primary Key is a composite key consisting of AppUserId and StockId.
  - A **One-To-Many** relationship between Stocks and Comments.
  - A **One-To-One** relationship between Comment and User to display the username associated with each comment.

    
### Getting Started 💻

Follow these steps to run the project locally on a Windows or compatible environment. Ensure that the .NET SDK, SQL Server and other dependencies are installed.

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




P.S: I couldnt think of a better signin key in the appsettings.json file 💀
