using Faculdade.Contexts;
using Faculdade.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Faculdade.Controllers
{
    public class AlunosController : Controller
    {
        private EFContext context = new EFContext();

        // Index
        public ActionResult Index()
        {
            return View(context.Alunos.OrderBy(a => a.Nome));
        }

        // Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Aluno aluno)
        {
            context.Alunos.Add(aluno);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Edit
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = context.Alunos.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                context.Entry(aluno).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aluno);
        }

        // Details
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = context.Alunos.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // Delete
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = context.Alunos.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Aluno aluno = context.Alunos.Find(id);
            context.Alunos.Remove(aluno);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}