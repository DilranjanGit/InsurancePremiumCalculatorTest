using System.ComponentModel.DataAnnotations;

/// <summary>
/// Represents insurance input details entered by the user.
/// </summary>
public class InsuranceInput
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Age Next Birthday is required")]
    [Range(1, 120, ErrorMessage = "Age must be between 1 and 120")]
    public int AgeNextBirthday { get; set; }

    [Required(ErrorMessage = "Date of Birth is required")]
    public string DateOfBirth { get; set; } // MM/YYYY format

    [Required(ErrorMessage = "Occupation Rating is required")]
    public string OccupationRating { get; set; }

    [Required(ErrorMessage = "Death Sum Insured is required")]
    [Range(1, double.MaxValue, ErrorMessage = "Death Sum Insured must be greater than 0")]
    public decimal DeathSumInsured { get; set; }
}
