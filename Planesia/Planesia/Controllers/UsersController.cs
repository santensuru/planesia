using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Planesia.Models;
using Planesia.Service;
using Planesia.Repository;

namespace Planesia.Controllers
{
    public class UsersController : Controller
    {
        //private PlanesiaDBsEntities db = new PlanesiaDBsEntities();
        UserService us = new UserService();

        // GET: Users
        public ActionResult Index()
        {
            if (Session["UserName"] != null)
            {
                string c = Session["UserName"].ToString();
                User user = (from u in us.GetAllUsers()
                             where u.Username.Equals(c)
                             select u).FirstOrDefault<User>();
                int status = user.Status.GetValueOrDefault();
                if (status == 1)
                {
                    return View(us.GetAllUsers());
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            //return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {

            if (Session["UserName"] != null)
            {
                if (id == null)
                {
                    string c = Session["UserName"].ToString();
                    User user = (from u in us.GetAllUsers()
                                 where u.Username.Equals(c)
                                 select u).FirstOrDefault<User>();
                    id = user.UserId;
                }
                //User user = db.Users.Find(id);

                User user1 = us.GetUserById(id.GetValueOrDefault());

                if (user1 == null)
                {
                    return HttpNotFound();
                }
                return View(user1);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            if (Session["UserName"] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,FirstName,LastName,Email,Birthday,Phone,Address,Photo,Gender,Username,Password,Status")] User user)
        {
            if (Session["UserName"] == null)
            {
                if (ModelState.IsValid)
                {
                    //db.Users.Add(user);
                    //db.SaveChanges();
                    user.Status = 0;
                    us.AddUser(user);
                }
                return View("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["UserName"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                //User user = db.Users.Find(id);

                User user = us.GetUserById(id.GetValueOrDefault());

                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,FirstName,LastName,Email,Birthday,Phone,Address,Photo,Gender,Username,Password,Status")] User user)
        {
            if (Session["UserName"] != null)
            {
                if (ModelState.IsValid)
                {
                    //db.Entry(user).State = EntityState.Modified;
                    //db.SaveChanges();

                    us.UpdateUser(user);

                    return RedirectToAction("Profile", "Home");
                }
                return View(user);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["UserName"] != null)
            {
                string c = Session["UserName"].ToString();
                User user = (from u in us.GetAllUsers()
                             where u.Username.Equals(c)
                             select u).FirstOrDefault<User>();
                int status = user.Status.GetValueOrDefault();
                if (status == 1)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    //User user = db.Users.Find(id);

                    User user1 = us.GetUserById(id.GetValueOrDefault());

                    if (user1 == null)
                    {
                        return HttpNotFound();
                    }
                    return View(user1);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            //return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["UserName"] != null)
            {
                string c = Session["UserName"].ToString();
                User user = (from u in us.GetAllUsers()
                             where u.Username.Equals(c)
                             select u).FirstOrDefault<User>();
                int status = user.Status.GetValueOrDefault();
                if (status == 1)
                {
                    //User user = db.Users.Find(id);
                    //db.Users.Remove(user);
                    //db.SaveChanges();

                    us.DeleteUser(id);

                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

    }
}