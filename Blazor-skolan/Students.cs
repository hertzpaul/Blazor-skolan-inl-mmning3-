using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions;

namespace Blazor_skolan.Models;
public class Students
{
    public int Id { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }

    [MinimumAge(10, ErrorMessage = "Du måste vara minst 10 år eller äldre")]
    public DateTime birthDay { get; set; }

    [ValidEmail(ErrorMessage = "Ogiltig e-postadress")]
    public string email { get; set; }
}

public class MinimumAgeAttribute : ValidationAttribute
{
    private readonly int _minimumAge;

    public MinimumAgeAttribute(int minimumAge)
    {
        _minimumAge = minimumAge;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null)
        {
            DateTime birthDate = Convert.ToDateTime(value);
            int age = DateTime.Now.Year - birthDate.Year;

            if (age <= _minimumAge)
            {
                return new ValidationResult(ErrorMessage);
            }
        }
        
        return ValidationResult.Success;
    }
}

public class ValidEmailAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null)
        {
            string email = value.ToString();
            if (!IsValidEmail(email))
            {
                return new ValidationResult(ErrorMessage);
            }
        }
        return ValidationResult.Success;
    }

    private bool IsValidEmail(string email)
    {
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        return Regex.IsMatch(email, pattern);
    }
}
