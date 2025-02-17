Expense Tracker with Power BI Integration

📌 Project Overview

This is a full-stack expense tracker application built using React (Vite) for the frontend, .NET for the backend, and MS SQL Server for data storage. The project also integrates Power BI to visualize expenses dynamically.

The purpose of this project is to practice full-stack development and understand how to incorporate Power BI reports into a web application.


🛠️ Tech Stack

Frontend: React.js

Backend: .NET Core Web API

Database: Microsoft SQL Server

BI & Analytics: Power BI Embedded


📊 Power BI Integration

This project utilizes Power BI Embedded to integrate interactive charts and reports within the React frontend. The reports update dynamically based on the expense data stored in the database.

How Power BI Works in This Project:

Data Collection: Expenses are stored in an SQL Server database through the .NET API.

Power BI Report Creation: A report is designed in Power BI Desktop and published to Power BI Service.

Embedding in React App: The frontend retrieves the Power BI Embed URL and Access Token from the backend.

Displaying Reports: Power BI SDK renders the report inside the application, and it updates dynamically when new expenses are added.


🤝 Usage

Start the backend and frontend.

Go to http://localhost:5173.

Add expenses and see them update dynamically on the Power BI chart.

📜 Disclaimer

This project is created for learning purposes only to explore Power BI integration with full-stack applications. It is not intended for production use.


📝 License

This project is open-source and can be modified for learning purposes.



