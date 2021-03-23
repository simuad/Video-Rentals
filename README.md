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
#### Get all items:
```
http://localhost:80/api/VideoRentalItems/
```
#### Get an item by id:
```
http://localhost:80/api/VideoRentalItems/{id}
```
#### Get renter of an item:
```
http://localhost:80/api/VideoRentalItems/{id}/renter
```
#### Get all rented items:
```
http://localhost:80/api/VideoRentalItems/rented
```
### POST
```
http://localhost:80/api/VideoRentalItems/
```
### PUT
```
http://localhost:80/api/VideoRentalItems/{id}
```
### DELETE
#### Delete an item
```
http://localhost:8080/api/VideoRentalItems/{id}
```
#### Delete renter of an item
```
http://localhost:8080/api/VideoRentalItems/{id}/renter
```