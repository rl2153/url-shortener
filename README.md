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
     Send a POST request to this url ``http://localhost:5128/api/auth/register`` with body (raw) parameters, eg.
     ```
     {
          "Username" : "John",
          "Email" : "john.doe@gmail.com",
          "Password" : "John.doe123"
    }
     ```

2. login:
   After the user is registered, log in by sending a POST request to this url ``http://localhost:5128/api/auth/login`` with body (raw) parameters, eg.
   ```
   {
        "Username" : "John",
        "Password" : "John.doe123"
   }
   ```
   If the login is successfull, you will receive a response json containing your auth. token that can be used to make url requests.

3. shorten url:
   To shorten a given url, send a POST request to ``http://localhost:5128/api/url/shorten``, but you need to include your auth. token in the request headers.
   
   To do this, go to headers tab and type ``Authorization`` for key and ``Bearer <your-jwt-token>`` for value.

   In the request body (raw) paste the url you want to shorten, eg. 
   ``"https://www.google.com"``
   
   If the request is successfull, you will receive the generated shor link in the response body, eg. ``https://sho.rt/aa1f36``.

5. retrieve original url:
     To retrieve the original url, send a GET request to ``http://localhost:5128/api/url/{code}`` where you replace ``{code}`` with the actual short code, that was generated in the previous           step, in this case ``aa1f36``.

     You can also just paste the link directly in the browser and you will be redirected to the original page.
     
