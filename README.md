# Jap Task

This is my solution to the first JAP task.

## Application's main features:

- User authenication
- Admin can view a list of all available students
- Admin can view a list of all available selections
- Admin can view all available programs
- Admin can view lectures and events
- Admin can view report tab
- Admin can manually order table with lectures and events.
- Admin can add, delete and edit lectures or events.
- Admin can create new student and send them their email and password.
- Page is supporting:
  - ordering
  - ordering
  - filtering
  - pagination 
- Students can login and view their informations
- Students can see lectures and events for their selection
- Students and Admin can logout

## Used Technologies

### Frontend

- ReactJS
- react-router-dom
- @reduxjs/toolkit
- react-redux
- axios
- moment
- bootstrap
- react-icons

### Backend

- .Net 6 Web API
- SQL Server database
- Entity Framework Core
- Microsoft Identity

## Running Application

To get a local copy up and running follow these simple steps:

1.  Clone the repository
    `https://github.com/adnmums/JapTask.git`

2.  Backend

- Open Platfrom.Backend folder with Visual Studio
- Run `update-database` in Package Manager Console and select Platform.Database as Default project
- Fill in your Sendgrid data in appsettings.json
- Start it with debbuging (F5) or without (Ctrl + F5)
- You can test API with Swagger: `https://localhost:7294/swagger/index.html`

3.  Frontend

- Install NPM packages npm install for frontend (from Platform.Frontend folder)
- After that run `npm start` to start the frontend

## Credentials for seeded admin

- username: `admin`
- password: `admin`
