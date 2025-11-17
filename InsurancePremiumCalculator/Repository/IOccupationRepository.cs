/// <summary>
/// Interface for occupation repository.
/// </summary>
public interface IOccupationRepository
{
    IEnumerable<Occupation> GetOccupations();
}
