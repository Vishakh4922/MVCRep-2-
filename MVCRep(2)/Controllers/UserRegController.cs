using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCRep_2_.Models;
using System.Web.Mvc;
using System.IO;

namespace MVCRep_2_.Controllers
{
    public class UserRegController : Controller
    {
        MVCMulti2Entities dbobj = new MVCMulti2Entities();
        // GET: UserReg
        public ActionResult Insert_Load()
        {
            return View();
        }
        public ActionResult Insert_click(UserInsert clsobj,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    string fname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/photos");
                    string pa = Path.Combine(s, fname);
                    file.SaveAs(pa);

                    var fullpath = Path.Combine("~\\photos", fname);
                    clsobj.photo = fullpath;
                }
                var getmaxid = dbobj.sp_MaxIdLogin().FirstOrDefault();
                int mid = Convert.ToInt32(getmaxid);
                int regid = 0;
                if (mid == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = mid + 1;
                }
                dbobj.sp_userReg(regid, clsobj.name,clsobj.age, clsobj.address, clsobj.email,clsobj.photo);
                dbobj.sp_loginsert(regid, clsobj.username, clsobj.password, "user");
                clsobj.usermsg = "Successfully Inserted";
                return View("Insert_Load", clsobj);
            }
            return View("Insert_click",clsobj);
        }
    }
}