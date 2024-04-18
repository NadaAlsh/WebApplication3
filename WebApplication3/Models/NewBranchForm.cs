using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class NewBranchForm
    {
        [Required]
        public string LocationName { get; set; }
        [Required]
        public string BranchManager { get; set; }
        [Required]
        public int EmployeeCount { get; set; }
        [Url]
        public string LocationURL { get; set; }

    }
}
