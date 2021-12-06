using NuGetRestore.WebAPI.ValidationAttributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace NuGetRestore.WebAPI.Models
{
    /// <summary>
    /// A ticket.
    /// </summary>
    public class Ticket
    {
        /// <summary>
        /// The ticket ID.
        /// </summary>
        public int? TicketId { get; set; }

        /// <summary>
        /// The project ID.
        /// </summary>
        [Required]
        public int? ProjectId { get; set; }

        /// <summary>
        /// The ticket title.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        /// <summary>
        /// The ticket description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The ticket owner.
        /// </summary>
        [StringLength(50)]
        public string Owner { get; set; }

        /// <summary>
        /// Date when the ticket was reported.
        /// </summary>
        [TicketEnsureReportDatePresent]
        public DateTime? ReportDate { get; set; }

        /// <summary>
        /// Date when the ticket is due.
        /// </summary>
        [TicketEnsureDueDatePresent]
        [TicketEnsureFutureDueDateOnCreation]
        [TicketEnsureDueDateAfterReportDate]
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// The <see cref="Project"/>.
        /// </summary>
        public Project Project { get; set; }

        /// <summary>
        /// Validates that a description is present.
        /// </summary>
        /// <returns><c>true</c> if the <see cref="Description"/> has been provided, otherwise <c>false</c>.</returns>
        public bool ValidateDescription()
        {
            return !string.IsNullOrWhiteSpace(Description);
        }

        /// <summary>
        /// Validates, when creating a ticket, the entered due date must be in the future.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the <see cref="TicketId"/> is provided.<para/>
        /// <c>true</c> if the <see cref="DueDate"/> is not provided.<para/>
        /// <c>true</c> if the <see cref="DueDate"/> is in the future, otherwise <c>false</c>.
        /// </returns>
        public bool ValidateFutureDueDate()
        {
            if (TicketId.HasValue) return true;
            if (!DueDate.HasValue) return true;

            return (DueDate.Value > DateTime.Now);
        }

        /// <summary>
        /// Validates, when an owner is assigned to the ticket, the report date must be present.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the owner is not provided.<para/>
        /// <c>true</c> if the <see cref="ReportDate"/> has a value, otherwise <c>false</c>.
        /// </returns>
        public bool ValidateReportDatePresence()
        {
            if (string.IsNullOrWhiteSpace(Owner)) return true;

            return ReportDate.HasValue;
        }

        /// <summary>
        /// Validates, when an owner is assigned to the ticket, the due date must be present.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the owner is not provided.
        /// <c>true</c> if the <see cref="DueDate"/> has a value, otherwise <c>false</c>.
        /// </returns>
        public bool ValidateDueDatePresence()
        {
            if (string.IsNullOrWhiteSpace(Owner)) return true;

            return DueDate.HasValue;
        }

        /// <summary>
        /// Validates, when the due date and report date are provided, the due date has to be later of equal to the report date.
        /// </summary>
        /// <returns></returns>
        public bool ValidateDueDateAfterReportDate()
        {
            if (!DueDate.HasValue || !ReportDate.HasValue) return true;

            return DueDate.Value.Date >= ReportDate.Value.Date;
        }
    }
}
