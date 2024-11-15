create or alter procedure spListagem
(
	 @tabela varchar(max),
	 @ordem varchar(max)
)
as
begin
	 exec('select * from ' + @tabela +
		' order by ' + @ordem)
end
GO

create or alter procedure spInsert_tbPizza(	@id int,	@descricao varchar(max))asbegin	insert into tbPizza 		(id, descricao)	values		(@id, @descricao)endGOcreate or alter procedure spUpdate_tbPizza(	@id int,	@descricao varchar(max))asbegin	update tbPizza set		descricao = @descricao	where id = @idendGO