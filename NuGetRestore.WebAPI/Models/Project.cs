using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NuGetRestore.WebAPI.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string ClientName { get; set; }

        public List<Ticket> Tickets { get; set; }
    }
}
