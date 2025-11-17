/// <summary>
/// Holds rating factors for different occupation categories.
/// </summary>
public static class RatingFactors
{
    public static readonly Dictionary<string, decimal> Factors = new Dictionary<string, decimal>
    {
        { "Professional", 1.5m },
        { "White Collar", 2.25m },
        { "Light Manual", 11.50m },
        { "Heavy Manual", 31.75m }
    };
}
