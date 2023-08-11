using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presistence;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        public DataContext Context { get; set; }
        public ActivitiesController(DataContext context)
        {
            Context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities(){
            return await Context.Activities.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(Guid id){
            return await Context.Activities.FindAsync(id);
        }
    }

}
