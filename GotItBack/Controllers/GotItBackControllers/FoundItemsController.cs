using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GotItBack.Data.Context.DataContext;
using GotItBack.Data.Objects.Entities;
using GotItBack.Data.Service.Enums;
using GotItBack.Data.Service.FileUploader;

namespace GotItBack.Controllers.GotItBackControllers
{
    public class FoundItemsController : Controller
    {
        private FoundItemDataContext db = new FoundItemDataContext();
        private StateDataContext dbs = new StateDataContext();

        // GET: FoundItems
        public ActionResult Index()
        {
            var foundItems = db.FoundItems.Include(f => f.Category).Include(f => f.SubCategory);
            return View(foundItems.ToList());
        }


        // GET: FoundItems/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoundItem foundItem = db.FoundItems.Find(id);
            if (foundItem == null)
            {
                return HttpNotFound();
            }
            return View(foundItem);
        }

        // GET: FoundItems/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "Name");
            return View();
        }

        // POST: FoundItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FoundItemId,DateItemFound,CategoryId,SubCategoryId,Title,Description,Color,Brand,SerialNumber,Model,ItemImage")] FoundItem foundItem)
        {
            HttpPostedFileBase image = Request.Files["ItemImage"];
            if (ModelState.IsValid)
            {
                if (image != null && image.FileName != "")
                {
                    foundItem.ItemImage = new FileUploader().UploadFile(image, UploadType.ItemImage);
                }
                foundItem.DateCreated = DateTime.Now;
                foundItem.DateLastModified = DateTime.Now;
                foundItem.CreatedBy = 0;
                foundItem.LastModifiedBy = 0;
                db.FoundItems.Add(foundItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "Name", foundItem.CategoryId);
            return View(foundItem);
        }

        // GET: FoundItems/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoundItem foundItem = db.FoundItems.Find(id);
            if (foundItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "Name", foundItem.CategoryId);
            ViewBag.SubCategoryId = new SelectList(db.SubCategories, "SubCategoryId", "Name", foundItem.SubCategoryId);
            return View(foundItem);
        }

        // POST: FoundItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FoundItemId,DateItemFound,CategoryId,SubCategoryId,Title,Description,Color,Brand,SerialNumber,Model,ItemImage,CreatedBy,DateCreated,DateLastModified,LastModifiedBy")] FoundItem foundItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foundItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "Name", foundItem.CategoryId);
            ViewBag.SubCategoryId = new SelectList(db.SubCategories, "SubCategoryId", "Name", foundItem.SubCategoryId);
            return View(foundItem);
        }

        // GET: FoundItems/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoundItem foundItem = db.FoundItems.Find(id);
            if (foundItem == null)
            {
                return HttpNotFound();
            }
            return View(foundItem);
        }

        // POST: FoundItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            FoundItem foundItem = db.FoundItems.Find(id);
            db.FoundItems.Remove(foundItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: FoundItems/LostItem
        public ActionResult LostItem()
        {
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "Name");
            ViewBag.SubCategoryId = new SelectList(db.SubCategories, "SubCategoryId", "Name");
            return View();
        }
        // GET: FoundItems/SearchItem
        public ActionResult SearchItem()
        {
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "Name");
            ViewBag.SubCategoryId = new SelectList(db.SubCategories, "SubCategoryId", "Name");
            ViewBag.State = new SelectList(dbs.States, "StateId", "Name");
            return View();
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
