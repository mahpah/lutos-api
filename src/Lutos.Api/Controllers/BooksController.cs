using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lutos.Domain.Aggregates.BookAggregate;
using Lutos.Domain.SeedWorks;
using Lutos.Infrastructure.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lutos.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly LutosDbContext _dbContext;

        public BooksController(LutosDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<QueryResult<Book>>> Get()
        {
            var list = await _dbContext.Books.Skip(0).Take(10).ToListAsync();
            var count = await _dbContext.Books.LongCountAsync();
            return Ok(new QueryResult<Book>
            {
                Items = list,
                Count = count,
            });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
