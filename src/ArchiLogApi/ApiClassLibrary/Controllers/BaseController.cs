using ApiClassLibrary.Data;
using ApiClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ApiClassLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TContext, TModel> : ControllerBase where TContext : BaseDbContext where TModel : BaseModel
    {
        protected readonly TContext _context;

        public BaseController(TContext context)
        {
            _context = context;
        }

        // GET: api/[Models]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TModel>>> GetAll()
        {
            return await _context.Set<TModel>().Where(x => x.Deleted == false).ToListAsync();
        }

        // GET: api/[Models]/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TModel>> GetById(int id)
        {
            var model = await _context.Set<TModel>().FindAsync(id);

            if (model == null)
            {
                return NotFound();
            }
            if (model.Deleted == true)
            {
                return NotFound();
            }
            return model;
        }

        // PUT: api/[Models]/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TModel model)
        {
            if (id != model.ID)
            {
                return BadRequest();
            }

            _context.Entry(model).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/[Models]
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TModel>> Post(TModel model)
        {
            _context.Set<TModel>().Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { id = model.ID }, model);
        }

        // DELETE: api/[Models]/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var car = await _context.Set<TModel>().FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            if (car.Deleted == true)
            {
                return NotFound();
            }

            _context.Set<TModel>().Remove(car);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModelExists(int id)
        {
            return _context.Set<TModel>().Any(e => e.ID == id);
        }
    }
}
