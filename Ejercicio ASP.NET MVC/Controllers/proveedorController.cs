using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ejercicio_ASP.NET_MVC.Models;

namespace Ejercicio_ASP.NET_MVC.Controllers
{
    public class proveedorController : Controller
    {
        private pricing_testEntities db = new pricing_testEntities();

        // GET: proveedor
        public ActionResult GetProveedors()
        {
            var proveedor = db.proveedor.Include(p => p.ciudad).Include(p => p.comuna);
            return View(proveedor.ToList());
        }

        // GET: proveedor/Create
        public ActionResult Create()
        {
            ViewBag.id_ciudad = new SelectList(db.ciudad, "id", "nombre");
            ViewBag.id_comuna = new SelectList(db.comuna, "id", "nombre");
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "rut,nombre,telefono,pagina_web,direccion,id_comuna,id_ciudad")] proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.proveedor.Add(proveedor);
                    db.SaveChanges();
                }
                catch
                {

                }

                return RedirectToAction("GetProveedors");
            }

            ViewBag.id_ciudad = new SelectList(db.ciudad, "id", "nombre", proveedor.id_ciudad);
            ViewBag.id_comuna = new SelectList(db.comuna, "id", "nombre", proveedor.id_comuna);
            return RedirectToAction("GetProveedors");
        }

        // GET: proveedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proveedor proveedor = db.proveedor.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_ciudad = new SelectList(db.ciudad, "id", "nombre", proveedor.id_ciudad);
            ViewBag.id_comuna = new SelectList(db.comuna, "id", "nombre", proveedor.id_comuna);
            return View(proveedor);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "rut,nombre,telefono,pagina_web,direccion,id_comuna,id_ciudad")] proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GetProveedors");
            }
            ViewBag.id_ciudad = new SelectList(db.ciudad, "id", "nombre", proveedor.id_ciudad);
            ViewBag.id_comuna = new SelectList(db.comuna, "id", "nombre", proveedor.id_comuna);
            return View(proveedor);
        }

        // GET: proveedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proveedor proveedor = db.proveedor.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // POST: proveedor/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            proveedor proveedor = db.proveedor.Find(id);
            db.proveedor.Remove(proveedor);
            db.SaveChanges();
            return RedirectToAction("GetProveedors");
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
