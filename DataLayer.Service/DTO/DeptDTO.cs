using employ.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataLayer.Service.DQ
{
    public class DeptDTO
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        public string DepartmentName { get; set; } 

        public string? DepartmentDescription { get; set; }

        public DateOnly CreatedDate { get; set; }

        [JsonIgnore]
        public virtual ICollection<EmpDTO> Employees { get; set; } = new List<EmpDTO>();


    }
}
