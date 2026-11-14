-- create table
create table customers (
	id serial primary key,
	name varchar(100) not null,
	nik varchar(16) not null unique check(length(nik) = 16) ,
	income numeric(15, 2) not null check (income > 0)
);

create table loan_applications (
	id serial primary key,
	customer_id integer not null references customers(id),
	amount numeric(15,2) not null check (amount > 0),
	tenor_months integer not null check (tenor_months > 0),
	interest_rate_percent numeric(5,2) not null check(interest_rate_percent >= 0)
	
);

select * from customers;
select * from loan_applications;

-- insert data
insert into customers
	(name, nik, income)
	values
	('Budi Santoso', '1111222233334441', 8000000),
	('Siti Rahma', '1111222233334442', 12000000),
	('Andi Wijaya', '1111222233334443', 5000000),
	('Dewi Lestari', '1111222233334444', 20000000);

insert into loan_applications	
	(customer_id, amount, tenor_months, interest_rate_percent)
	values
	(1, 10000000, 12, 12),
	(1, 25000000, 24, 10),
	(2, 50000000, 36, 9),
	(3, 5000000, 6, 15);