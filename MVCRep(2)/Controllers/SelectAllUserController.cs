using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCRep_2_.Controllers
{
    public class SelectAllUserController : Controller
    {
        MVCMulti2Entities dbobj = new MVCMulti2Entities();
        // GET: SelectAllUser
        public ActionResult DisplayAll_Load()
        {
            var data = dbobj.sp_SelectAllUsers().ToList();
            ViewBag.userdetails = data;
            return View();
        }
    }
}