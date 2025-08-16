@echo off
echo Starting Shop Management System...
echo.
echo This script will start the backend server and frontend development server.
echo.

REM Start the backend server in a new window
start cmd /k "cd backend && npm run start"

REM Wait for 3 seconds to allow the backend to initialize
echo Waiting for backend to initialize...
timeout /t 3 /nobreak >nul

REM Start the frontend development server
echo Starting frontend...
npm run dev

REM When the frontend server is terminated, this will execute
echo Shutting down...
