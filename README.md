# CO3102/CO7102: GEVS – An Online Voting Platform

## Tech Stack
- Frontend: NextJS (ReactJS) 13 (App Router)
- Backend: C# .NET 7 (API) - Attempted to use .NET 8 but had issues with Identity Server authentication in endpoints, so reverted to .NET 7. I realised its not fully supported.
- Database: PostgreSQL (Database)
- Deployment: Docker (Containerization)

## How to run
1. Install Docker
2. Run `docker-compose up` in the `backend` directory
3. Install NodeJS
4. Run `npm install` in the `frontend` directory
5. Run `npm run dev` in the `frontend` directory
6. Open `http://localhost:3000` in your browser

### Docker Compose
The `docker-compose.yml` file contains the following services:
- `gevsdb` - The PostgreSQL database
- `gevs-api` - The .NET API
- `gevs-identity` - Identity Server

The docker compose should run all of these services and link them together.

## How to use
### User
1. Register an account
2. Login
3. Vote on an election
4. View the results of an election (once the admin has closed the election)
### Admin
1. The admin account is created when the database is created.
2. Login with the admin account
3. Open an election
4. View the results of an election
5. Close an election
6. Restart an election - this will delete all votes and reset the election results

## API Endpoints

### GET /gevs/constituency/{constituency}
Returns the results of an election for a given constituency

### GET /gevs/results
Returns the results of an election and the seats won by each party

### GET /gevs/candidate (requires authentication - Bearer token)
Returns the candidate details for all constituencies

### PUT /gevs/admin/election/{boolean} (requires authentication - Bearer token)
Opens or closes an election - true to open, false to close

### GET /gevs/candidate/{candidateId} (requires authentication - Bearer token)
Returns the candidate details for a given candidate ID

### DEL /gevs/admin/delete (requires authentication - Bearer token)
Deletes vote history and election results from the database

### GET /gevs/election/status
Returns the status of the election - true if open, false if closed

### GET /gevs/election/candidate/{constituency}
Returns the candidate details for a given constituency


## Explaining the frontend

### Pages
- `/` - Home page
- `/election/vote` - Voting page (only accessible if logged in - you can only vote once - admins cannot vote)
- `/election/results` - Results page (only accessible if logged in - you can only view the results once the admin has closed the election)
- `/admin/session` - Admin session details which hold the tokens for the admin API endpoints
- `/admin/dashboard` - Admin dashboard (only accessible if logged in as an admin)

### Extra notes

- When restarting an election as an admin, all votes for the candidates are zeroed.
- You may have to refresh the webpage occasionally to see the update on the home page since the website is an SPA.