using Headlinr_System2.Services.Rss;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class NewsController : ControllerBase
{
    private readonly RssService _service;

    public NewsController(RssService service)
        => _service = service;

    [HttpGet("GetAllNews", Name = "GetNews")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<Item>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllNewsAsync()
    {
        try
        {
            var items = await _service.GetAllRssAsync();
            return Ok(items);
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("GetNewsById/{id}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(Item), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync(string id)
    {
        var item = await _service.GetByIdAsync(id);
        if (item == null) return NotFound();
        return Ok(item);
    }
}
