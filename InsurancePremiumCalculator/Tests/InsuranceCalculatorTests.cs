using Xunit;
using Moq;
using Microsoft.Extensions.Logging;

public class InsuranceCalculatorTests
{
    [Fact]
    public void CalculatePremium_ValidInput_ReturnsCorrectPremium()
    {
        var loggerMock = new Mock<ILogger<InsuranceCalculator>>();
        var calculator = new InsuranceCalculator(loggerMock.Object);

        var input = new InsuranceInput { Name = "John", AgeNextBirthday = 30, DateOfBirth = "01/1995", OccupationRating = "Professional", DeathSumInsured = 100000 };

        decimal premium = calculator.CalculatePremium(input);

        Assert.Equal(54000, premium);
    }

    [Fact]
    public void CalculatePremium_InvalidOccupation_ThrowsException()
    {
        var loggerMock = new Mock<ILogger<InsuranceCalculator>>();
        var calculator = new InsuranceCalculator(loggerMock.Object);

        var input = new InsuranceInput { Name = "John", AgeNextBirthday = 30, DateOfBirth = "01/1995", OccupationRating = "Invalid", DeathSumInsured = 100000 };

        Assert.Throws<ArgumentException>(() => calculator.CalculatePremium(input));
    }
}
