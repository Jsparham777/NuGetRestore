using NuGetRestore.WebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace NuGetRestore.WebAPI.ValidationAttributes
{
    public class TicketEnsureDueDateAfterReportDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ticket = validationContext.ObjectInstance as Ticket;

            if (!ticket.ValidateDueDateAfterReportDate())
                return new ValidationResult("Due date has to be after the report date.");

            return ValidationResult.Success;
        }
    }
}
