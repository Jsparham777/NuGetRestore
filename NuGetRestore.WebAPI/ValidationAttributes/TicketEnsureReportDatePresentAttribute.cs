using NuGetRestore.WebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace NuGetRestore.WebAPI.ValidationAttributes
{
    public class TicketEnsureReportDatePresentAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ticket = validationContext.ObjectInstance as Ticket;

            if (!ticket.ValidateReportDatePresence())
                return new ValidationResult("Report date is required.");

            return ValidationResult.Success;
        }
    }
}
