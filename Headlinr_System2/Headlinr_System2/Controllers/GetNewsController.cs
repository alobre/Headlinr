using System.Net;
using Headlinr_System2.Services.Rss;
using Microsoft.AspNetCore.Mvc;

namespace Headlinr_System2.Controllers;

[ApiController]
[Route("[controller]")]
public class GetNewsController(RssService service) : ControllerBase
{
    [HttpGet( template:"GetAllNews",Name = "GetNews")]
    [Produces("application/json")]                            
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllNewsAsync()
    {
        var result = await service.GetAllRssAsync();
        if (string.IsNullOrEmpty(result))
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
        return Ok(result);
    }

    [HttpGet(template: "GetNewsById", Name = "GetNewsById")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetNewsByIdAsync(string id)
    {
        var result = await service.GetByIdAsync(id);
        if (string.IsNullOrEmpty(result))
        {
            return StatusCode((int)HttpStatusCode.BadRequest);
        }
        return Ok(result);
    }
}