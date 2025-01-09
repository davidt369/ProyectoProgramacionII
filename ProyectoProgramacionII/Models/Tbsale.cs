using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProyectoProgramacionII.Models;

[Table("tbsales")]
public partial class Tbsale
{
    [Key]
    [Column("PK_sale")]
    public int PkSale { get; set; }

    [Column("FK_user")]
    public int FkUser { get; set; }

    [Column("FK_salestatus")]
    public int FkSalestatus { get; set; }

    [Column("totalAmount", TypeName = "decimal(10, 2)")]
    public decimal TotalAmount { get; set; }

    [Column("status")]
    public bool? Status { get; set; }

    [Column("createdAt", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updatedAt", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("FkSalestatus")]
    [InverseProperty("Tbsales")]
    public virtual Tbsalesstatus FkSalestatusNavigation { get; set; } = null!;

    [ForeignKey("FkUser")]
    [InverseProperty("Tbsales")]
    public virtual Tbuser FkUserNavigation { get; set; } = null!;

    [InverseProperty("FkSaleNavigation")]
    public virtual ICollection<Tbpaymentreceipt> Tbpaymentreceipts { get; set; } = new List<Tbpaymentreceipt>();

    [InverseProperty("FkSaleNavigation")]
    public virtual ICollection<Tbsaledetail> Tbsaledetails { get; set; } = new List<Tbsaledetail>();
}
