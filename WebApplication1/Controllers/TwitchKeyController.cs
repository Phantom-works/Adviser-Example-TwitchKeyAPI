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
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var twitchKey = await dbContext.TwitchKey.FindAsync(id);

            if (twitchKey == null)
            {
                return NotFound();
            }

            return Ok(twitchKey);
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
        public async Task<IActionResult> Put([FromRoute] Guid id, AddTwitchKeyRequest _twitchKeyRequest) // would normally make another file, isnt necesairy for this example
        {
            var twitchKey = await dbContext.TwitchKey.FindAsync(id);

            if (twitchKey == null)
            {
                return NotFound();
            }

            twitchKey.AccessToken = _twitchKeyRequest.AccessToken;
            twitchKey.ExpiresIn = _twitchKeyRequest.ExpiresIn;
            twitchKey.TokenType= _twitchKeyRequest.TokenType;

            await dbContext.SaveChangesAsync();

            return Ok(twitchKey);
        }

        // DELETE api/<TwitchKeyController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var twitchKey = await dbContext.TwitchKey.FindAsync(id);

            if (twitchKey == null)
            {
                return NotFound();
            }

            dbContext.Remove(twitchKey);
            dbContext.SaveChanges();

            return Ok(twitchKey);
        }
    }
}
