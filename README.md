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
#### Item:

```JSON
{
    "id": 1,
    "title": "A Clockwork Orange",
    "genre": "Crime",
    "releaseYear": 1971,
    "duration": 136,
    "language": "English",
    "rating": "R",
    "renterId": "12345",
    "isRented": true
}
```
#### Contact:

```JSON
{
    "id": 74638,
    "surname": "Dirk",
    "name": "Mike",
    "number": "+37064787734",
    "email": "mikedirk@mail.com"
}
```

### GET
#### Get all items:
```
http://localhost:80/api/VideoRentalItems/
```
#### Get an item by id:
```
http://localhost:80/api/VideoRentalItems/{id}
```
#### Get item with extended information about renter:
```
http://localhost:80/api/VideoRentalItems/{id}/renter
```
#### Get all rented items:
```
http://localhost:80/api/VideoRentalItems/rented
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