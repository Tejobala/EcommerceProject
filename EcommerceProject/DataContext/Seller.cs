using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace EcommerceProject.DataContext
{
    public class Seller
    {
        [Required(ErrorMessage = "Please Add SellerId"), Column(TypeName = "nvarchar(30)")]
        public string SellerId { get; set; }


        [Required(ErrorMessage = "Please add SellerName "), Column(TypeName = "nvarchar(30)")]
        public string SellerName { get; set; }


        [Required(ErrorMessage = "Please add Products ")]
        public int Products { get; set; }


        [Required(ErrorMessage = "Please add WalletBalance ")]
        public long WalletBalance { get; set; }


        [Required(ErrorMessage = "Please add Revenue ")]
        public float Revenue { get; set; }


        [Required(ErrorMessage = "Please add Rating ")]
        public float Rating { get; set; }


        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
