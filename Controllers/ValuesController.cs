using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using test.Data;
using test.Service;

namespace test.Controllers {
    [Route ("api/[controller]/[action]")]
    public class ValuesController : Controller {
        private readonly IUserService userService;
        private readonly IPrivilegeService privilegeService;
        private readonly ITableService tableService;

        public ValuesController (IUserService userService, IPrivilegeService privilegeService, ITableService tableService) {
            this.userService = userService;
            this.privilegeService = privilegeService;
            this.tableService = tableService;
        }

        // GET api/values
        [HttpGet]
        public void Init () {
            User admin = new User {
                name = "admin",
                login = "admin",
                pass = "123456",
                ModifiedDate = DateTime.Now
            };
            userService.InsertUser (admin);
            if (admin.Id > 0) {

                G_Table userTable = new G_Table {
                    code = "User",
                    name = "User",
                    ModifiedDate = DateTime.Now
                };
                G_Table productTable = new G_Table {
                    code = "Product",
                    name = "Product",
                    ModifiedDate = DateTime.Now
                };
                G_Table privTable = new G_Table {
                    code = "Privilege",
                    name = "Privilege",
                    ModifiedDate = DateTime.Now
                };
                G_Table histTable = new G_Table {
                    code = "Hist",
                    name = "Hist",
                    ModifiedDate = DateTime.Now
                };

                tableService.InsertG_Table (userTable);
                tableService.InsertG_Table (productTable);
                tableService.InsertG_Table (privTable);
                tableService.InsertG_Table (histTable);

                if (userTable.Id > 0) {
                    Privilege userPriv = new Privilege {
                        isDelete = true,
                        isInsert = true,
                        isUpdate = true,
                        isView = true,
                        table = userTable,
                        user = admin,
                        ModifiedDate = DateTime.Now
                    };
                    privilegeService.InsertPrivilege (userPriv);
                }

                if (productTable.Id > 0) {
                    Privilege productPriv = new Privilege {
                        isDelete = true,
                        isInsert = true,
                        isUpdate = true,
                        isView = true,
                        table = productTable,
                        user = admin,
                        ModifiedDate = DateTime.Now
                    };
                    privilegeService.InsertPrivilege (productPriv);
                }
                if (histTable.Id > 0) {
                    Privilege histPriv = new Privilege {
                        isDelete = true,
                        isInsert = true,
                        isUpdate = true,
                        isView = true,
                        table = histTable,
                        user = admin,
                        ModifiedDate = DateTime.Now
                    };
                    privilegeService.InsertPrivilege (histPriv);
                }

                if (privTable.Id > 0) {
                    Privilege privPriv = new Privilege {
                        isDelete = true,
                        isInsert = true,
                        isUpdate = true,
                        isView = true,
                        table = privTable,
                        user = admin,
                        ModifiedDate = DateTime.Now
                    };
                    privilegeService.InsertPrivilege (privPriv);
                }
            }
        }
    }
}