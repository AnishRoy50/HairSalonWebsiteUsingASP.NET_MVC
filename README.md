# Hair Salon Website - ["Glamour Cuts"]

[![ASP.NET MVC](https://img.shields.io/badge/ASP.NET%20MVC-5C2D91?style=for-the-badge&logo=.net&logoColor=white)](https://dotnet.microsoft.com/apps/aspnet/mvc)
[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![HTML5](https://img.shields.io/badge/HTML5-E34F26?style=for-the-badge&logo=html5&logoColor=white)](https://developer.mozilla.org/en-US/docs/Web/Guide/HTML/HTML5)
[![CSS3](https://img.shields.io/badge/CSS3-1572B6?style=for-the-badge&logo=css3&logoColor=white)](https://developer.mozilla.org/en-US/docs/Web/CSS)
[![JavaScript](https://img.shields.io/badge/JavaScript-F7DF1E?style=for-the-badge&logo=javascript&logoColor=black)](https://developer.mozilla.org/en-US/docs/Web/JavaScript)
## 🌟 Overview

Welcome to the "Glamour Cuts" Hair Salon Website! This project is a fully functional web application built using ASP.NET MVC, designed to provide an online presence for a modern hair salon. It allows users to browse services, view stylist profiles, check opening hours, and book appointments. For salon administrators, it offers tools to manage services, appointments, and potentially staff information.

## ✨ Key Features

* **Service Listings:** Display of all services offered by the salon (e.g., haircuts, coloring, styling) with descriptions and prices.
* **Stylist Profiles:** Information about each stylist, including their specializations and possibly a portfolio.
* **Online Appointment Booking:** A system for clients to request or book appointments based on available slots, services, and preferred stylists.
* **Contact Information & Location:** Easy access to the salon's phone number, email, address, and an embedded map.
* **Opening Hours Display:** Clearly shows the salon's operating hours for each day.
* **Responsive Design:** Ensures the website looks and functions well on various devices (desktops, tablets, mobiles).
* **Photo Gallery:** Showcase salon work, interiors, etc.

## 🛠️ Technologies Used

* **Framework:** ASP.NET MVC 5 
* **Language:** C#
* **Frontend:**
    * HTML5
    * CSS3
    * JavaScript
* **Backend:**
    * Entity Framework
* **Database:**
    * MySQL 
* **Authentication:**
    * ASP.NET Identity 
* **Development Environment:**
    * Visual Studio 


## ⚙️ Setup and Installation

To get a local copy up and running, follow these simple steps.

### Prerequisites

* Visual Studio (e.g., 2019 or 2022) with the ASP.NET and web development workload installed.
* .NET Framework (version, e.g. 4.7.2 )
* SQL Server and SQL Server Management Studio (SSMS) 

### Installation Steps

1.  **Clone the repository:**
    ```bash
    git clone 
    cd ...
    ```
2.  **Open in Visual Studio:**
    Open the `.sln` (solution) file in Visual Studio.
3.  **Database Setup:**
    * **Connection String:** Update the database connection string in the `Web.config` file (usually in the `<connectionStrings>` section) to point to your local database instance.
        ```xml
        <connectionStrings>
          <add name="DefaultConnection" 
               connectionString="Data Source=YOUR_SERVER_NAME;Initial Catalog=YOUR_DATABASE_NAME;Integrated Security=True" 
               providerName="System.Data.SqlClient" />
          </connectionStrings>
        ```
    * **Database Creation/Migration:**
        * If using Entity Framework Code First with Migrations:
            1.  Open the Package Manager Console in Visual Studio (`View > Other Windows > Package Manager Console`).
            2.  Run `Update-Database` to create the database and apply migrations.
        * If using Database First or Model First, you might need to:
            1.  Create the database manually in SSMS.
            2.  Run SQL scripts (if provided in the repository) to create tables and seed initial data.
            3.  Update your Entity Framework model from the database if necessary.
4.  **Build the Solution:**
    In Visual Studio, build the solution (Build > Build Solution or `Ctrl+Shift+B`). This will restore NuGet packages.
5.  **Run the Application:**
    Press `F5` or click the "Start" button in Visual Studio to run the application. It should open in your default web browser.

## 🚀 Usage

Once the application is running:

* **Client View:**
    * Navigate through the public pages: Home, Services, Stylists, Contact, Book Appointment.
    * Use the booking form to request an appointment.





* Mention any third-party libraries, assets, or tutorials that were particularly helpful.
* Any individuals who provided significant help.

---

**Happy Coding!** 💇‍♀️✨
