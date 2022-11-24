using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.DataContext
{
    public class Product
    {
        [Required]
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please add ProductName "), Column(TypeName = "nvarchar(30)")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Please add Rating ")]
        public float Rating { get; set; }

        [Required(ErrorMessage = "Please add Category "), Column(TypeName = "nvarchar(30)")]
        public string Category { get; set; }

        [Required]
        public DateTime AddedDate { get; set; }

        [Required(ErrorMessage = "Please add Price ")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Please add Quantity ")]
        public int Quantity { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate {get; set;}
    }
}
