create database Employeemanagement;

use Employeemanagement;


create table Employee_Details
(
    Empno int primary key,
    EmpName varchar(50) not null,
    Empsal numeric(10,2) check (Empsal >= 25000),
    Emptype char(1) check (Emptype IN ('F', 'P'))
);



create procedure add_employee
(
    @empname varchar(50),
    @empsal numeric(10,2),
    @emptype char(1)
)
as
begin
    declare @newempno int;
    select @newempno = isnull(max(empno), 0) + 1
    from employee_details;
    insert into employee_details (empno, empname, empsal, emptype)
    values (@newempno, @empname, @empsal, @emptype);
end;

exec add_employee 'Ren', 35000, 'f';
exec add_employee 'Ben', 28000, 'p';
exec add_employee 'zen', 45000, 'f';

select * from employee_details;


create procedure update_salary
(
    @empid int,
    @updatedsal numeric(10,2) output
)
as
begin
    update employee_details
    set empsal = empsal + 100
    where empno = @empid;
    select @updatedsal = empsal
    from employee_details
    where empno = @empid;
end;

select * from Employee_Details
declare @newsal numeric(10,2)
exec update_salary 1, @newsal output;
select @newsal as UpdatedSalary;
