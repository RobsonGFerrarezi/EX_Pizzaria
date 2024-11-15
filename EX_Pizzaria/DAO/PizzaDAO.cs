using EX_Pizzaria.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System;

namespace EX_Pizzaria.DAO
{
    public class PizzaDAO : PadraoDAO<PizzaViewModel>
    {
        protected override void SetTabela()
        {
            Tabela = "tbPizza";
            NomeSpListagem = "spListagem";
        }

        protected override SqlParameter[] CriaParametros(PizzaViewModel pizza)
        {
            SqlParameter[] parametros =
            {
                new SqlParameter("id",pizza.Id),
                new SqlParameter("descricao",pizza.Descricao)
            };

            return parametros;
        }

        protected override PizzaViewModel MontaModel(DataRow registro)
        {
            PizzaViewModel pizza = new PizzaViewModel();
            pizza.Id = Convert.ToInt32(registro["id"]);
            pizza.Descricao = registro["descricao"].ToString();

            return pizza;
        }
    }
}
/*
 create table tbPizza
(
	id int not null primary key, 
	descricao varchar(100) not null 
)
GO
 */

/*
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

create or alter procedure spInsert_tbPizza
(
	@id int,
	@descricao varchar(max)
)
as
begin
	insert into tbPizza 
		(id, descricao)
	values
		(@id, @descricao)
end
GO

create or alter procedure spUpdate_tbPizza
(
	@id int,
	@descricao varchar(max)
)
as
begin
	update tbPizza set
		descricao = @descricao
	where id = @id
end
GO
 */