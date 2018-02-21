using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using test.Data;
using test.Service;

namespace test.Controllers {
    [Route ("api/[controller]/[action]")]
    public class AuthController : Controller {
        private readonly IUserService userService;
        private readonly IPrivilegeService privService;

        public AuthController (IUserService userService, IPrivilegeService privService) {
            this.userService = userService;
            this.privService = privService;
        }

        [HttpPost]
        public JsonResult Login ([FromBody] User user) {
            if (user == null) {
                return Json ("");
            }
            var item = userService.GetUsers ().FirstOrDefault (m => m.login == user.login);
            if (item != null && item.pass.Equals (user.pass)) {
                return Json (item);
            }
            return Json ("");
        }

        [HttpPost]
        public JsonResult Register ([FromBody] User user) {
            if (user == null) {
                return Json ("");
            }

            user.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString ();
            user.ModifiedDate = DateTime.Now;
            userService.InsertUser (user);

            if (user.Id > 0) {
                return Json (user);
            }

            return Json ("");
        }

        [HttpPost]
        public JsonResult CheckAccess ([FromBody] Privilege priv) {
            if (priv == null) {
                return Json ("");
            }
            var item = privService.GetPrivileges ().Where (m => m.user.Id == priv.user.Id && m.table.code == priv.table.code);
            return Json (item != null && item.Count () > 0);
        }
    }
}