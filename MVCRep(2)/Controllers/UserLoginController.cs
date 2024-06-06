using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCRep_2_.Models;
using System.Web.Mvc;
using System.Data.Entity.Core.Objects;

namespace MVCRep_2_.Controllers
{
    public class UserLoginController : Controller
    {
        MVCMulti2Entities dbobj = new MVCMulti2Entities();
        // GET: UserLogin
        public ActionResult Login_Load()
        {
            return View();
        }
        public ActionResult User_Home()
        {
            return View();
        }
        public ActionResult Admin_Home()
        {
            return View();
        }
        public ActionResult Login_click(Logincls objcls)
        {
            if (ModelState.IsValid)
            {
                ObjectParameter op = new ObjectParameter("status", typeof(int));
                dbobj.sp_login(objcls.Uname, objcls.password, op);
                int val = Convert.ToInt32(op.Value);
                if (val == 1)
                {
                    var uid = dbobj.sp_loginid(objcls.Uname, objcls.password).FirstOrDefault();
                    Session["uid"] = uid;

                    var loType = dbobj.sp_loginType(objcls.Uname, objcls.password).FirstOrDefault();
                    if (loType == "user")
                    {
                        return RedirectToAction("User_Home");
                    }
                    else if (loType == "admin")
                    {
                        return RedirectToAction("Admin_Home");
                    }
                }
                
            }
            else
            {
                ModelState.Clear();
                objcls.msg = "Inavlid login";
                return View("Login_Load", objcls);
            }
            return View("Login_Load",objcls);
        }
    }
}