using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int CivilId { get; set; }

        public string Position { get; set; }
        [Required]
        public int BankBranchId { get; set; }
        [Required]
        public BankBranch BankBranch { get; set; }
    }

   
}
