using FiapSmartCity.Models;
using FiapSmartCity.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FiapSmartCity.Controllers
{
    public class TipoProdutoController : Controller
    {

        private readonly TipoProdutoRepository TipoProdutoRepository;

        public TipoProdutoController()
        {
            TipoProdutoRepository = new TipoProdutoRepository();
        }

        [Filtros.LogFilter]
        [HttpGet]
        public IActionResult Index()
        {
            var listaTipo = TipoProdutoRepository.Listar();
            return View(listaTipo);
        }

        // Anotação de uso do Verb HTTP Get
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View(new TipoProduto());
        }

        // Anotação de uso do Verb HTTP Post
        [HttpPost]
        public ActionResult Cadastrar(Models.TipoProduto TipoProduto)
        {
            if (ModelState.IsValid)
            {
                TipoProdutoRepository.Inserir(TipoProduto);

                @TempData["mensagem"] = "Tipo cadastrado com sucesso!";
                return RedirectToAction("Index", "TipoProduto");

            }
            else
            {
                return View(TipoProduto);
            }
        }

        [HttpGet]
        public ActionResult Editar(int Id)
        {
            var TipoProduto = TipoProdutoRepository.Consultar(Id);
            return View(TipoProduto);
        }

        [HttpPost]
        public ActionResult Editar(Models.TipoProduto TipoProduto)
        {

            if (ModelState.IsValid)
            {
                TipoProdutoRepository.Alterar(TipoProduto);

                @TempData["mensagem"] = "Tipo alterado com sucesso!";
                return RedirectToAction("Index", "TipoProduto");
            }
            else
            {
                return View(TipoProduto);
            }

        }


        [HttpGet]
        public ActionResult Consultar(int Id)
        {
            var TipoProduto = TipoProdutoRepository.Consultar(Id);
            return View(TipoProduto);
        }


        [HttpGet]
        public ActionResult Excluir(int Id)
        {
            TipoProdutoRepository.Excluir(Id);

            @TempData["mensagem"] = "Tipo removido com sucesso!";

            return RedirectToAction("Index", "TipoProduto");
        }



    }
}