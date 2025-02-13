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

namespace ArchiLogApi.Controllers
{
    
    public class ReservationsController : BaseController<ArchiLogDbContext, Reservation>
    {
        

        public ReservationsController(ArchiLogDbContext context) : base(context)
        {        
        }

    }
}
