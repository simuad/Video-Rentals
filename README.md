# API for Video Rentals
Simple CRUD project for VU Web Services course.
## Installation
Clone the repository:
```bash
git clone https://github.com/simuad/Video-Rentals.git
cd Video-Rentals
```
Launch docker container:
```bash
docker-compose build
docket-compose up
```
## Usage
Test the API with [Postman](https://www.postman.com/).
### GET
#### Get all:
```
http://localhost:8080/api/VideoRentalItems/
```
Example output:
```JSON
[
    {
        "id": 1,
        "title": "A Clockwork Orange",
        "genre": "Crime",
        "releaseYear": 1971,
        "duration": 136,
        "language": "English",
        "rating": "R",
        "isRented": true
    },
    {
        "id": 2,
        "title": "Citizen Kane",
        "genre": "Drama",
        "releaseYear": 1941,
        "duration": 119,
        "language": "English",
        "rating": "PG",
        "isRented": false
    },
    {
        "id": 3,
        "title": "Casablanca",
        "genre": "Drama",
        "releaseYear": 1942,
        "duration": 102,
        "language": "English",
        "rating": "PG",
        "isRented": true
    }
]
```
#### Get by Id:
```
http://localhost:8080/api/VideoRentalItems/3
```
Example output:
```JSON
{
    "id": 3,
    "title": "Casablanca",
    "genre": "Drama",
    "releaseYear": 1942,
    "duration": 102,
    "language": "English",
    "rating": "PG",
    "isRented": true
}
```
### POST
```
http://localhost:8080/api/VideoRentalItems/
```
Example input:
```JSON
{
    "title": "The Godfather",
    "genre": "Crime",
    "releaseYear": 1972,
    "duration": 115,
    "language": "English",
    "rating": "R",
    "isRented": true
}
```
### PUT
```
http://localhost:8080/api/VideoRentalItems/3
```
Example input:
```JSON
{
    "id": 3,
    "title": "Casablanca",
    "genre": "Drama",
    "releaseYear": 1942,
    "duration": 102,
    "language": "English",
    "rating": "PG",
    "isRented": false
}
```
### DELETE
```
http://localhost:8080/api/VideoRentalItems/3
```