using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

/// <summary>
/// Handles premium calculation and form rendering.
/// </summary>
public class PremiumController : Controller
{
    private readonly IInsuranceCalculator _calculator;
    private readonly IOccupationRepository _repository;
    private readonly ILogger<PremiumController> _logger;

    public PremiumController(IInsuranceCalculator calculator, IOccupationRepository repository, ILogger<PremiumController> logger)
    {
        _calculator = calculator;
        _repository = repository;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        ViewBag.Occupations = _repository.GetOccupations();
        return View(new InsuranceInput());
    }

    [HttpPost]
    public IActionResult Index(InsuranceInput input)
    {
        ViewBag.Occupations = _repository.GetOccupations();

        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Invalid input received.");
            return View(input);
        }

        try
        {
            decimal premium = _calculator.CalculatePremium(input);
            ViewBag.Premium = premium;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error calculating premium");
            ViewBag.Error = "An error occurred while calculating premium.";
        }

        return View(input);
    }
}
