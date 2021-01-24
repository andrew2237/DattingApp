﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using DattingApp.API.Data;

namespace DattingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context=context;
        }
        // GET api/values
        [HttpGet]

        public async Task<IActionResult> GetValues()
        {
           var values=await _context.Values.ToListAsync();
           return Ok(values);
        }

        
         [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
           var value=await _context.Values.FirstOrDefaultAsync(x => x.Id == id);
           return Ok(value);
        }
    }
}
