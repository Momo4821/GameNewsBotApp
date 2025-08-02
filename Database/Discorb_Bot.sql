create table IF NOT EXISTS Discord_Requests (
    Request_ID INT AUTO_INCREMENT PRIMARY KEY,
    User_ID INT NOT NULL,
    Command VARCHAR(255) NOT NULL,
    Request_Time TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    app_id VARCHAR(255) NOT NULL,
    http_url VARCHAR(255) NOT NULL,
    FOREIGN KEY (User_ID) REFERENCES Users(User_ID)
);


create table if not exists Users (
    User_ID INT AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL UNIQUE,
    Created_At TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);




/* This table is used to log requests made by users for Discord commands.
    It includes the ID of the request, the user who made the request, the command requested, and the time of the request.
    The User_ID is a foreign key that references the Users table to ensure that each request is associated with a valid user.
   
   
   
 */