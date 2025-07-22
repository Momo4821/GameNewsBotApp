
       create table usernames
       (
           id          integer primary key autoincrement,
           user_id     text not null,
           username    text not null,
           Server_Activity ,
           created_at  datetime default current_timestamp
       );;