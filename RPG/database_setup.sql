create database if not exists rpg;

use rpg;

create table if not exists users(
	id int primary key auto_increment unique,
    username varchar(20) unique,
    password varchar(255),
    email varchar(255)
);

insert into users(username, password, email) value('a@a', 'a@a', 'a@plebanos.xd');
insert into users(username, password, email) value('b@b', 'b@b', 'b@plebanos.xd');
