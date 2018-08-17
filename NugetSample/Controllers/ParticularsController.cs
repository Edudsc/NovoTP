using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace IdentitySample.Controllers
{
    [Authorize(Roles ="Admin,Particular")]
    public class ParticularsController : Controller
    {
        private ApplicationDbContext db;
        protected ApplicationDbContext ApplicationDbContext { get; set; }
        protected UserManager<ApplicationUser> UserManager { get; set; }

        public ParticularsController()
        {
            db = new ApplicationDbContext();
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
        }

        // GET: Particulars
        public ActionResult Index()
        {
            return View(db.Particulares.ToList());
        }

        // GET: Particulars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Particular particular = db.Particulares.Find(id);
            if (particular == null)
            {
                return HttpNotFound();
            }
            return View(particular);
        }

        // GET: Particulars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Particulars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ViewModelParticular model)
        {
            if (ModelState.IsValid)
            {
                var dados = new Particular
                {
                    Nome = model.Nome,
                    Bi = model.Bi,
                    Morada = model.Morada,
                    DataNascimento = model.DataNascimento,
                    Cconducao = model.Cconducao,
                    Email = model.Cconducao,
                    Tel = model.Tel
                };

                db.Particulares.Add(dados);
                db.SaveChanges();

                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Perfil = "Particular",
                    ParticularId = dados.ParticularId
                };

                var adminresult = await UserManager.CreateAsync(user, model.Password);
                //Add User ao Role
                if (adminresult.Succeeded)
                {
                    var result = await UserManager.AddToRoleAsync(user.Id, "Particular");
                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("",result.Errors.First());
                        return View();
                    }
                 
                }
                else
                {
                    ModelState.AddModelError("", adminresult.Errors.First());
                    return View();
                }

                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Particulars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Particular particular = db.Particulares.Find(id);
            if (particular == null)
            {
                return HttpNotFound();
            }
            return View(particular);
        }

        // POST: Particulars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ParticularId,Nome,Bi,Morada,DataNascimento,Cconducao,Email,Tel")] Particular particular)
        {
            if (ModelState.IsValid)
            {
                db.Entry(particular).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(particular);
        }

        // GET: Particulars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Particular particular = db.Particulares.Find(id);
            if (particular == null)
            {
                return HttpNotFound();
            }
            return View(particular);
        }

        // POST: Particulars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Particular particular = db.Particulares.Find(id);
            db.Particulares.Remove(particular);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
