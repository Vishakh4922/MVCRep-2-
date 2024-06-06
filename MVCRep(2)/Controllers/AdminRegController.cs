using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCRep_2_.Models;
using System.Web.Mvc;

namespace MVCRep_2_.Controllers
{
    public class AdminRegController : Controller
    {
        MVCMulti2Entities dbobj = new MVCMulti2Entities();
        // GET: AdminReg
        public ActionResult Insertadmin_Load()
        {
            return View();
        }
        
        public ActionResult Insertadmin_click(AdminInsert clsobj)
        {
            if (ModelState.IsValid)
            {
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
                dbobj.sp_adminReg(regid, clsobj.name, clsobj.address, clsobj.phone, clsobj.email);
                dbobj.sp_loginsert(regid, clsobj.username, clsobj.password, "admin");
                clsobj.adminmsg = "Successfully Inserted";
                return View("Insertadmin_Load", clsobj);
            }
            return View("Insertadmin_Load",clsobj);
        }
    }
}