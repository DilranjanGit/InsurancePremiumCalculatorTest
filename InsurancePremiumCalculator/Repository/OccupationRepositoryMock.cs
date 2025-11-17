/// <summary>
/// Mock implementation of IOccupationRepository.
/// </summary>
public class OccupationRepositoryMock : IOccupationRepository
{
    public IEnumerable<Occupation> GetOccupations()
    {
        return new List<Occupation>
        {
            new Occupation { Name = "Cleaner", Rating = "Light Manual" },
            new Occupation { Name = "Doctor", Rating = "Professional" },
            new Occupation { Name = "Author", Rating = "White Collar" },
            new Occupation { Name = "Farmer", Rating = "Heavy Manual" },
            new Occupation { Name = "Mechanic", Rating = "Heavy Manual" },
            new Occupation { Name = "Florist", Rating = "Light Manual" },
            new Occupation { Name = "Other", Rating = "Heavy Manual" }
        };
    }
}
