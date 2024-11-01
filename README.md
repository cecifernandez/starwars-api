# Star Wars API

## Overview

This is a C# API that retrieves data about characters, planets, starships, and more from the Star Wars universe. The API is built using ASP.NET Core and interacts with the [Star Wars API](https://swapi.dev/) to provide detailed information. It allows users to search for characters and other entities, with support for filtering and partial matches.

### Features

- Fetch character details (e.g., name, species, home planet).
- Search for characters by name with partial matching (e.g., searching "Lu" returns "Luke Skywalker").
- Built-in pagination support for listing large sets of data.

### Technologies Used

- **ASP.NET Core**: Framework for building the API.
- **C#**: Main programming language.
- **HTTP Client**: To interact with external Star Wars APIs.
- **Swagger**: For API documentation and testing.

## Getting Started

### Prerequisites

- **.NET 8.0 SDK**: [Download here](https://dotnet.microsoft.com/es-es/download/dotnet/8.0).
- **Visual Studio 2022** (or any preferred IDE for C#).
- **Postman** (optional, for testing API endpoints).

### Setup

1) **Clone the repository**
 ```
git clone https://github.com/cecifernandez/starwars-api.git
cd star-wars-api
```  
2) **Restore Packages**
```

dotnet restore

```
3) **Run the API**
```

dotnet run

```

## Endpoints

| HTTP Method | Endpoint                | Description                             |
|-------------|-------------------------|-----------------------------------------|
| GET         | `api/Character/all`     | Retrieves a list of all characters.     |
| GET         | `api/Character/search`  | Searches for characters by name. Pass the search term as a query parameter (e.g., `api/Character/search?name=Luke`). |
| GET         | `api/Film/all`             | Retrieves a list of all films.          |

### Example Request
```

GET /api/Character/search?name=Leia

```

### Example Response
```
{
    "name": "Leia Organa",
    "films": [
      "A New Hope",
      "The Empire Strikes Back",
      "Return of the Jedi",
      "Revenge of the Sith"
    ],
    "homeworld": "Alderaan",
    "url": "https://swapi.dev/api/people/5/"
  }
```














