using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

public class PremiumControllerTests
{
    [Fact]
    public void Index_PostValidInput_ReturnsViewWithPremium()
    {
        var mockCalc = new Mock<IInsuranceCalculator>();
        mockCalc.Setup(c => c.CalculatePremium(It.IsAny<InsuranceInput>())).Returns(54000);

        var mockRepo = new Mock<IOccupationRepository>();
        mockRepo.Setup(r => r.GetOccupations()).Returns(new List<Occupation>());

        var loggerMock = new Mock<ILogger<PremiumController>>();
        var controller = new PremiumController(mockCalc.Object, mockRepo.Object, loggerMock.Object);

        var input = new InsuranceInput { Name = "John", AgeNextBirthday = 30, DateOfBirth = "01/1995", OccupationRating = "Professional", DeathSumInsured = 100000 };

        var result = controller.Index(input) as ViewResult;
        Assert.NotNull(result);
        decimal premium =54000M;
        Assert.Equal(premium, result.ViewData["Premium"] );
    }
}
