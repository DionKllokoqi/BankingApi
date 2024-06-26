# Banking API

This project is a banking API built with .NET Core. It provides a set of endpoints for managing user accounts and performing transactions.

## Project Structure

The project is organized according to the onion architecutre, and is separated in several layers:

- `Core`: Contains the application's business logic and domain models.
- `Infrastructure`: Contains code for data persistence and presentation.
- `WebApi`: The API layer of the application.

## Testing

The project includes a suite of unit tests in `xUnit` for both the domain and application layers. Further tests should be added.

## Building and Running the Project

Execute on the command line:

```
dotnet build BankingApi.sln
dotnet run --project src/WebApi/WebApi.csproj
```

You can use swagger or cURL, or any other tool to test the api.

Sample request to register a user:

```
curl -X 'POST' \
  'http://localhost:5070/api/register' \
  -H 'accept: application/json' \
  -H 'Content-Type: application/json' \
  -d '{
  "userName": "string",
  "password": "string"
}'
```

For the create account and delete account endpoint, you need to provide a jwt token in the request, which you can get from the register call:

```
curl -X 'POST' \
  'http://localhost:5070/api/create-account' \
  -H 'accept: */*' \
  -H 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InN0cmluZyIsInJvbGUiOiJ1c2VyIiwibmJmIjoxNzEyNTIwMTE1LCJleHAiOjE3MTI1MjE5MTUsImlhdCI6MTcxMjUyMDExNX0.26xZpRtLKnbPYhSIsvbsf2heDITni0zPrgHQ6n3YXHw' \
  -H 'Content-Type: application/json' \
  -d '{
  "userId": "f4b2f041-0013-4459-a319-b22b2e65ab14",
  "name": "string",
  "initialBalance": 1000
}'
```

## Docker Support

The project includes a Dockerfile and docker-compose.yml for building and running the application in a Docker container.

```
docker-compose up --build
```

## Improvements and Notes

The solution is by far not finished yet. The general structure is laid out, and adding endpints for the deposit and withdrawal functionality follows the same pattern. There was not logging added, which should be done in further iterations, and exception handling can be improved. Endpoints now deliver exceptions if something goes wrong, but returning result objects might be a better idea.

| :exclamation:  On security              |
|-----------------------------------------|

The JWT secret key was hard-coded in the solution. This should not be the case in a production scenario. Usually you would access such a secret via Azure KeyVault and the like.
