using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace EcommerceProject.DataContext
{
    public class Customer
    {
        [Required]
        [Key]
        public string CustomerId { get; set; }


        [Required(ErrorMessage = "Please add ProductName "), Column(TypeName = "nvarchar(30)")]
        public string CustomerName { get; set; }


        [Required(ErrorMessage = "Please add PhoneNumber "), Column(TypeName = "nvarchar(10)")]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "Please add Balance ")]
        public long Balance { get; set; }


        [Required(ErrorMessage = "Please add Orders ")]
        public int? Orders { get; set; }

        [Required]
        public DateTime LastOrdered { get; set; }

        [Required(ErrorMessage = "Please add Orders ")]
        public string Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate
        {
            get; set;
        }
    }
}
