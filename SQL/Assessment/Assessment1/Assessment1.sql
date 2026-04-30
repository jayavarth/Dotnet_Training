create database Assessment1
use Assessment1


create table books(id int primary key,title varchar(100) not null,author varchar(100) not null,isbn varchar(20) unique not null,published_date date not null);
insert into books values(1,'My first SQL book','Mary Parker',981483029127,'2012-02-22'),(2,'My Second SQL book','John Mayer',857300923713,'1972-07-03'),(3,'My Third SQL Book','Cary Flint',523120967812,'2015-10-18');


--1.Write a query to fetch the details of the books written by author whose name ends with er.
select * from books where author like '%er';

create table reviews (id int primary key,book_id int not null,reviewer_name varchar(50) not null,content varchar(500),
	rating int check (rating between 1 and 5),published_date date not null,constraint bookfkey foreign key (book_id) references books(id));
insert into reviews values
(1,1,'John Smith','my first review',4,'2017-12-10'),
(2,2,'John Smith','my second review',5,'2017-10-13'),
(3,2,'Alice Walker','another review',1,'2017-10-22');


--2.Display the Title ,Author and ReviewerName for all the books from the above table  
select s.title,s.author,r.reviewer_name from reviews r join books s on s.id=r.book_id;


--3.Display the  reviewer name who reviewed more than one book. 
select reviewer_name from reviews group by reviewer_name having count(distinct book_id)>1;

create table customer(id int primary key,name varchar(20) not null,age int not null,address varchar(50) not null,salary int);
insert into customer values
(1,'Ramesh',32,'Ahmedabad',2000),
(2,'khilan',25,'delhi',1500),
(3,'kaushik',23,'kota',2000),
(4,'chaitali',25,'mumbai',6500),
(5,'hardik',27,'bhopal',8500),
(6,'komal',22,'Mp',4500),
(7,'muffy',24,'indore',10000);

--alter table customer
--alter column salary int null;

--4 Display the Name for the customer from above customer table  who live in same address which has character o anywhere in address
select name from customer where address like '%o%';

create table orders(oid int primary key,date date not null,customer_id int not null,amount int not null
constraint orderfkey foreign key (customer_id) references customer(id));

insert into orders values
(102,'2009-10-08',3,3000),
(100,'2009-10-08',3,1500),
(101,'2009-11-20',2,1560),
(103,'2008-05-20',4,2060);



--5 Write a query to display the   Date,Total no of customer  placed order on same Date  
select date, COUNT(customer_id) as total_customers from orders group by date;


update customer set salary = null where id = 5;
update customer set salary = null where id = 6;




--6 Display the Names of the Employee in lower case, whose salary is null  
select lower(name) as name from customer where salary is null;

create table studentdetails (registerno int primary key,name varchar(50),age int,qualification varchar(20),
    mobileno varchar(15),mail_id varchar(50),location varchar(30),gender char(1));
 
insert into studentdetails values
(2, 'Sai', 22, 'b.e', '9952836777', 'sai@gmail.com', 'chennai', 'm'),
(3, 'Kumar', 20, 'bsc', '7890125648', 'kumar@gmail.com', 'madurai', 'm'),
(4, 'Selvi', 22, 'b.tech', '8904567342', 'selvi@gmail.com', 'selam', 'f'),
(5, 'Nisha', 25, 'm.e', '7834672310', 'nisha@gmail.com', 'theni', 'f'),
(6, 'Saisaran', 21, 'b.a', '7890345678', 'saran@gmail.com', 'madurai', 'f'),
(7, 'Tom', 23, 'bca', '8901234675', 'tom@gmail.com', 'pune', 'm');
 



--7 display gender and total count
select gender,count(*) as total from studentdetails group by gender;