# Authentication API Documentation

## Login

**Endpoint:** `POST /api/v1.0/auth/login`

**Description:** Authenticates a user with a username and password.

**Headers:**
- None

**Body:**
```json
{
    "username": "string",
    "password": "string"
}
```

**Responses:**
- `200 OK`: Returns the authenticated user's token.
- `401 Unauthorized`: If the username or password is incorrect.

---

## Register

**Endpoint:** `POST /api/v1.0/auth/register`

**Description:** Registers a new user.

**Headers:**
- None

**Body:**
```json
{
    "username": "string",
    "password": "string",
    "email": "string"
}
```

**Responses:**
- `200 OK`: Returns the newly registered user's token.
- `400 Bad Request`: If the username or email already exists.

---

## Check Token

**Endpoint:** `GET /api/v1.0/auth/token/check`

**Description:** Checks if a token is valid.

**Headers:**
- `x-auth-token`: The token to check.

**Responses:**
- `200 OK`: If the token is valid, returns a message indicating the token is valid.
- `401 Unauthorized`: If the token is invalid, returns a message indicating the reason.

---

## Logout

**Endpoint:** `POST /api/v1.0/auth/logout`

**Description:** Logs out a user, invalidating their current token.

**Headers:**
- `x-auth-token`: The token of the user to log out.

**Responses:**
- `200 OK`: Returns a message indicating the user was logged out successfully.
- `401 Unauthorized`: If the token is invalid.

---

## Change Username

**Endpoint:** `POST /api/v1.0/auth/username/change`

**Description:** Changes a user's username.

**Headers:**
- `x-auth-token`: The token of the user changing their username.

**Body:**
```json
{
    "newUsername": "string"
}
```

**Responses:**
- `200 OK`: Returns a message indicating the username was changed successfully.
- `400 Bad Request`: If the new username already exists.
- `401 Unauthorized`: If the token is invalid.

---

## Change Email

**Endpoint:** `POST /api/v1.0/auth/email/change`

**Description:** Changes a user's email.

**Headers:**
- `x-auth-token`: The token of the user changing their email.

**Body:**
```json
{
    "newEmail": "string"
}
```

**Responses:**
- `200 OK`: Returns a message indicating the email was changed successfully.
- `400 Bad Request`: If the new email already exists.
- `401 Unauthorized`: If the token is invalid.

---

## Reset Password

**Endpoint:** `POST /api/v1.0/auth/password/reset`

**Description:** Resets a user's password.

**Headers:**
- `x-auth-token`: The token of the user resetting their password.

**Body:**
```json
{
    "old": "string",
    "new": "string"
}
```

**Responses:**
- `200 OK`: Returns a message indicating the password was reset successfully.
- `400 Bad Request`: If the old password is incorrect.
- `401 Unauthorized`: If the token is invalid.

---

## Profile

**Endpoint:** `GET /api/v1.0/auth/profile`

**Description:** Retrieves a user's profile information.

**Headers:**
- `x-auth-token`: The token of the user retrieving their profile.

**Responses:**
- `200 OK`: Returns the user's profile information.
- `401 Unauthorized`: If the token is invalid.

---

## Get Settings

**Endpoint:** `GET /api/v1.0/auth/settings`

**Description:** Retrieves a user's settings.

**Headers:**
- `x-auth-token`: The token of the user retrieving their settings.

**Responses:**
- `200 OK`: Returns the user's settings.
- `404 Not Found`: If the user's settings do not exist.
- `401 Unauthorized`: If the token is invalid.

---

## Update Settings

**Endpoint:** `PUT /api/v1.0/auth/settings`

**Description:** Updates a user's settings.

**Headers:**
- `x-auth-token`: The token of the user updating their settings.

**Body:**
```json
{
    // The settings to update
}
```

**Responses:**
- `200 OK`: Returns a message indicating the settings were updated successfully.
- `404 Not Found`: If the user's settings do not exist.
- `401 Unauthorized`: If the token is invalid.~~~~