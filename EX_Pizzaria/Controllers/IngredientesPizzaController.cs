using EX_Pizzaria.DAO;
using EX_Pizzaria.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EX_Pizzaria.Controllers
{
    public class IngredientesPizzaController : PadraoController<IngredientesPizzaViewModel>
    {
        public IngredientesPizzaController()
        {
            DAO = new IngredientesPizzaDAO();
            GeraProximoId = true;
        }

        protected override void ValidaDados(IngredientesPizzaViewModel model, string operacao)
        {
            base.ValidaDados(model, operacao);
            if (string.IsNullOrEmpty(model.Descricao))
                ModelState.AddModelError("Descricao", "Preencha o nome do ingrediente.");
        }

        public IActionResult ListaIngredientes(int pizzaId)
        {
            try
            {
                ViewBag.pizzaId = pizzaId; // necessário para que na inclusão seja o ingrediente seja associado à pizza 
                var lista = (DAO as IngredientesPizzaDAO).Listagem(pizzaId); // cast foi necessário para acessar método específico dessa classe, que não tem no padrao
                return View(NomeViewIndex, lista);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }


        public IActionResult CriaIngrediente(int PizzaId)
        {
            try
            {
                ViewBag.Operacao = "I";
                var model = new IngredientesPizzaViewModel();
                model.PizzaId = PizzaId;
                PreencheDadosParaView("I", model);
                return View(NomeViewForm, model);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        /// <summary>
        /// Foi necessário enviar o códigoda pizza para listagem de ingredientes afim de listar apenas 
        /// ingredientes da pizza selecionada
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        protected override IActionResult RedirecionaParaIndex(IngredientesPizzaViewModel model)
        {
            return RedirectToAction("ListaIngredientes",
                routeValues: new { pizzaId = model.PizzaId });
        }

    }
}
