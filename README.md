## Authentication
- The process of verifying the existence (user)

## Authorization
- The process of checking the permissions (role)

## Cookie based authentication
- Comprised of a browser and a sever
- If you want to be authenticated you send a username and password to the server
- The server checks that the credentials are correct
- If credentials are correct, the server creates a session in the server memory
- It then sends the user the session id, this is stored in a cookie in the browser
- When asking for data from the server you pass the session id in the request
- The sever checks the session id is valid before returning data
- Problem with cookie based authentication is if you have a lot of users, the sever can get overloaded with sessions/session requests
- Another issue is if cookies get stolen from the browser, the session id's are stolen as well

## Token based authentication
- Token based authentication also has a browser and a sever
- The browser sends username/pass to the sever and the sever checks that these are valid
- The sever then does not create a session, instead it generates an access token
- The token is an encrypted string which has enough information for the sever to find the user
- The returned token from the server is stored in the browser 
- When the browser asks for data from the server it uses authentication type bearer and passes the token in the request
- The server checks the token is valid before returning the requested data
- This solves the server overload issue as it does not create sessions, instead it just generates tokens
- Tokens have an expiration time so if they are stolen they will stop being usable after 5/10 minutes (standard access token lifetime)
- We have another type of token which is long lived, this is called a refresh token
- Once our access token is expired, we use our refresh token to generate a new access token from the server

## JWT Tokens
- Comprise of Header - Payload - Signature
- Header contains the type of token and the signing algorithm
- Payload contains the claims (properties/definitions of the user). These can be registered/public/private 
- Signature is used to make sure the token has not changed