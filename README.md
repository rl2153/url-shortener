# 📎 URL Shortener

A backend URL shortening service built with **.NET**.

## 🚀 Features

- 🧑‍💻 User registration and login  
- 🔐 Authenticated users can:  
  - Generate short URLs from original links  
  - Retrieve original URLs via short codes  

---

## 🛠️ Getting Started

### ▶️ Run the Application

Navigate to the project root and run:

```bash
dotnet run
```

Verify the server is up by visiting:

```
http://localhost:5128/api/hello
```

You should see:

```
"hello"
```

---

## 🔬 Testing the API with Postman

### 1. 📝 Register a User

**POST** `http://localhost:5128/api/auth/register`  
Set the request **body** to `raw > JSON`:

```json
{
  "Username": "John",
  "Email": "john.doe@gmail.com",
  "Password": "John.doe123"
}
```

---

### 2. 🔐 Log In

**POST** `http://localhost:5128/api/auth/login`  
Body (raw JSON):

```json
{
  "Username": "John",
  "Password": "John.doe123"
}
```

You’ll receive a JWT token in the response. You’ll need this to authorize your requests.

---

### 3. ✂️ Shorten a URL

**POST** `http://localhost:5128/api/url/shorten`

#### Headers:
| Key           | Value                        |
|---------------|------------------------------|
| Authorization | Bearer `<your-jwt-token>`    |
| Content-Type  | application/json             |

#### Body (raw JSON):
```json
"https://www.google.com"
```

#### ✅ Example Response:
```json
{
  "shortUrl": "https://sho.rt/aa1f36"
}
```

---

### 4. 🔗 Retrieve Original URL

**GET** `http://localhost:5128/api/url/{code}`  
Replace `{code}` with the actual short code, e.g.:

```
http://localhost:5128/api/url/aa1f36
```

You’ll be redirected to the original URL.

> You can also paste the short link directly into your browser to test redirection.

---

## ✅ Example Flow

1. Register ➡️ Login ➡️ Get Token  
2. Use token to shorten a URL  
3. Use the generated short link to get redirected

---

Enjoy shortening! 🚀