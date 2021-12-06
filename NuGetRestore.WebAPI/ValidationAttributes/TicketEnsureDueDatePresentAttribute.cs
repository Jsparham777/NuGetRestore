using NuGetRestore.WebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace NuGetRestore.WebAPI.ValidationAttributes
{
    public class TicketEnsureDueDatePresentAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ticket = validationContext.ObjectInstance as Ticket;

            if (!ticket.ValidateDueDatePresence())
                return new ValidationResult("Due date is required.");

            return ValidationResult.Success;
        }
    }
}
