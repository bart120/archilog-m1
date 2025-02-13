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

namespace ArchiLogApi.Controllers
{
    
    public class CarsController : BaseController<ArchiLogDbContext, Car>
    {
        public CarsController(ArchiLogDbContext context):base(context)
        {
        }
    }
}
