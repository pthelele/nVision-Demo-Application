using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using nVisionBank.integration;
using nVisionBank.Models;
using Newtonsoft.Json;

namespace nVisionBank.Controllers
{
    public class nVisionBankController : Controller
    {
        // GET: nVisionBank
        public ActionResult Index()
        {
            return View();
        }

       
        public JsonResult Authenticate(/*[FromBody]*/string authmodel)
        {
            var model = JsonConvert.DeserializeObject<AuthenticationViewModel>(authmodel);
            var reposne = new ApiIntegration().ResponseFromAPIPost("Authenticate", model,"http://localhost:2056/api/Authentication/");
            return Json(reposne, JsonRequestBehavior.AllowGet);
        }
    }
}