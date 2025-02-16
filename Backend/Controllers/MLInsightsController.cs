using Microsoft.AspNetCore.Mvc;
using SmartExpenseTracker.API.Data;
using SmartExpenseTracker.API.Services;

[Route("api/[controller]")]
[ApiController]
public class MLInsightsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly TrainExpenseModel _trainExpenseModel;

    public MLInsightsController(ApplicationDbContext context)
    {
        _context = context;
        _trainExpenseModel = new TrainExpenseModel();
    }

    [HttpGet]
    public ActionResult<string> GetInsights()
    {
        var expenses = _context.Expenses.ToList();
        if (!expenses.Any())
            return BadRequest("No expense data available.");

        var totalFood = expenses.Where(e => e.Category == "Food").Sum(e => e.Amount);
        var totalTransport = expenses.Where(e => e.Category == "Transport").Sum(e => e.Amount);
        var totalEntertainment = expenses.Where(e => e.Category == "Entertainment").Sum(e => e.Amount);
        var totalSpending = expenses.Sum(e => e.Amount);

        string insight = _trainExpenseModel.PredictInsight(totalFood, totalTransport, totalEntertainment, totalSpending);
        return Ok(insight);
    }
}
