using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CondominiumManager.BLL.Models;
using CondominiumManager.DAL;
using CondominiumManager.DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace CondominiumManager.Controllers
{
    [Authorize(Roles = "Administrador,Sindico")]
    public class EventosController : Controller
    {
        private readonly IEventoRepositorio _eventoRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public EventosController(IEventoRepositorio eventoRepositorio, IUsuarioRepositorio usuarioRepositorio)
        {
            _eventoRepositorio = eventoRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
        }

        // GET: Eventos
        public async Task<IActionResult> Index()
        {
            Usuario usuario = await _usuarioRepositorio.PegarUsuarioPeloNome(User); //User possui as informações do usuário logado

            if (await _usuarioRepositorio.VerificarSeUsuarioEstaEmFuncao(usuario, "Morador"))
            {
                return View(await _eventoRepositorio.PegarEventosPeloId(usuario.Id));
            }
            return View(await _eventoRepositorio.PegarTodos());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            Usuario usuario = await _usuarioRepositorio.PegarUsuarioPeloNome(User);
            Evento evento = new Evento
            {
                UsuarioId = usuario.Id
            };

            return View(evento);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventoId,Nome,Data,UsuarioId")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                await _eventoRepositorio.Inserir(evento);
                TempData["NovoRegistro"] = $"Evento {evento.Nome} inserido com sucesso";
                return RedirectToAction(nameof(Index));
            }

            return View(evento);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Evento evento = await _eventoRepositorio.PegarPeloId(id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventoId,Nome,Data,UsuarioId")] Evento evento)
        {
            if (id != evento.EventoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _eventoRepositorio.Atualizar(evento);
                TempData["Atualizacao"] = $"Evento {evento.Nome} atualizado";
                return RedirectToAction(nameof(Index));
            }

            return View(evento);
        }


        [HttpPost]
        public async Task<JsonResult> Delete(int id) //é JsonResult pois a exclusão é feita por Ajax
        {
            await _eventoRepositorio.Excluir(id);
            TempData["Exclusao"] = $"Evento excluído";
            return Json("Evento excluído");
        }
    }
}

