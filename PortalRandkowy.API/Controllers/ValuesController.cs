using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PortalRandkowy.API.Data;

namespace PortalRandkowy.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext context;

        public ValuesController(DataContext dataContext)
        {
            context = dataContext;
        }

        [HttpGet]
        public IActionResult GetValues()
        {
            var result = context.Values.ToList();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetValue(int id)
        {
            var result = context.Values.FirstOrDefault(x => x.Id == id);
            return Ok(result);
        }

        [HttpPost]
        public void AddValue([FromBody]Value value)
        {
            context.Add(value);
            context.SaveChanges();
        }

        [HttpPut("{id}")]
        public void EditValue(int id, [FromBody] Value value)
        {
            var valueToModify = context.Values.FirstOrDefault(x => x.Id == id);
            if (valueToModify != null)
            {
                valueToModify.Name = value.Name;
                context.SaveChanges();
            }
            
        }

        [HttpDelete("{id}")]
        public void DeleteValue(int id)
        {
            var valueToDelete = context.Values.FirstOrDefault((x => x.Id == id));
            if (valueToDelete != null)
            {
                context.Remove(valueToDelete);
                context.SaveChanges();
            }
        }
    }
}