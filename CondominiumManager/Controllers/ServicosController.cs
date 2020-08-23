using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CondominiumManager.BLL.Models;
using CondominiumManager.DAL;
using Microsoft.AspNetCore.Authorization;
using CondominiumManager.DAL.Interfaces;

namespace CondominiumManager.Controllers
{
    public class ServicosController : Controller
    {
        private readonly IServicoRepositorio _servicoRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public ServicosController(IServicoRepositorio servicoRepositorio, IUsuarioRepositorio usuarioRepositorio)
        {
            _servicoRepositorio = servicoRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
        }

        // GET: Servicos
        public async Task<IActionResult> Index()
        {
            Usuario usuario = await _usuarioRepositorio.PegarUsuarioPeloNome(User);
            if (await _usuarioRepositorio.VerificarSeUsuarioEstaEmFuncao(usuario, "Morador"))
            {
                return View(await _servicoRepositorio.PegarServicosPeloUsuario(usuario.Id));
            }

            return View(await _servicoRepositorio.PegarTodos());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            Usuario usuario = await _usuarioRepositorio.PegarUsuarioPeloNome(User);
            Servico servico = new Servico
            {
                UsuarioId = usuario.Id
            };

            return View(servico);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServicoId,Nome,Valor,Status,UsuarioId")] Servico servico)
        {
            if (ModelState.IsValid)
            {
                servico.Status = StatusServico.Pendente;
                await _servicoRepositorio.Inserir(servico);
                TempData["NovoRegistro"] = $"Serviço {servico.Nome} solicitado";
                return RedirectToAction(nameof(Index));
            }

            return View(servico);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            Servico servico = await _servicoRepositorio.PegarPeloId(id);
            if (servico == null)
            {
                return NotFound();
            }

            return View(servico);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServicoId,Nome,Valor,Status,UsuarioId")] Servico servico)
        {
            if (id != servico.ServicoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _servicoRepositorio.Atualizar(servico);
                TempData["Atualizacao"] = $"Serviço {servico.Nome} atualizado";
                return RedirectToAction(nameof(Index));
            }
            return View(servico);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            await _servicoRepositorio.Excluir(id);
            TempData["Exclusao"] = $"Serviço excluído";
            return Json("Serviço excluído");
        }
    }
}
