// Controllers/TransactionController.cs
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/transactions")]
public class TransactionController : ControllerBase {
  [HttpGet] public IActionResult Get() => Ok();
}