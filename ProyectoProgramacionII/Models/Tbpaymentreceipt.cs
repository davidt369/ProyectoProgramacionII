using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProyectoProgramacionII.Models;

[Table("tbpaymentreceipts")]
public partial class Tbpaymentreceipt
{
    [Key]
    [Column("PK_paymentreceipt")]
    public int PkPaymentreceipt { get; set; }

    [Column("FK_paymentmethod")]
    public int FkPaymentmethod { get; set; }

    [Column("FK_sale")]
    public int FkSale { get; set; }

    [Column("receiptImage")]
    [StringLength(255)]
    public string ReceiptImage { get; set; } = null!;

    [Column("receiptDate")]
    public DateOnly ReceiptDate { get; set; }

    [Column("receiptTime")]
    public TimeOnly? ReceiptTime { get; set; }

    [Column("status")]
    public bool? Status { get; set; }

    [Column("createdAt", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updatedAt", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("FkPaymentmethod")]
    [InverseProperty("Tbpaymentreceipts")]
    public virtual Tbpaymentmethod FkPaymentmethodNavigation { get; set; } = null!;

    [ForeignKey("FkSale")]
    [InverseProperty("Tbpaymentreceipts")]
    public virtual Tbsale FkSaleNavigation { get; set; } = null!;
}
