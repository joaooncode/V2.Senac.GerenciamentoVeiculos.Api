#!/bin/bash

echo "Running all tests..."

# Run tests with coverage
dotnet test --collect:"XPlat Code Coverage" --results-directory ./TestResults

echo "Test results saved to ./TestResults"
