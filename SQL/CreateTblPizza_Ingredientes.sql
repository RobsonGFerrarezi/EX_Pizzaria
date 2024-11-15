create table tbPizza
(
	id int not null primary key, 
	descricao varchar(100) not null 
)
GO

create table tbIngredientesPizza
(
	id int not null primary key, 
	pizzaId  int not null, 
	descricao varchar(100) not null
)
GO
alter table tbIngredientesPizza
	add constraint fk_PizzaId
	foreign key (pizzaId) references tbPizza (id)