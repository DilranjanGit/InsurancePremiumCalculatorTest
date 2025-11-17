using Microsoft.Extensions.Logging;

/// <summary>
/// Implements insurance premium calculation logic.
/// </summary>
public class InsuranceCalculator : IInsuranceCalculator
{
    private readonly ILogger<InsuranceCalculator> _logger;

    public InsuranceCalculator(ILogger<InsuranceCalculator> logger)
    {
        _logger = logger;
    }

    public decimal CalculatePremium(InsuranceInput input)
    {
        _logger.LogInformation("Calculating premium for {Name}", input.Name);

        if (!RatingFactors.Factors.ContainsKey(input.OccupationRating))
        {
            _logger.LogError("Invalid occupation rating: {Rating}", input.OccupationRating);
            throw new ArgumentException("Invalid Occupation Rating");
        }

        decimal factor = RatingFactors.Factors[input.OccupationRating];
        decimal premium = (input.DeathSumInsured * factor * input.AgeNextBirthday) / 1000 * 12;

        _logger.LogInformation("Premium calculated: {Premium}", premium);
        return premium;
    }
}
