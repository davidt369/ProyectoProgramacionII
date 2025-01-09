using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProyectoProgramacionII.Models;

[Table("tbsaledetails")]
public partial class Tbsaledetail
{
    [Key]
    [Column("PK_saledetail")]
    public int PkSaledetail { get; set; }

    [Column("FK_sale")]
    public int FkSale { get; set; }

    [Column("FK_product")]
    public int FkProduct { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("unitPrice", TypeName = "decimal(10, 2)")]
    public decimal UnitPrice { get; set; }

    [Column("subtotal", TypeName = "decimal(10, 2)")]
    public decimal Subtotal { get; set; }

    [Column("status")]
    public bool? Status { get; set; }

    [Column("createdAt", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updatedAt", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("FkProduct")]
    [InverseProperty("Tbsaledetails")]
    public virtual Tbproduct FkProductNavigation { get; set; } = null!;

    [ForeignKey("FkSale")]
    [InverseProperty("Tbsaledetails")]
    public virtual Tbsale FkSaleNavigation { get; set; } = null!;
}
