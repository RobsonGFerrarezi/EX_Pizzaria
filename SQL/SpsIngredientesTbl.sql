create or alter procedure spListagemIngredientesPizza
(@pizzaId int)
as
begin
   select * from tbIngredientesPizza
   where pizzaId = @pizzaId
end
GO

create procedure spInsert_tbIngredientesPizza