namespace QuoteService.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    [Route("[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly QuoteContext _context;
        private Version _version;

        public QuotesController(QuoteContext context, IConfiguration config)
        {
            _context = context;
        }

        [HttpGet("rand")]
        public async Task<ActionResult<Quote>> Get()
        {
            Quote quote = await _context.Quotes
                                 .OrderBy(x => Guid.NewGuid())
                                 .FirstAsync();
            // Increase processor usage to force scaleout
            var dummy = CalcFactorial(1000);
            Console.WriteLine("Calculated 1000! = " + dummy);
            return quote;
        }

        [HttpGet("rand/{number}")]
        public async Task<ActionResult<IEnumerable<Quote>>> Get(int number)
        {
            if (number <= 0 || number >= 10)
            {
                return BadRequest();
            }

            return await _context.Quotes
                     .OrderBy(x => Guid.NewGuid())
                     .Take(number)
                     .ToListAsync();
        }


        private static BigInteger CalcFactorial(BigInteger i)
        {
            if (i <= 1)
                return 1;
            return i * CalcFactorial(i - 1);
        }
    }
}
