create database CatTest;


use CatTest;
go

create table projects(
	project_id int primary key,
	project_name varchar(255) not null
);

create table employees(
	employee_id int primary key,
	employee_name varchar(255) not null,
	project_id int not null,
	constraint emp_project_FK  foreign key (project_id) 
	references projects(project_id)
);

insert into projects (project_id, project_name)
values
(101, 'Project A'),
(102, 'Project B'),
(103, 'Project C');

insert into employees (employee_id, employee_name, project_id)
values
(1, 'Alice', 101),
(2, 'Bob', 102),
(3, 'Charlie', 101),
(4, 'David', 103),
(5, 'Eva', 102);


select p.project_name as'project_name' ,COUNT(e.employee_id) as 'employee_count'
from projects as p join employees as e
on p.project_id = e.project_id
group by p.project_name
order by p.project_name;
