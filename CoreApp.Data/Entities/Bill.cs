using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CoreApp.Data.Enums;
using CoreApp.Data.Interfaces;
using CoreApp.Infrastructure.SharedKernel;

namespace CoreApp.Data.Entities
{
    [Table("Bills")]
    public class Bill : DomainEntity<int>, ISwitchable, IDateTracking
    {
        public Bill() { }

        public Bill(string customerName, string customerAddress, string customerMobile, string customerMessage,
            BillStatus billStatus, PaymentMethod paymentMethod, Status status, Guid customerId, int quantity, decimal totalPrice, decimal discount, string coupon, int bonusPoints)
        {
            CustomerName = customerName;
            CustomerAddress = customerAddress;
            CustomerMobile = customerMobile;
            CustomerMessage = customerMessage;
            BillStatus = billStatus;
            PaymentMethod = paymentMethod;
            Status = status;
            CustomerId = customerId;
            Quantity = quantity;
            TotalPrice = totalPrice;
            Discount = discount;
            Coupon = coupon;
            BonusPoints = bonusPoints;
        }

        public Bill(int id, string customerName, string customerAddress, string customerMobile, string customerMessage,
           BillStatus billStatus, PaymentMethod paymentMethod, Status status, Guid customerId, int quantity, decimal totalPrice, decimal discount, string coupon, int bonusPoints)
        {
            Id = id;
            CustomerName = customerName;
            CustomerAddress = customerAddress;
            CustomerMobile = customerMobile;
            CustomerMessage = customerMessage;
            BillStatus = billStatus;
            PaymentMethod = paymentMethod;
            Status = status;
            CustomerId = customerId;
            Quantity = quantity;
            TotalPrice = totalPrice;
            Discount = discount;
            Coupon = coupon;
            BonusPoints = bonusPoints;
        }
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

        [DefaultValue(Status.Active)]
        public Status Status { set; get; } = Status.Active;
        public int Quantity { get; set; }
        public decimal TotalPrice { set; get; }
        public decimal Discount { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Coupon { set; get; }
        public int BonusPoints { get; set; }

        public Guid CustomerId { set; get; }

        [ForeignKey("CustomerId")]
        public virtual AppUser User { set; get; }

        public virtual ICollection<BillDetail> BillDetails { set; get; }
    }
}