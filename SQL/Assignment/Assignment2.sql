create database Assignment2

use Assignment2

create table dept (
    deptno int primary key,
    dname varchar(20),
    loc varchar(20)
);

create table emp (
    empno int primary key,
    ename varchar(20),
    job varchar(20),
    mgr_id int,
    hiredate date,
    sal int,
    comm int,
    deptno int,
    foreign key (deptno) references dept(deptno)
);

alter table emp
add constraint fk_mgr
foreign key (mgr_id) references emp(empno);

insert into dept values
(10, 'accounting', 'new york'),
(20, 'research', 'dallas'),
(30, 'sales', 'chicago'),
(40, 'operations', 'boston');

insert into emp values
(7839, 'king', 'president', null, '1981-11-17', 5000, null, 10),
(7698, 'blake', 'manager', 7839, '1981-05-01', 2850, null, 30),
(7782, 'clark', 'manager', 7839, '1981-06-09', 2450, null, 10),
(7566, 'jones', 'manager', 7839, '1981-04-02', 2975, null, 20),
(7788, 'scott', 'analyst', 7566, '1987-04-19', 3000, null, 20),
(7902, 'ford', 'analyst', 7566, '1981-12-03', 3000, null, 20),
(7369, 'smith', 'clerk', 7902, '1980-12-17', 800, null, 20),
(7499, 'allen', 'salesman', 7698, '1981-02-20', 1600, 300, 30),
(7521, 'ward', 'salesman', 7698, '1981-02-22', 1250, 500, 30),
(7654, 'martin', 'salesman', 7698, '1981-09-28', 1250, 1400, 30),
(7844, 'turner', 'salesman', 7698, '1981-09-08', 1500, 0, 30),
(7876, 'adams', 'clerk', 7788, '1987-05-23', 1100, null, 20),
(7900, 'james', 'clerk', 7698, '1981-12-03', 950, null, 30),
(7934, 'miller', 'clerk', 7782, '1982-01-23', 1300, null, 10);

select * from emp where ename like 'a%';

select * from emp where mgr_id is null;

select ename, empno, sal from emp
where sal between 1200 and 1400;

select * from emp where deptno = 20;
update emp
set sal = sal * 1.10
where deptno = 20;
select * from emp where deptno = 20;

select count(*) as number_of_clerks
from emp where job = 'clerk';

select job, avg(sal) as avg_salary, count(*) as total
from emp
group by job;

select * from emp
where sal = (select min(sal) from emp)
or sal = (select max(sal) from emp);

select * from dept d
where not exists (
    select 1 from emp e where e.deptno = d.deptno
);

select ename, sal from emp
where job = 'analyst'
and sal>1200
and deptno = 20
order by ename;

select d.deptno, d.dname, sum(e.sal) as total_salary
from dept d
left join emp e on d.deptno = e.deptno
group by d.deptno, d.dname;

select ename, sal from emp
where ename in ('miller', 'smith');

select ename from emp
where ename like 'a%' or ename like 'm%';

select ename, sal * 12 as yearly_salary
from emp where lower(ename) = 'smith';

select ename, sal from emp
where sal not between 1500 and 2850;

select mgr_id, count(*) as total_employees
from emp
where mgr_id is not null
group by mgr_id
having count(*) > 2;