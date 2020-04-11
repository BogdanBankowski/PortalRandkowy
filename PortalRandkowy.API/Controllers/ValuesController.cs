using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> GetValues()
        {
            var result = await context.Values.ToListAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var result = await context.Values.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(result);
        }

        [HttpPost]
        public async Task AddValue([FromBody]Value value)
        {
            context.Add(value);
            await context.SaveChangesAsync();
        }

        [HttpPut("{id}")]
        public async Task EditValue(int id, [FromBody] Value value)
        {
            var valueToModify = await context.Values.FirstOrDefaultAsync(x => x.Id == id);
            if (valueToModify != null)
            {
                valueToModify.Name = value.Name;
                await context.SaveChangesAsync();
            }
            
        }

        [HttpDelete("{id}")]
        public async Task DeleteValue(int id)
        {
            var valueToDelete = await context.Values.FirstOrDefaultAsync((x => x.Id == id));
            if (valueToDelete != null)
            {
                context.Remove(valueToDelete);
                await context.SaveChangesAsync();
            }
        }
    }
}