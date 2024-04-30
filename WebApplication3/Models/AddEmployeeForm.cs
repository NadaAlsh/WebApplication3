using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class AddEmployeeForm
    {

        [Required]
    //    [Display(Name = nameof(SharedResources.Name), ResourceType = typeof())]

        public string Name { get; set; }

        private string? nameof(object name)
        {
            throw new NotImplementedException();
        }

        [Required]
        public int CivilId { get; set; }
        [Required]
        public string Position { get; set; }
    }
}
