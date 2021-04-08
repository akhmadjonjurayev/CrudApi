using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudAPI.Model;
namespace CrudAPI.Controllers
{
    [Route("api/main")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly DbClass db;
        public MainController(DbClass dbClass)
        {
            db = dbClass;
        }
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            return Ok(db.Emploees.ToList());
        }
        [HttpGet("get/{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var user = db.Emploees.FirstOrDefault(x => x.EmploeeID == id);
                return Ok(user);
            }
            catch
            {
                return BadRequest(new { message = "Something went wrong" });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Emploee emploee)
        {
            if (emploee != null)
            {
                await db.Emploees.AddAsync(emploee);
                await db.SaveChangesAsync();
                return Ok(new { message = "Save Successfully" });
            }
            else return BadRequest(new { message = "Model is empty" });
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody]Emploee emploee)
        {
            if (emploee != null)
            {
                db.Emploees.Update(emploee);
                await db.SaveChangesAsync();
                return Ok(new { message = "Update operation has done successfuly" });
            }
            else return BadRequest(new { message = "Something went wrong" });
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody]int id)
        {
            var user = await db.Emploees.FindAsync(id);
            if (user != null)
            {
                db.Emploees.Remove(user);
                await db.SaveChangesAsync();
                return Ok(new { message = "Delete operation has done successfuly" });
            }
            else return BadRequest(new { message = "Id is not valid" });
        }
    }
}
