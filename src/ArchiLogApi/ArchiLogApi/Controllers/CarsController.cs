using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArchiLogApi.Data;
using ArchiLogApi.Models;
using ApiClassLibrary.Controllers;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ApiClassLibrary.Extensions;

namespace ArchiLogApi.Controllers
{
    /// <summary>
    /// Controlleur pour les voitures, le CRUD est implémenté dans la class mère BaseController
    /// </summary>
    public class CarsController : BaseController<ArchiLogDbContext, Car>
    {
        public CarsController(ArchiLogDbContext context):base(context)
        {
        }

        public override async Task<ActionResult<IEnumerable<Car>>> GetAll()
        {
            var list2 = await  _context.Cars.Where(x => !x.Deleted).Sort("Modele").ToListAsync();
            return list2;
        }
    }
}
