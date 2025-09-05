# BudgetBuddy-Smart-Personal-Finance-Tracker

Description
-----------
A platform that helps users manage expenses, set savings goals, and receive AI-powered recommendations for smarter financial decisions.

## Tech Stack
- Scala (AI/ML service for static-rule categorization & future model integration)
- FastAPI (Python REST API to expose endpoints)
- ASP.NET Core (C# back-end for budget tracking & goal management)

## Requirements
- Transaction categorization system  
  • Support custom categories  
  • Auto-categorized transactions via static rules
- Budget tracking with goal progress  
  • Recalculate budgets and progress after each transaction
- AI-powered spending insights  
  • Start with static rules before integrating ML models

## Installation

### 1. Scala AI/ML Service
Prerequisites:
- JDK 11+
- sbt

bash
git clone https://github.com/YourOrg/BudgetBuddy-Smart-Personal-Finance-Tracker.git
cd BudgetBuddy-Smart-Personal-Finance-Tracker/scala-ml-service
sbt compile
sbt run


### 2. FastAPI Service
Prerequisites:
- Python 3.9+
- pip

bash
cd ../fastapi-api
python -m venv venv
source venv/bin/activate      # On Windows: venv\Scripts\activate
pip install -r requirements.txt
uvicorn main:app --reload --port 8000


### 3. ASP.NET Core Back-End
Prerequisites:
- .NET 6 SDK

bash
cd ../aspnet-backend
dotnet restore
dotnet build
dotnet run --urls "https://localhost:5001"


### Environment Variables
Set these in your shell or via a .env file:
- DATABASE_CONNECTION_STRING  
- OPENAI_API_KEY (for future AI integration)
- LOG_LEVEL (e.g., Debug, Information)

## Usage
1. Start the Scala ML service (`sbt run`) to handle categorization rules.
2. Launch the FastAPI server (`uvicorn main:app`) to expose REST endpoints.
3. Run the ASP.NET Core server (`dotnet run`) for budget and goal management.
4. Use an HTTP client (Postman, curl) to interact with endpoints:
   - Create transactions
   - View categorized data and budget progress
   - Fetch spending insights

## Implementation Steps
1. Project Setup
   - Create three folders: `scala-ml-service`, `fastapi-api`, `aspnet-backend`.
2. Data Models
   - Define `Transaction`, `Category`, `BudgetGoal` classes in each stack.
3. Transaction Categorization
   - In Scala: implement static-rule engine; support override via custom user category.
   - Expose a `/categorize` endpoint in FastAPI that calls the Scala service.
4. Budget Tracking
   - In ASP.NET Core: create services to track budgets and recalculate goal progress on each new transaction.
   - Persist data using EF Core or your preferred ORM.
5. AI-Powered Insights
   - Begin with hard-coded rules (e.g., high spend alerts)
   - Expose `/insights` in FastAPI, aggregate data from ASP.NET Core and Scala services.
6. Environment Configuration
   - Wire up `DATABASE_CONNECTION_STRING`, `OPENAI_API_KEY`, and logging settings.
7. Integration & Testing
   - Write unit tests for each service.
   - Use Docker Compose (future) to orchestrate services.

## API Endpoints

FastAPI:
- POST /transactions/categorize   – Send raw transaction, receive category
- GET  /insights                 – Get current spending insights

ASP.NET Core:
- POST /api/transactions         – Create a new transaction, triggers recalc
- GET  /api/budgets/{userId}     – Retrieve budget goals and progress
- GET  /api/goals                – List all saving goals