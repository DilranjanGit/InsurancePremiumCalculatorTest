/// <summary>
/// Interface for insurance premium calculation.
/// </summary>
public interface IInsuranceCalculator
{
    decimal CalculatePremium(InsuranceInput input);
}
