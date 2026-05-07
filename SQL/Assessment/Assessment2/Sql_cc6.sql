--1.Write a query to display your birthday(day of week)
select datename(dw, '2004-12-14') as dayofweek;

--2.Write a query to display your age in days
select datediff(day, '2004-12-14', getdate()) as age;




--3.Write a query to display all employees information those who joined before 5 years in the current month
use Assignment2;
select * from emp where month(hiredate)=month(getdate()) and year(hiredate) <= year(getdate())-5;





create database Assessment2
use Assessment2
create table employee(empno int primary key,ename varchar(50),sal float,doj datetime);

begin transaction;
-- a. insert 3 rows
insert into employee(empno, ename, sal, doj) values (1,'ajay',1000,'2020-01-01'),(2,'vijay',1200,'2021-01-01'),(3,'ren',1500,'2019-12-01');
select * from employee;

-- b. update 2nd row salary with 15% increment
update employee set sal = sal * 1.15 where empno = 2;
select * from employee;

-- c. delete first row
delete from employee where empno = 1;
select * from employee;

-- restoring deleted row
insert into employee(empno, ename, sal, doj) values (1,'ajay',1000,'2020-01-01');
select * from employee;

commit transaction;
select * from employee;   


--5. Create a user defined function calculate Bonus for all employees of a  given dept using 	following conditions
	--a.     For Deptno 10 employees 15% of sal as bonus.
	--b.     For Deptno 20 employees  20% of sal as bonus
	--c      For Others employees 5%of sal as bonus
use Assignment2
create or alter function fn_bonus(@deptno int, @sal int)
returns int
as
begin
    declare @bonus int;
    if (@deptno = 10)
        set @bonus = @sal*15/100;
    else if (@deptno = 20)
        set @bonus = @sal*20/100;
    else
        set @bonus = @sal*5/100;
    return @bonus;
end;
select empno, ename, sal, deptno,dbo.fn_bonus(deptno, sal) as bonus from emp;


--6.Create a procedure to update the salary of employee by 500 whose dept name is Sales and current salary is below 1500 (use emp table)
create procedure sp_update
as
begin
    update emp
    set sal = sal+500
    where deptno=(select deptno from dept where dname = 'sales') and sal<1500;
end;
exec sp_update;
select * from emp;