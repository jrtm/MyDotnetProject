using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyDotnetAPI.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class AdminController : ControllerBase
{
    [HttpGet]
    public IActionResult Get([FromQuery] string path)
    {
        using StreamReader reader = new(path);
        var text = reader.ReadToEnd();
        
        return Ok("Here you go: " + text);
    }
    
    [HttpPost]
    public IActionResult Post([FromBody] AdminAction action)
    {
        return Ok("All OK!");
    }
    
}

public record AdminAction(string Action);