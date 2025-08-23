using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMVCApplication.DAL.Entities;

namespace UserMVCApplication.BLL.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = string.Empty;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int? AddressId { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string FullAddress { get; set; } =string.Empty;
        [Required(ErrorMessage = "State is required.")]
        public int StateId { get; set; }
        public string? StateName { get; set; }
        public virtual Address? Address { get; set; }
    }
}
