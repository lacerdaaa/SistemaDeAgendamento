using Microsoft.AspNetCore.Mvc;
using SistemaDeAgendamentos.Data;
using SistemaDeAgendamentos.Models;

namespace SistemaDeAgendamentos.Controllers
{
    public class AgendamentosController : Controller
    {
        private readonly AgendamentoService _service = new();

        public IActionResult Index()
        {
            var agendamentos = _service.GetAll();
            return View(agendamentos);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Agendamento agendamento)
        {
            if (ModelState.IsValid)
            {
                _service.Add(agendamento);
                return RedirectToAction("Index");
            }
            return View(agendamento);
        }

        public IActionResult Edit(int id)
        {
            var agendamento = _service.GetById(id);
            if (agendamento == null)
                return NotFound();

            return View(agendamento);
        }

        [HttpPost]
        public IActionResult Edit(Agendamento agendamento)
        {
            if (ModelState.IsValid)
            {
                _service.Update(agendamento);
                return RedirectToAction("Index");
            }
            return View(agendamento);
        }

        public IActionResult Delete(int id)
        {
            var agendamento = _service.GetById(id);
            if (agendamento == null)
                return NotFound();

            return View(agendamento);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var agendamento = _service.GetById(id);
            if (agendamento == null)
                return NotFound();

            return View(agendamento);
        }

    }
}
