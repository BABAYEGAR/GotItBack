using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BhuInfo.Data.Service.Encryption;
using GotItBack.Data.Context.DataContext;
using GotItBack.Data.Factory.FactoryClasses;
using GotItBack.Data.Objects.Entities;
using GotItBack.Data.Service.Enums;

namespace GotItBack.Controllers.GotItBackControllers
{
    public class ContactsController : Controller
    {
        private readonly ContactDataContext db = new ContactDataContext();

        // GET: Contacts
        public ActionResult Index()
        {
            return View(db.Contacts.ToList());
        }

        // GET: Contacts/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var contact = db.Contacts.Find(id);
            if (contact == null)
                return HttpNotFound();
            return View(contact);
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "ContactId,PhoneNumber,Email,DisplayNumber,Password")] Contact contact,
            FormCollection collectedValues)
        {
            var loggedinuser = Session["gotitbackloggedinuser"] as Contact;
            if (ModelState.IsValid)
            {
                if (loggedinuser == null)
                {
                    contact.CreatedBy = 0;
                    contact.LastModifiedBy = 0;
                    contact.Role = Usertype.Client.ToString();
                }
                else
                {
                    contact.Role = typeof(Usertype).GetEnumName(int.Parse(collectedValues["Role"]));
                }
                var password = collectedValues["Password"];
                var confirmPassword = collectedValues["ConfirmPassword"];
                contact.DateCreated = DateTime.Now;
                contact.DateLastModified = DateTime.Now;
                if (password == confirmPassword)
                {
                    contact.Password = new Md5Ecryption().ConvertStringToMd5Hash(confirmPassword);
                }
                else
                {
                    TempData["wrongPassword"] = "Make sure the password field and confirm password are the same!";
                    return View(contact);
                }
                var userExist = new ContactFactory().CheckIfUserExist(collectedValues["Email"]);
                if (userExist)
                {
                    TempData["saveContact"] = "A registerged user has this email,Change the email and try again!";
                    return View(contact);
                }
                db.Contacts.Add(contact);
                db.SaveChanges();
                TempData["saveContact"] = "Make sure the password field and confirm password are the same!";

                return RedirectToAction("Index");
            }

            return View(contact);
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var contact = db.Contacts.Find(id);
            if (contact == null)
                return HttpNotFound();
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "ContactId,PhoneNumber,Email,Password,Role,DateCreated,CreatedBy,DisplayNumber")] Contact
                contact)
        {
            if (ModelState.IsValid)
            {
                contact.LastModifiedBy = 0;
                contact.DateLastModified = DateTime.Now;
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var contact = db.Contacts.Find(id);
            if (contact == null)
                return HttpNotFound();
            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var contact = db.Contacts.Find(id);
            db.Contacts.Remove(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}