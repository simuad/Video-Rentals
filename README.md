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

### Example JSON

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
        "renter": {
            "id": 0,
            "surname": "Vangogh",
            "name": "Jake",
            "number": "+37065841738",
            "email": "jakevan@mail.com"
        },
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
        "renter": {
            "id": 0,
            "surname": "Davis",
            "name": "Luke",
            "number": "+37064787735",
            "email": "davisluke@mail.com"
        },
        "isRented": true
    }
]
```

### GET
#### Get all items:
```
http://localhost:80/api/VideoRentalItems/
```
#### Get all items with information about renter:
```
http://localhost:80/api/VideoRentalItems/renter
```
#### Get an item by id:
```
http://localhost:80/api/VideoRentalItems/{id}
```
#### Get item with extended information about renter:
```
http://localhost:80/api/VideoRentalItems/{id}/renter
```
### POST
#### Create new item:
```
http://localhost:80/api/VideoRentalItems/
```
### PUT
#### Update item by id:
```
http://localhost:80/api/VideoRentalItems/{id}
```
#### Update item's renter by id:
```
http://localhost:80/api/VideoRentalItems/{id}/renter
```
### DELETE
#### Delete an item
```
http://localhost:80/api/VideoRentalItems/{id}
```
#### Delete renter of an item
```
http://localhost:80/api/VideoRentalItems/{id}/renter
```