using CrudMvcComAdo.Models;
using CrudMvcComAdo.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudMvcComAdo.Controllers
{
    public class TimeController : Controller
    {
        // GET: Time

        private TimeRepositorio _repositorio;

        private TimeRepositorio _repositorioEstado;

        [HttpGet]
        public ActionResult ObterTimes()
        {
            _repositorio = new TimeRepositorio();

            _repositorio.ObterTimes();
            ModelState.Clear();

            return View(_repositorio.ObterTimes());
        }

        //Incluir

        [HttpGet]
        public ActionResult IncluirTime()
        {
            _repositorio = new TimeRepositorio();

            ViewBag.EstadoId = new SelectList(_repositorio.ObterEstados(), "EstadoId", "EstadoSigla", "1");

            return View();
        }

        [HttpPost]
        public ActionResult IncluirTime(Times timeObj)
        {
            try
            {
                _repositorio = new TimeRepositorio();

                
                    if (_repositorio.AdicionarTime(timeObj))
                    {
                        ViewBag.Mensagem = "Time cadastrado com sucesso";
                    }
                

                ViewBag.EstadoId = new SelectList(_repositorio.ObterEstados(), "EstadoId", "EstadoSigla", "1");

                //return RedirectToAction("ObterTimes");

                return View();
            }
            catch (Exception)
            {
                return View("ObterTimes");
            }
        }


        //Editar

        [HttpGet]
        public ActionResult EditarTime(int id)
        {
            _repositorio = new TimeRepositorio();

            _repositorioEstado = new TimeRepositorio();

            var estadoAtual = _repositorio.ObterTimes().Find(t => t.TimesId == id).EstadoId;

            ViewBag.EstadoId = new SelectList(_repositorioEstado.ObterEstados(), "EstadoId", "EstadoSigla", estadoAtual);

            return View(_repositorio.ObterTimes().Find(t => t.TimesId == id));
        }

        [HttpPost]
        public ActionResult EditarTime(int id, Times timeObj)
        {
            try
            {
                _repositorio = new TimeRepositorio();

                _repositorioEstado = new TimeRepositorio();

                _repositorio.AtualizarTime(timeObj);

                ViewBag.EstadoId = new SelectList(_repositorioEstado.ObterEstados(), "EstadoId", "EstadoSigla", "1");

                return RedirectToAction("ObterTimes");
            }
            catch (Exception)
            {
                return View("ObterTimes");
            }
        }
   
        public ActionResult ExcluirTime(int id)
        {
            try
            {
                _repositorio = new TimeRepositorio();
                if (_repositorio.ExcluirTime(id))
                {
                    ViewBag.Mensagem = "Time excluído com sucesso";
                }

                return RedirectToAction("Obtertimes");
            }
            catch (Exception)
            {
                return View("ObterTimes");
            }
        }
    }
}