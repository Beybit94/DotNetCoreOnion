using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using test.Data;
using test.Service;

namespace test.Controllers {
    [Route ("api/[controller]/[action]")]
    public class PrivilegeController : Controller {
        private readonly IPrivilegeService privService;
        
        public PrivilegeController(IPrivilegeService privService){
            this.privService=privService;
        }

        [HttpGet]
        public IEnumerable<Privilege> Get(){
            return privService.GetPrivileges();
        }

        [HttpGet("{id}",Name="GetPrivById")]
        public Privilege Get(int id){
            return privService.GetPrivilege(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Privilege priv){
            if(priv==null){
                return BadRequest();
            }

            priv.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString ();
            priv.ModifiedDate = DateTime.Now;
            privService.InsertPrivilege(priv);

            return Ok();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Privilege priv){
            if(priv==null){
                return BadRequest();
            }

            var item = privService.GetPrivilege(priv.Id);
            if (item == null) {
                return NotFound ();
            }

            item.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString ();
            item.ModifiedDate = DateTime.Now;
            item.user.Id=priv.user.Id;
            item.table.Id=priv.table.Id;
            item.isDelete=priv.isDelete;
            item.isInsert=priv.isInsert;
            item.isUpdate=priv.isUpdate;
            item.isView=priv.isView;
            privService.UpdatePrivilege(item);
            
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id){
            var item = privService.GetPrivilege(id);
            if (item == null) {
                return NotFound ();
            }

            privService.DeletePrivilege(item.Id);
            return NoContent();
        }
    }
}