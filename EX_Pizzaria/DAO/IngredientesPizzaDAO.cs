using EX_Pizzaria.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System;
using Microsoft.AspNetCore.Mvc;

namespace EX_Pizzaria.DAO
{
    public class IngredientesPizzaDAO : PadraoDAO<IngredientesPizzaViewModel>
    {
        protected override SqlParameter[] CriaParametros(IngredientesPizzaViewModel ingredientes)
        {
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("id", ingredientes.Id);
            parametros[1] = new SqlParameter("Pizzaid", ingredientes.PizzaId);
            parametros[2] = new SqlParameter("descricao", ingredientes.Descricao);
            return parametros;
        }

        protected override IngredientesPizzaViewModel MontaModel(DataRow registro)
        {
            var a = new IngredientesPizzaViewModel();
            a.Id = Convert.ToInt32(registro["id"]);
            a.PizzaId = Convert.ToInt32(registro["Pizzaid"]);
            a.Descricao = registro["descricao"].ToString();
            return a;
        }

        protected override void SetTabela()
        {
            Tabela = "tbIngredientesPizza";
            NomeSpListagem = "spListagemIngredientesPizza";
        }

        public virtual List<IngredientesPizzaViewModel> Listagem(int pizzaId)
        {
            var p = new SqlParameter[]
            {
               new SqlParameter("Pizzaid", pizzaId)
            };
            var tabela = HelperDAO.ExecutaProcSelect(NomeSpListagem, p);
            var lista = new List<IngredientesPizzaViewModel>();
            foreach (DataRow registro in tabela.Rows)
                lista.Add(MontaModel(registro));

            return lista;
        }
    }
}
/*
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
 */

/*
 create or alter procedure spListagemIngredientes
(
	 @pizzaId int
)
as
begin
	 exec('select * from tbIngredientesPizza  where pizzaId = ' + @pizzaId)
end
GO

create procedure spInsert_tbIngredientesPizza
(
	@id int,
	@pizzaId int,
	@descricao varchar(max)
)
as
begin
	insert into tbIngredientesPizza 
		(id, pizzaId, descricao)
	values
		(@id, @pizzaId, @descricao)
end
GO

create procedure spUpdate_tbIngredientesPizza
(
	@id int,
	@pizzaId int,
	@descricao varchar(max)
)
as
begin
	update tbIngredientesPizza set
		pizzaId = @pizzaId,
		descricao = @descricao
	where id = @id
end
GO
 */