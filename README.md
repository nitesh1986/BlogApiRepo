# BlogApiRepo
Blog Management System Repo
### Frontend Setup

1. Clone the repository: `git clone <repository-url>`
2. Navigate to the frontend directory: `cd blog-management-app`
3. Install dependencies: `npm install`
4. Run the application: `ng serve`
5. Open the application in your browser: `http://localhost:4200`


## Features

- User authentication and authorization
- Create, read, update, and delete (CRUD) blog posts
- Responsive UI
- Client-side form validation
- Error handling and notifications

## Technologies Used

### Backend
- ASP.NET Core Web API (Visual Studio 2022)
- Entity Framework Core
- Utilize a local JSON file as a mock database
- xUnit for unit testing

### Frontend
- Angular 18.05
- RxJS
- Jasmine and Karma for unit testing


### Backend Setup

1. Navigate to the backend directory: `cd BlogApi`
2. Install dependencies: `dotnet restore`
3. Run the application: `dotnet run`
4. The API will be available at: 'https://localhost:44385/api/Blogposts'



How to Run the Application:

Start the backend server using the above instructions.
Start the frontend application using the above instructions.
Open a browser and navigate to http://localhost:4200 to interact with the application.
Design Decisions and Application Structure:

markdown

### Design Decisions

- **Frameworks:** Chose Angular for the frontend for its robust ecosystem and .NET Core for the backend for its performance and scalability.
- **State Management:** Utilized RxJS for state management in Angular, ensuring a reactive approach to data handling.
- **Styling:** Used Bootstrap for styling to create a responsive and consistent UI.
- **API Structure:** Designed RESTful API endpoints for CRUD operations on blog posts.

### Application Structure

- **Frontend:**
  - `src/app/components`: Contains Angular components such as `BlogListComponent` and `BlogFormComponent`.
  - `src/app/services`: Contains services for handling HTTP requests, e.g., `BlogService`.
  - `src/app/models`: Contains data models, e.g., `BlogPost`.


