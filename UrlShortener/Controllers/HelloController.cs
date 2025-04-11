using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class HelloController : ControllerBase{

    [HttpGet]
    public IActionResult GetHello() {
        return Ok("Hello");
    }
}