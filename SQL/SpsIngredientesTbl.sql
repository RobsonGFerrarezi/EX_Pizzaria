create or alter procedure spListagemIngredientesPizza
(@pizzaId int)
as
begin
   select * from tbIngredientesPizza
   where pizzaId = @pizzaId
end
GO

create procedure spInsert_tbIngredientesPizza(	@id int,	@pizzaId int,	@descricao varchar(max))asbegin	insert into tbIngredientesPizza 		(id, pizzaId, descricao)	values		(@id, @pizzaId, @descricao)endGOcreate procedure spUpdate_tbIngredientesPizza(	@id int,	@pizzaId int,	@descricao varchar(max))asbegin	update tbIngredientesPizza set		pizzaId = @pizzaId,		descricao = @descricao	where id = @idendGO