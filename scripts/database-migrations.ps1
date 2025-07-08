#!/bin/bash

# Database migration scripts for Windows PowerShell
# Run these commands in PowerShell from the project root directory

Write-Host "=== Database Migration Commands ==="
Write-Host ""

Write-Host "1. Add Migration:"
Write-Host "dotnet ef migrations add InitialCreate --project src/V2.Senac.GerenciamentoVeiculos.Api.Infrastructure --startup-project src/V2.Senac.GerenciamentoVeiculos.Api.WebApi"
Write-Host ""

Write-Host "2. Update Database:"
Write-Host "dotnet ef database update --project src/V2.Senac.GerenciamentoVeiculos.Api.Infrastructure --startup-project src/V2.Senac.GerenciamentoVeiculos.Api.WebApi"
Write-Host ""

Write-Host "3. Drop Database:"
Write-Host "dotnet ef database drop --project src/V2.Senac.GerenciamentoVeiculos.Api.Infrastructure --startup-project src/V2.Senac.GerenciamentoVeiculos.Api.WebApi"
Write-Host ""

Write-Host "4. Remove Migration:"
Write-Host "dotnet ef migrations remove --project src/V2.Senac.GerenciamentoVeiculos.Api.Infrastructure --startup-project src/V2.Senac.GerenciamentoVeiculos.Api.WebApi"
Write-Host ""

Write-Host "5. List Migrations:"
Write-Host "dotnet ef migrations list --project src/V2.Senac.GerenciamentoVeiculos.Api.Infrastructure --startup-project src/V2.Senac.GerenciamentoVeiculos.Api.WebApi"
Write-Host ""

# If you want to actually run the commands, uncomment the lines below:
# dotnet ef migrations add InitialCreate --project src/V2.Senac.GerenciamentoVeiculos.Api.Infrastructure --startup-project src/V2.Senac.GerenciamentoVeiculos.Api.WebApi
# dotnet ef database update --project src/V2.Senac.GerenciamentoVeiculos.Api.Infrastructure --startup-project src/V2.Senac.GerenciamentoVeiculos.Api.WebApi
