create database Assignment5

use Assignment5

create table emp
(
 empid int primary key,
 empname varchar(30),
 salary float
)

insert into emp values (1,'arun',10000)
insert into emp values (2,'bala',8000)
insert into emp values (3,'charan',12000)

create procedure sp_payslip
 @empid int
as
begin
 declare @ename varchar(30), @salary float
 declare @hra float, @da float, @pf float, @it float
 declare @deductions float, @gross float, @net float

 select @ename = empname, @salary = salary
 from emp
 where empid = @empid

 set @hra = @salary * 0.10
 set @da = @salary * 0.20
 set @pf = @salary * 0.08
 set @it = @salary * 0.05

 set @deductions = @pf + @it
 set @gross = @salary + @hra + @da
 set @net = @gross - @deductions

 print 'payslip'
 print 'employee id : ' + cast(@empid as varchar)
 print 'employee name : ' + @ename
 print 'basic salary : ' + cast(@salary as varchar)
 print 'hra (10%) : ' + cast(@hra as varchar)
 print 'da (20%) : ' + cast(@da as varchar)
 print 'gross salary : ' + cast(@gross as varchar)
 print 'pf (8%) : ' + cast(@pf as varchar)
 print 'it (5%) : ' + cast(@it as varchar)
 print 'deductions : ' + cast(@deductions as varchar)
 print 'net salary : ' + cast(@net as varchar)

end

exec sp_payslip 1

create table holiday
(
 holiday_date date,
 holiday_name varchar(30)
)

insert into holiday values('2026-01-26','republic day')
insert into holiday values('2026-08-15','independence day')
insert into holiday values('2026-04-29','diwali')
insert into holiday values('2026-10-02','gandhi jayanti')

create trigger trg_holiday
on emp
for insert, update, delete
as
begin
 declare @today date
 declare @hname varchar(30)
 set @today = cast(getdate() as date)
 select @hname = holiday_name 
 from holiday 
 where holiday_date = @today
 if(@hname is not null)
  begin
   print 'due to '+@hname +' you cannot manipulate data'
   rollback transaction
  end
end
update emp set salary = 15000 where empid = 1
