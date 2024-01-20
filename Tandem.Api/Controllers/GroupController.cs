using Microsoft.AspNetCore.Mvc;

namespace Tandem.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class GroupController : ControllerBase
{
    [HttpGet]
    public ActionResult TestGroup()
    {
        return Ok("XYZ_123");
    }
}