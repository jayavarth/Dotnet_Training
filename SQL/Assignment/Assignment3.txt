use assignment2;
 
select * from emp where job = 'manager';
 
select ename, sal from emp where sal > 1000;
 
select ename, sal from emp where ename <> 'james';
 
select * from emp where ename like 's%';
 
select ename from emp where ename like '%a%';
 
select ename from emp where ename like '__l%';
 
select ename, sal/30 as daily_salary from emp where ename = 'jones';
 
select sum(sal) as total_salary from emp;
 
select avg(sal*12) as avg_annual_salary from emp;
 
select ename, job, sal, deptno from emp where job <> 'salesman' and deptno = 30;
 
select distinct deptno from emp;
 
select ename as employee, sal as monthly_salary from emp where sal > 1500 and deptno in (10, 30);
 
select ename, job, sal from emp where job in ('manager', 'analyst') and sal not in (1000, 3000, 5000);
 
select ename, sal, comm from emp where comm > sal * 1.10;
 
select ename from emp where (ename like '%l%l%' and deptno = 30) or mgr_id= 7782;
 
select count(*) from emp where datediff(year, hiredate, getdate()) between 31 and 39;
 
select d.dname, e.ename from emp e join dept d on e.deptno = d.deptno order by d.dname asc, e.ename desc;
 
select ename,datediff(year, hiredate, getdate()) as experience from emp where ename = 'miller';