# Shop Management System Starter Script

Write-Host "Starting Shop Management System..." -ForegroundColor Cyan
Write-Host ""
Write-Host "This script will start the backend server and frontend development server." -ForegroundColor White
Write-Host ""

# Initialize the database first
Write-Host "Initializing database..." -ForegroundColor Yellow
Push-Location -Path ".\backend"
npm run init-db
if ($LASTEXITCODE -ne 0) {
    Write-Host "Database initialization failed. Please check the error and try again." -ForegroundColor Red
    Write-Host "Press any key to exit..."
    $null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
    exit 1
}
Pop-Location

# Start the backend server in a new window
Write-Host "Starting backend server..." -ForegroundColor Yellow
Start-Process powershell.exe -ArgumentList "-NoExit", "-Command", "cd '$PWD\backend'; npm run start"

# Wait for 3 seconds to allow the backend to initialize
Write-Host "Waiting for backend to initialize..." -ForegroundColor Gray
Start-Sleep -Seconds 3

# Start the frontend development server
Write-Host "Starting frontend..." -ForegroundColor Yellow
npm run dev

# When the frontend server is terminated, this will execute
Write-Host "Shutting down..." -ForegroundColor Red
