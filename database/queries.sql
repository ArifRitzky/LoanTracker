-- create table
create table customers (
	id serial primary key,
	name varchar(100) not null,
	nik varchar(16) not null unique check(length(nik) = 16) ,
	income numeric(15, 2) not null check (income > 0)
);

create table loan_applications (
	id serial primary key,
--cek menggunakan inner join dan left join
--inner join
select 
	c.id,
	c.name,
	l.amount
from customers c
inner join loan_applications l on c.id = l.customer_id;

--left join
select 
	c.id,
	c.name,
	l.amount
from customers c
	left join loan_applications l on c.id = l.customer_id;

--check database
-- Uji 1: income negatif (harus ditolak oleh CHECK)
insert into customers (name, nik, income)
values ('Test Negatif', '1111222233334499', -1000);

-- Uji 2: NIK kembar dengan Budi (harus ditolak oleh UNIQUE)
insert into customers (name, nik, income)
values ('Test Kembar', '1111222233334441', 5000000);

-- Uji 3: customer_id tidak ada (harus ditolak oleh FOREIGN KEY)
insert into loan_applications (customer_id, amount, tenor_months, interest_rate_percent)
values (99, 10000000, 12, 10);

-- Uji 4 (tambahan): NIK kurang dari 16 digit (harus ditolak oleh CHECK length)
insert into customers (name, nik, income)
values ('Test Pendek', '123', 5000000);


select * from customers;