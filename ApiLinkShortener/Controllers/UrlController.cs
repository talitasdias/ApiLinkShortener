using ApiLinkShortener.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiLinkShortener.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UrlController(ApiDbContext context) : ControllerBase
{
    private readonly ApiDbContext _context = context;

    [HttpGet]
    public async Task<ActionResult<string>> Get(string shortenLink)
    {
        try
        {
            var url = await _context.UrlMappings.AsNoTracking().SingleOrDefaultAsync(url => url.ShortenUrl == shortenLink);

            if (url is null) return NotFound("Link não encontrado!");

            return new RedirectResult(url.LongUrl);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Ocorreu um problema ao tratar a sua solicitação!");
        }
    }

    [HttpPost]
    public async Task<ActionResult<string>> Post(string longUrl)
    {
        try
        {
            var urlExist = _context.UrlMappings.AsNoTracking().SingleOrDefault(url => url.LongUrl == longUrl);
            if (urlExist is not null) return Ok(urlExist.ShortenUrl);

            UrlMappings url = new UrlMappings
            {
                ShortenUrl = $"ShortenLink/{Guid.NewGuid().ToString().Substring(0, 5)}",
                LongUrl = longUrl
            };

            _context.UrlMappings.Add(url);
            await _context.SaveChangesAsync();

            return Ok(url.ShortenUrl);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Ocorreu um problema ao tratar a sua solicitação!");
        }
    }
}