# 🚌 Online Ticket Booking System

A desktop application developed for **Faisalabad Transport Company** 
using C# Windows Forms and SQLite database.

## 👩‍💻 Developer
- **Name:** Areeba Asghar
- **AG No:** 2024-AG-5387
- **Degree:** BSc Computer Science
- **University:** University of Agriculture Faisalabad

## ✨ Features
- User Registration & Login (Role-based)
- Search Tickets (Bus/Train)
- Seat Selection & Ticket Booking
- Payment Processing
- E-Ticket Generation
- Booking History & Cancellation
- Admin Panel (Routes & Bookings Management)

## 🛠️ Technology Stack
- **Language:** C#
- **UI Framework:** Windows Forms (.NET Framework)
- **Database:** SQLite
- **Data Access:** ADO.NET
- **IDE:** Visual Studio 2022
- **Version Control:** Git/GitHub

## 🗄️ Database Tables
- Users
- Routes
- Tickets
- Bookings
- Payments
- Feedback

## 🚀 How to Run
1. Clone the repository
2. Open `TicketBookingSystem.sln` in Visual Studio
3. Install NuGet package: `System.Data.SQLite`
4. Press F5 to run

## 🔑 Default Login
Admin Email:    admin@ticketsystem.com
Admin Password: Admin@123

## 📁 Project Structure

TicketBookingSystem/
├── Database/
│   ├── BaseRepository.cs
│   ├── DbConnections.cs
│   ├── UserDB.cs
│   ├── BookingDB.cs
│   └── TicketDB.cs
├── Forms/
│   ├── LoginForm.cs
│   ├── RegisterForm.cs
│   ├── MainDashboard.cs
│   ├── SearchTicketsForm.cs
│   ├── BookingForm.cs
│   ├── BookingHistoryForm.cs
│   └── AdminPanelForm.cs
├── Models/
│   ├── User.cs
│   └── Session.cs
└── Program.cs

## 📋 Supervisor
- **Name:** Dr. Qamar
- **Department:** Computer Science
- **University:** UAF
