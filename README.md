# PizzaOrders
Test application for Avesdo 

Author: Jacob Tan

API functionality tested through POSTMAN

Structure:
Main object is the Order, which is composed of:
1. int Id (Primary Key)
2. string CustomerName
3. string CustomerAddr
4. string Pizza
5. bool IsDelivered

Features:

GET 
1. Get all orders
2. Get order by Id
3. Get all pending orders (IsDelivered = false)

POST
1. Create a new order (pass customer name and address as parameters, Pizza is auto generated)
2. Seed database for testing

PUT
1. Update delivery status of an order to delivered

DELETE
1. Delete an order from the database

Instructions:
1. Run solution on IIS Express
2. Seed database by sending a POST request to http://localhost:xxxxx/pizzaorder/seed (replace xxxxx with your local port number)
3. View all orders in the database by sending a GET request to http://localhost:xxxxx/pizzaorder
4. View all pending orders by sending a GET request to http://localhost:xxxxx/pizzaorder/pending
5. Add an order by sending a POST request to http://localhost:49564/pizzaorder/ with parameters "name" and "addr" (customer name and address respectively) 
6. View a specific order by sending a GET request to http://localhost:xxxxx/pizzaorder/{id} where {id} is the order ID
7. Mark an order as delivered by sending a PUT request to http://localhost:49564/pizzaorder/{id} where {id} is the order ID
8. Delete an order by sending a DELETE request to http://localhost:49564/pizzaorder/{id} where {id} is the order ID
