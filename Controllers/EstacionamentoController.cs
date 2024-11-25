using Microsoft.AspNetCore.Mvc;
using SistemaDeControleDeEstacionamento.Repositorio;
using SistemaSimplesDeEstacionamento.Models;
using System.Collections.Generic;

namespace SistemaSimplesDeEstacionamento.Controllers
{
    public class EstacionamentoController : Controller
    {
        private readonly IEstacionamentoRepositorio _estacionamentoRepositorio;
        public EstacionamentoController(IEstacionamentoRepositorio estacionamentoRepositorio)
        {
            _estacionamentoRepositorio = estacionamentoRepositorio;
        }
        public IActionResult Index()
        {
            List<EstacionamentoModel> estacionamentos = _estacionamentoRepositorio.BuscarTodos();
            return View(estacionamentos);
        }

        public IActionResult Adicionar()
        {
            return View();
        }
        public IActionResult Pesquisa()
        {
            return View(new EstacionamentoModel()); 
        }


        public IActionResult ResultadoBusca()
        {
            return View();
        }

        public IActionResult Editar(int id )
        {
            EstacionamentoModel estacionamento= _estacionamentoRepositorio.ListarPorId(id);
            return View(estacionamento);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            EstacionamentoModel estacionamento = _estacionamentoRepositorio.ListarPorId(id);
            return View(estacionamento);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _estacionamentoRepositorio.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Veículo removido com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Opa, não foi possível remover o veículo!";

                }
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Opa, não foi possível remover o veículo! Mais detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Adicionar(EstacionamentoModel estacionamento) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _estacionamentoRepositorio.Adicionar(estacionamento);
                    TempData["MensagemSucesso"] = "Veículo adicionado com sucesso!";
                    return RedirectToAction("Index");

                }

                return View(estacionamento);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Opa, náo foi possível adicionar o veículo, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(EstacionamentoModel estacionamento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _estacionamentoRepositorio.Editar(estacionamento);
                    TempData["MensagemSucesso"] = "Veículo atualizado com sucesso!";
                    return RedirectToAction("Index");

                }
                return View(estacionamento);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Opa, náo foi possível modificar o veículo, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public IActionResult Pesquisar(string nomeProprietario, string marcaModelo, string placa)
        {
            var resultados = _estacionamentoRepositorio.Pesquisar(nomeProprietario, marcaModelo, placa);

            return View("Pesquisa", resultados);
        }
    }
}
