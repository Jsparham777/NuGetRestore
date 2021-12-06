using NuGetRestore.WebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace NuGetRestore.WebAPI.ValidationAttributes
{
    public class TicketEnsureFutureDueDateOnCreationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ticket = validationContext.ObjectInstance as Ticket;

            if (!ticket.ValidateFutureDueDate())
                return new ValidationResult("Due date has to be in the future.");

            return ValidationResult.Success;
        }
    }
}
