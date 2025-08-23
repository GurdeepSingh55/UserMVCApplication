using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserMVCApplication.DAL.Entities
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string FullAddress { get; set; } = string.Empty;
        public int StateId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } 
        public virtual State? State { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
