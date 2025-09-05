// Controllers/BudgetController.cs
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/budgets")]
public class BudgetController : ControllerBase {
  private readonly BudgetService _svc;
  public BudgetController(BudgetService svc){_svc=svc;}
  [HttpPost] public IActionResult Update() => Ok(_svc.Recalculate());
}