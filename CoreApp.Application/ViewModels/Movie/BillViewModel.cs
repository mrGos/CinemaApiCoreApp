using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using CoreApp.Application.ViewModels.System;
using CoreApp.Data.Enums;

namespace CoreApp.Application.ViewModels.Movie
{
    public class BillViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string CustomerName { set; get; }

        [Required]
        [MaxLength(256)]
        public string CustomerAddress { set; get; }

        [Required]
        [MaxLength(50)]
        public string CustomerMobile { set; get; }

        [Required]
        [MaxLength(256)]
        public string CustomerMessage { set; get; }

        public PaymentMethod PaymentMethod { set; get; }

        public BillStatus BillStatus { set; get; }

        public DateTime DateCreated { set; get; }

        public DateTime DateModified { set; get; }

        public Status Status { set; get; }
        public int Quantity { get; set; }
        public decimal TotalPrice { set; get; }
        public decimal Discount { get; set; }
        public string Coupon { set; get; }
        public int BonusPoints { get; set; }
        public Guid CustomerId { set; get; }

        public List<BillDetailViewModel> BillDetails { set; get; }
    }
}
