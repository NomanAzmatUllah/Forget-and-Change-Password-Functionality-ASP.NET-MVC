using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using forget_Password.Models;
namespace forget_Password.Controllers
{
    public class AccountController : Controller
    {
        loginregisterEntities db = new loginregisterEntities();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]

        //login
        public ActionResult login(loginivewmodel lg)
        {

            tbl_login t = db.tbl_login.Where(x => x.R_email == lg.R_email && x.R_password == lg.R_password).SingleOrDefault();
            if (t == null)
            {

                return RedirectToAction("login");


            }
            else
            {

                return RedirectToAction("Index", "Home");
            }

            return View();
        }


        //forgetpassword
        [HttpGet]
        public ActionResult forgetpassword()
        {
            return View();
        }


        [HttpPost]
        public ActionResult forgetpassword(loginivewmodel obj)
        {

            tbl_login t = db.tbl_login.Where(x => x.R_email == obj.R_email).SingleOrDefault();
            if (t == null)
            {

                TempData["Data"] = "Please Enter a Email First";
                return RedirectToAction("forgetpassword");
            }
            else
            {

                Session["User_id"] = t.R_id;
                return RedirectToAction("Edit");



            }



            return View();
        }


        //ResetPassword
        [HttpGet]
        public ActionResult Edit(int? id)
        {

            int user_id = Convert.ToInt32(Session["User_id"]);
            id = user_id;

            if (id == null)
            {

                return RedirectToAction("forgetpassword");
            }

           tbl_login  t = db.tbl_login.Where(x => x.R_id == id).SingleOrDefault();


            if (t == null)
            {
                return HttpNotFound();

            }

            return View(t);
        }

        [HttpPost]
        public ActionResult Edit(tbl_login std)
        {
      
            db.Entry(std).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("login");


            return View();
        }

    }

}