Project Structure:

**TwoFactorAuthService**: .NET Core class library containing the core logic of the 2FA service.

**TwoFactorAuthService.Api**: .NET Core Web API project containing API controllers.

**Instructions for Launching:**

Clone the repository or download the code.

Open the solution in Visual Studio or your preferred IDE.

Set the TwoFactorAuthService.Api project as the startup project.

Run the application.

**API Description:**

**Send Code Endpoint:**

URL: /api/twofactor/send-code

Method: POST

Request Body: { "phone": "9876543212" }

Response (Success): { "message": "Code sent successfully." }

Response (Error): { "message": "Too many active codes for the phone." }

**Verify Code Endpoint:**

URL: /api/twofactor/verify-code

Method: POST

Request Body: { "phone": "9876543212", "code": "123456" }

Response (Success): { "message": "Code verified successfully." }

Response (Error): { "message": "Code verification failed." }

and also use the swagger for documentation so after running the application. We can test the API using swagger interface.

**Note**

Default URL for running the application is "http://localhost:5257"
