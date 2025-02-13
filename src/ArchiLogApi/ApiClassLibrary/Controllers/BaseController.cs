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
    public class BaseController<TContext, TModel> : ControllerBase where TContext : BaseDbContext where TModel : BaseModel
    {
        protected readonly TContext _context;

        public BaseController(TContext context)
        {
            _context = context;
        }

        // GET: api/Models
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TModel>>> GetAll()
        {
            return await _context.Set<TModel>().Where(x => x.Deleted == false).ToListAsync();
        }
    }
}
