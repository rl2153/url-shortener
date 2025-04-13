# url shortener

A backend application developed in .NET framework.

Functionality:
1. user registration and login
2. logged in users can generate a short url for a given url link
3. logged in users can retrieve the original

Run the application with commad ``dotnet run`` inside the project repository. 

You can test if the app is running by going to: http://localhost:5128/api/hello which should display a "hello".

Test the functionality with Postman:
1. register user:
     send a POST request to this url ``http://localhost:5128/api/auth/register`` with body (raw) parameters, eg.
     ```
     {
      "Username" : "John",
      "Email" : "john.doe@gmail.com",
      "Password" : "John.doe123"
    }
     ```
     
