# Blazor Database Application - Intern Assessment

This is a simple Blazor Server application that displays a list of products from a SQL Server database, allows adding new products, editing and deleting existing ones.

# How to Run

1.  **Database Setup (SQL Server):**
    * Ensure you have Microsoft SQL Server Express installed. If Not download it [here](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) and download the SQL Server 2022 Express.
    * **Important:** Update your connection string in appsettings.json with this: 
    `"DefaultConnection": "Server=(Your System Name)\\SQLEXPRESS;Database=OnTecAssessmentDb;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=True;TrustServerCertificate=True"`.
    * **Esure that you use your system name** You can get your system name on system information 
2.  **.Net Setup:**
    * Ensure you have .Net installed. If Not download it [here](https://dotnet.microsoft.com/en-us/download) and download the latest .Net SDK application.

3.  **Open Terminal or Command Prompt and run these commands:**

    ## Clone the project from GitHub 
    * **Using ssh** ``` git clone git@github.com:bhekumuzithabethe/OnTecAssessment.git``` 
    * **Using https** ``` git clone https://github.com/bhekumuzithabethe/OnTecAssessment.git``` 

    * If you don't have git installed download the source code, unzip it and carry on with the commands


    ## Navigate to the project folder
    ``` cd OnTecAssessment ``` 

    ## Restore the Nuget packages
    ``` dotnet restore OnTecAssessment.csproj ```

    ## Install the dotnet-ef tool globally
    ``` dotnet tool install --global dotnet-ef  ```
    
    ## Build the application
    ``` dotnet build OnTecAssessment.csproj``` 

    ## Apply EF Core migrations
    ``` dotnet ef migrations add firstMigration ``` 

    ## Update the database
    ``` dotnet ef database update ``` 

    ## Run the Blazor Server app
    ``` dotnet run ``` 

    ## To view the application

    Visit http://localhost:5017 in your browser.

# What I Learned

* **Blazor Server Fundamentals:** Understanding component based UI development, data binding and event handling.
* **Entity Framework Core:** Setting up `DbContext`, defining models with navigation properties, performing basic CRUD operations (Create, Read, Delete), and using `Include()` for eager loading related data (which effectively performs an inner join).
* **Database Connectivity:** Connecting a Blazor application to a SQL Server database using Entity Framework Core.
* **Dependency Injection:** Injecting services (`ProductService`) into Blazor components.
* **Form Handling and Validation:** Utilizing Blazor's `EditForm`, `DataAnnotationsValidator`, and `ValidationSummary` for robust user input.
* **Basic UI Styling:** Using MudBlazor components for a decent layout. 
* **Handling Images in Blazor:** Since I added the product Image this was interesting learning as I'm new to Blazor
# What Was Hardest for Me

* **Initial Database Connection String Configuration:** Getting the connection string exactly right for my SQL Server instance took some trial and error. 
* **Setting up form validation with dropdowns:** Ensuring the `CategoryId` was properly validated when "Select a Category" (value 0) was the default unselected option.
* **Debugging Database Issues:** Troubleshooting errors related to the database this incudes incorrect table names, foreign key constraints
