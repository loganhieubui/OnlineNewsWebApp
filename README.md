# OnlineNewsWebApp 
This is my final project during part-time internship in NashTech from Feb to April 2024.
This project is created in ASP.NET Core MVC platform, with EntityFrmework, using database SQL Server.
I apply clean-architecture for easy maintaining purpose, which means my project has following structure:
- Core:
  + Enties: includes data models
  + Config: includes configuration for model properties and their relationships
  + ViewModels: includes view model for displaying in web app, only has necessary information
  + IServices: include interfaces defined functions for each data model (mapping version of ViewModels), will be implemented in Infrastructure/Services
  + Commons: some customize HtmlHelper to generate link faster (not really necessary) and datetime displaying
- Infrastructure:
  + Mapper: map the properties in Entities with ViewModels for displaying
  + IRepos: define the function of context
  + Repos: implement context function
  + Services: implement IServices
  + Database: configure the connection to the database and seed data using Lorem.NET package to generate random text and HtmlAgilityPack to crawl post data from real website. In the furture, these data may be used for analyzing users preference and synonym searching.
  + Migration: initialized data
- WebApp:
  + Controller: for post, tag, comment, category and default home
  + Views: separated into many partial views for displaying purposes
  + wwwroot: included css and js get from ZenBlog bootstrap template and AdminSB template, some customizes js functions,...
  + Areas/Admin: log in as admin and CRUD 

