﻿using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web_application.Controllers
{
   
    public class PreguntasController : Controller
    {
       
        public ActionResult Index()
        {
            PreguntasBLL oBLL = new PreguntasBLL();
            List<Pregunta> preguntas = oBLL.RetrieveAll();
          

            return View(preguntas);
        }
        public ActionResult IndexNotificacion(int id)
        {
            
            PreguntasBLL oBLL = new PreguntasBLL();
            List<Pregunta> preguntas = oBLL.RetrieveAll();
            ViewBag.notificacion= id;
            return View(preguntas);
            
        }


        public ActionResult Create()
        {
            UsuariosBLL obBLL = new UsuariosBLL();
            List<Usuario> usuarios = obBLL.RetrieveAll();
            ViewBag.UsuarioID = new SelectList(usuarios, "UsuarioID", "UserName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pregunta pregunta)
        {
            ActionResult Result;
            try
            {
                if (ModelState.IsValid)
                {
                    PreguntasBLL oBLL = new PreguntasBLL();
                    oBLL.Create(pregunta);
                    Result = RedirectToAction("Index");
                }
                else
                {
                    Result = View(pregunta);
                }
                return Result;
            }
            catch (Exception e)
            {
                return View(pregunta);
            }
        }

        public ActionResult Edit(int id)
        {
            PreguntasBLL oBLL = new PreguntasBLL();
            Pregunta pregunta= oBLL.Retrieve(id);

            return View(pregunta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pregunta pregunta)
        {
            ActionResult Result;
            try
            {
                if (ModelState.IsValid)
                {
                    PreguntasBLL oBLL = new PreguntasBLL();
                    oBLL.Update(pregunta);
                    Result = RedirectToAction("Index");
                }
                else
                {
                    Result = View(pregunta);
                }
                return Result;
            }
            catch (Exception e)
            {
                return View(pregunta);
            }
        }

        public ActionResult Details(int id)
        {
            PreguntasBLL oBLL = new PreguntasBLL();
            Pregunta pregunta= oBLL.Retrieve(id);
            ViewBag.PreguntaID = id;

            return View(pregunta);
        }

        public ActionResult Delete(int id)
        {
            PreguntasBLL oBLL = new PreguntasBLL();
            oBLL.Delete(id);
            return RedirectToAction("Index"); //redirecionar al index cuando borres
        }
        

        //Guarda y muesta la respuesta recien actualizada 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRespuesta(Pregunta pregunta)
        {

            ViewBag.PreguntaID = pregunta.PreguntaID;
            return View();
        }
        public ActionResult ShowRespuestas(int id)
        {
            RespuestasBLL listBLL = new RespuestasBLL();
            List<Respuesta> respuestas = listBLL.FilterRespuestasByPreguntaID(id);
            return PartialView("_ShowRespuestas",respuestas);
        }
        public ActionResult ShowNewRespuesta(Pregunta pregunta,Respuesta respuesta)
        {
            ActionResult Result;
            try
            {
                if (ModelState.IsValid)
                {
                    RespuestasBLL oBLL = new RespuestasBLL();
                    oBLL.Create(respuesta);
                    RespuestasBLL listBLL = new RespuestasBLL();
                    List<Respuesta> respuestas = listBLL.FilterRespuestasByPreguntaID(pregunta.PreguntaID);        
                    Result = PartialView("_ShowNewRespuesta",respuestas );
                }
                else
                {
                    Result = View(respuesta);
                }
                return Result;
            }
            catch (Exception e)
            {
                return View(respuesta);
            }


        }

        public string Getknownull(int id)
        {
            UsuariosBLL mBLL = new UsuariosBLL();
            Usuario usuario = mBLL.Retrieve(id);
            var foto = usuario.Foto;
            ViewBag.getnull = foto;
            if (foto != null)
            {
                return "true";
            }
            else
            {
                return "false";
            }


        }

        public string Getusuario(int id)
        {
            UsuariosBLL mBLL = new UsuariosBLL();
            Usuario usuario = mBLL.Retrieve(id);
            var name = usuario.UserName;

            return name;
        }

    }
}