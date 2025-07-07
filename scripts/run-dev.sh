#!/bin/bash

echo "Starting development environment..."

# Restore packages
echo "Restoring packages..."
dotnet restore

# Build solution
echo "Building solution..."
dotnet build

# Run tests
echo "Running tests..."
dotnet test

# Start the API
echo "Starting API..."
dotnet run --project src/V2.Senac.GerenciamentoVeiculos.Api.WebApi
