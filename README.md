# ✈️ Flight Management System

Welcome to the Flight Management System — a modular, microservices-based web application designed for managing flight bookings, check-ins, and user services. Built using ASP.NET Core, MySQL, Docker, and Jenkins for CI/CD.

---

## 🏛️ System Architecture

graph TD
  A[User Interface - FMS Frontend (ASP.NET MVC)] --> B1[UserService API]
  A --> B2[BookingService API]
  A --> B3[CheckInService API]
  B1 --> C1[(UserDB - MySQL)]
  B2 --> C2[(BookingDB - MySQL)]
  B3 --> C3[(CheckInDB - MySQL)]

⚙️ Setup & Run Instructions
🔧 Prerequisites
.NET SDK 7.0 or later

Docker & Docker Compose

Git

(Optional) Jenkins for CI/CD pipeline
git clone https://github.com/YourUsername/FlightManagementSystem.git
cd FlightManagementSystem

This will spin up the following:
docker-compose up --build
FMSFrontend at: http://localhost:5263
BookingService at: http://localhost:5138/
CheckInService at: http://localhost:5032/
UserService at: http://localhost:5123/

📡 API Documentation
Each microservice exposes a Swagger UI:

🧍‍♂️ UserService
Base URL: http://localhost:5123

Endpoints:

GET /api/users

POST /api/users

PUT /api/users/{id}

DELETE /api/users/{id}

📦 BookingService
Base URL: http://localhost:5138

Endpoints:

GET /api/bookings

POST /api/bookings

PUT /api/bookings/{id}

DELETE /api/bookings/{id}

🧳 CheckInService
Base URL: http://localhost:5032

Endpoints:

GET /api/checkin

POST /api/checkin

PUT /api/checkin/{id}

DELETE /api/checkin/{id}

You can test each API interactively via Swagger UI.

🔄 Continuous Integration
This project uses Jenkins for automated testing, building, and deploying services. The root directory contains a Jenkinsfile that defines the pipeline stages:

Clone from GitHub

Restore NuGet packages

Build & Test each microservice

Dockerize & Deploy

🧪 Testing
FMSFrontend at: http://localhost:5263/swagger
BookingService at: http://localhost:5138/swagger
CheckInService at: http://localhost:5032/swagger
UserService at: http://localhost:5123/swagger

📂 Folder Structure
mathematica
Copy code
FlightManagementSystem/
├── Jenkinsfile
├── docker-compose.yml
├── Services/
│   ├── BookingService/
│   ├── CheckInService/
│   ├── UserService/
├── FMS Front End/
│   └── FMSFrontend.csproj
├── Tests/
│   └── Playwright tests

📬 Contact
For questions or contributions, contact Mufaddal Bhaijiwala
📧 Email: mufaddal@example.com
🔗 GitHub: github.com/Mufu2005