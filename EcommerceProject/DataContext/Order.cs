using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace EcommerceProject.DataContext
{
    public class Order
    {
        [Required]
       
        public string OrderId { get; set; }


        [Required(ErrorMessage = "Please add BillingName "), Column(TypeName = "nvarchar(30)")]
        public string BillingName { get; set; }


        [Required(ErrorMessage = "Please add Date ")]
        public DateTime Date { get; set; }


        [Required(ErrorMessage = "Please add PaymentStatus "), Column(TypeName = "nvarchar(30)")]
        public string PaymentStatus { get; set; }


        [Required(ErrorMessage = "Please add Total ")]
        public float Total { get; set; }


        [Required(ErrorMessage = "Please add PaymentMethod "), Column(TypeName = "nvarchar(30)")]
        public string PaymentMethod { get; set; }


        [Required(ErrorMessage = "Please add OrderStatus "), Column(TypeName = "nvarchar(30)")]
        public string OrderStatus { get; set; }


        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
