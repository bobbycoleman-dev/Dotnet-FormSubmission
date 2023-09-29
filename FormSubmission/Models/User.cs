using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace FormSubmission.Models;

public class User
{
    [Required]
    [MinLength(2, ErrorMessage = "Name must be at least 2 characters long!")]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    [FutureDate]
    [DataType(DataType.Date)]
    public DateTime? DOB { get; set; }

    [Required]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters long!")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [OddNumber]
    public int? OddNumber { get; set; }
}

public class FutureDateAttribute : ValidationAttribute
{    
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)    
    {   
        DateTime todaysDate = DateTime.Today;
        
        if (value == null || ((DateTime)value) >= todaysDate)
        {
            return new ValidationResult("Date selection must be in the past");
        }

        return ValidationResult.Success;
    }
}

public class OddNumberAttribute : ValidationAttribute
{    
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)    
    {   
        
        if (value == null || ((int)value) % 2 == 0)
        {
            return new ValidationResult("Favorite Odd Number must be an odd number!");
        }

        return ValidationResult.Success;
    }
}