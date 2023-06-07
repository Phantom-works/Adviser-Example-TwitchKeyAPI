using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using TwitchKeyAPI.Data;
using TwitchKeyAPI.Models;

namespace TwitchKeyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwitchKeyController : ControllerBase
    {

        private readonly TwitchKeyAPIDbContext dbContext;

        public TwitchKeyController(TwitchKeyAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/<TwitchKeyController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await dbContext.TwitchKey.ToListAsync());
        }

        // GET api/<TwitchKeyController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TwitchKeyController>
        [HttpPost]
        public async Task<IActionResult> Post(AddTwitchKeyRequest _twitchKeyRequest)
        {
            TwitchKey twitchKey = new TwitchKey()
            {
                Id = Guid.NewGuid(),
                AccessToken = _twitchKeyRequest.AccessToken,
                ExpiresIn = _twitchKeyRequest.ExpiresIn,
                TokenType = _twitchKeyRequest.TokenType
            };

            await dbContext.TwitchKey.AddAsync(twitchKey);
            await dbContext.SaveChangesAsync();


            return Ok(twitchKey);
        }

        // PUT api/<TwitchKeyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TwitchKeyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
