using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static RomanNumConvertAPI.Models.RomanNumViewModel;
using static RomanNumConvertAPI.Controllers.RomanNumeralController;

namespace RomanNumConvertAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecentConversionController : ControllerBase
    {

        

        [HttpGet]
        public async Task<ActionResult<List<RomanNumeral>>> Get()
        {
            return Ok(romanNumerals);
        }

       
    }
}