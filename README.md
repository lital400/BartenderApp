# BartenderApp

## What is it for?

```
The University of North Florida
CIS-4327 - IS Senior Project I
Bartender Application Assignment
```

## Description

```
The context for this assignment is bar patrons ordering a cocktail via an online application, 
and a bartender preparing cocktails based on an order queue. 

In this application, bar patrons (customer users) can perform actions such as 
view the cocktail menu and place an order for a cocktail drink. 
The bartender (staff user) is able to view the cocktail order queue 
and set each order for pick up by server after it is prepared.

An Index page acts as a homepage for the application from where patrons can access the cocktail menu, 
and from where bartenders can access the order queue.
```

## Notes

```
This application has no use in the real world.
Both customers and bartender can access their interface from the same homepage (part of the requirements).
User accounts are not implemented.
CRUD operations are implemented but commented out due to the assignment requirements. 
```

## How to install?

```
Download the full project and change the connection string 
in the appsettings.json file to your local DB server name.
I have implemented a database initializer to populate the cocktail menu, 
so it will create a database with cocktail entities for you as soon as you run the application.
The order queue will be empty until a customer places an order. 

```
