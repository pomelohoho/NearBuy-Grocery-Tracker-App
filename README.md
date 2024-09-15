# NearBuy-Grocery-Tracker-App

**NearBuy** is a web application designed to help users manage their grocery shopping, track their inventory, and plan meals based on their pantry. The app integrates with the Kroger public API to fetch real-time product prices and allows users to "commit" their grocery lists into their inventory. It also features recipe creation and a meal planner that helps identify missing ingredients for planned meals.

## Table of Contents

- [Features](#features)
- [Technology Stack](#technology-stack)
- [Setup Instructions](#setup-instructions)
- [Running the App Locally](#running-the-app-locally)
- [Deployment](#deployment)
- [Contributing](#contributing)
- [License](#license)

## Features

- **Grocery List Management**: Create, edit, and manage grocery lists. Track prices from the Kroger API in real-time.
- **Inventory Management**: Automatically add items to your inventory after purchasing them from the grocery list.
- **Recipe Creation**: Create custom recipes and associate ingredients with your inventory items.
- **Meal Planner**: Plan meals based on available inventory or generate a grocery list based on recipes you want to make.

## Technology Stack

- **Frontend**: Angular 18 (TypeScript)
- **Backend**: Azure Functions (C# / .NET Core)
- **Database**: 
  - Local: SQLite (for local development)
  - Production: Azure SQL Database (Serverless) or Azure Cosmos DB
- **API Integration**: Kroger Public API for fetching grocery prices
- **Hosting**: 
  - Frontend: Azure Static Web Apps
  - Backend: Azure Functions

## Setup Instructions

### Prerequisites

- [Node.js](https://nodejs.org/) (for Angular)
- [Angular CLI](https://angular.io/cli)
- [Azure Functions Core Tools](https://docs.microsoft.com/en-us/azure/azure-functions/functions-run-local)
- [Visual Studio](https://visualstudio.microsoft.com/) (for C# development)
- SQLite (for local database)

### Cloning the Repository

```bash
git clone https://github.com/your-username/nearbuy.git
cd nearbuy
```

### Install Frontend Dependencies

```bash
cd frontend
npm install
```

### Install Backend Dependencies

```bash
cd backend
dotnet restore
```

## Running the App Locally

### Backend: Azure Functions (Local)

1. Set up your local environment with **Azure Functions Core Tools** and SQLite.
2. Update the `local.settings.json` file with your Kroger API credentials and SQLite connection string.
3. Start the backend server:

```bash
cd backend
func start
```

### Frontend: Angular (Local)

1. Navigate to the `frontend` folder.
2. Start the frontend server:

```bash
cd frontend
ng serve
```

3. The app will be running at `http://localhost:4200`.

### Database: SQLite

1. Configure SQLite for local development. The database schema can be found in the `/db` folder.
2. Use the provided SQL scripts to set up tables for `Inventory`, `GroceryList`, and `Recipes`.

```bash
sqlite3 nearbuy.db < db/schema.sql
```

## Deployment

### Deploy Backend to Azure Functions

1. Log in to your Azure account:

```bash
az login
```

2. Deploy the function app to Azure:

```bash
az functionapp create --name <YourAppName> --resource-group <YourResourceGroup> --consumption-plan-location <Region> --runtime dotnet
az functionapp deploy --name <YourAppName> --src-path ./backend
```

### Deploy Frontend to Azure Static Web Apps

1. Build the frontend for production:

```bash
cd frontend
ng build --prod
```

2. Deploy to Azure Static Web Apps:

```bash
az staticwebapp create --name NearBuy --resource-group <YourResourceGroup> --source ./frontend
```

### Azure SQL Database (Production)

1. Set up an Azure SQL database and configure the connection string in your Azure Functions application settings.

```bash
az sql db create --name nearbuy --resource-group <YourResourceGroup> --server <ServerName> --service-objective S0
```

2. Use Entity Framework migrations or raw SQL to set up tables on Azure SQL.

## Contributing

We welcome contributions to the NearBuy project! Here's how you can contribute:

1. Fork the repository.
2. Create a new branch: `git checkout -b feature/your-feature`.
3. Make your changes and commit them: `git commit -m 'Add some feature'`.
4. Push to the branch: `git push origin feature/your-feature`.
5. Submit a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

This README should give you and your partner a solid starting point for your GitHub repository, clearly outlining how to set up, run, and deploy the project.
