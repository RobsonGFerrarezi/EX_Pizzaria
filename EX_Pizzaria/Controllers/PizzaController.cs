using EX_Pizzaria.DAO;
using EX_Pizzaria.Models;
using Microsoft.AspNetCore.Mvc;

namespace EX_Pizzaria.Controllers
{
    public class PizzaController : PadraoController<PizzaViewModel>
    {
        public PizzaController()
        {
            DAO = new PizzaDAO();
            GeraProximoId = true;
        }

        protected override void ValidaDados(PizzaViewModel pizza, string Operacao)
        {
            base.ValidaDados(pizza, Operacao);

            if (string.IsNullOrEmpty(pizza.Descricao))
                ModelState.AddModelError("descricao", "Campo obrigatório, digite o nome da pizza!");
        }

        protected override void PreencheDadosParaView(string Operacao, PizzaViewModel model)
        {
            base.PreencheDadosParaView(Operacao, model);
        }
    }
}
