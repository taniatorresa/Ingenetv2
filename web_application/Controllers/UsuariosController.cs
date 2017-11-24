using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace web_application.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            UsuariosBLL oBLL = new UsuariosBLL();
            List<Usuario> usuarios = oBLL.RetrieveAll();
            return View(usuarios);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            ActionResult Result;
            try
            {
                if (ModelState.IsValid)
                {
                    UsuariosBLL oBLL = new UsuariosBLL();
                    oBLL.Create(usuario);
                    Result = RedirectToAction("Index");
                }
                else
                {
                    Result = View(usuario);
                }
                return Result;
            }
            catch (Exception e)
            {
                return View(usuario);
            }
        }
        public ActionResult Edit(int id)
        {
            UsuariosBLL oBLL = new UsuariosBLL();
            Usuario usuario = oBLL.Retrieve(id);

            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuario)
        {
            ActionResult Result;
            try
            {
                if (ModelState.IsValid)
                {
                    UsuariosBLL oBLL = new UsuariosBLL();
                    oBLL.Update(usuario);
                    Result = RedirectToAction("Index");
                }
                else
                {
                    Result = View(usuario);
                }
                return Result;
            }
            catch (Exception e)
            {
                return View(usuario);
            }
        }

        public ActionResult Details(int id)
        {
            UsuariosBLL oBLL = new UsuariosBLL();
            Usuario usuario = oBLL.Retrieve(id);

            return View(usuario);
        }

        public ActionResult Delete(int id)
        {

            UsuariosBLL oBLL = new UsuariosBLL();
            oBLL.Delete(id);
            return RedirectToAction("Index"); //redirecionar al index cuando borres
        }
    }
}