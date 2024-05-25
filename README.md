Details of the asp.net core project:
Project Structure: An ASP.NET Core project typically consists of folders and files organized like:
•	Controller: Contain C# classes that handle incoming HTTP requests.( ProductModelsController.cs)
•	Views: Contain HTML files and bootstrap styling combined with C# code (Razor syntax) for generating dynamic content. ( Index.cshtml, Create.cshtml, Edit.cshtml, Details.cshtml, Delete.cshtml).
•	Models: Contain C# classes that represent the data and business logic of the application.
(ProductModel.cs).
•	www root: Contains static files like HTML, CSS, JavaScript, images, etc.
•	Database Context: Represents a session with the database, allowing you to query and save data. (ApplicationDbContext).
•	Root: Define How Urls map to the controllers and  action(e.g. startup.cs).
Dependencies:  Using  both EF Core migrations files and Dapper which is an ORM (Object-Relational Mapper) provided by ASP.NET Core.

Running the Project: 
1.	Install required Tools: Ensure you have the .NET SDK installed on your system. You can download it from the official .NET website.
2.	 Open the solution in visual studio or navigate to the project directry in visual studio code(EmployeeProductData).
3.	Build the project by clicking on the build option or running dotnet build command in the terminal.
4.	Once the build is successful, you can run the project, click on this page (ProductModelsController.cs).  
5.	In Visual Studio, you can press F5 to run/debug the project.
Access the Application:
Open a web browser and navigate to the URL where your application is running (usually https://localhost:port/).
