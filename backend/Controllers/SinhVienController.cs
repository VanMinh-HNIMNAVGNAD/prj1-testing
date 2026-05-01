using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")] 
public class SinhVienController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Chạy được API Sinh Viên rồi Minh nhé!");
    }
}