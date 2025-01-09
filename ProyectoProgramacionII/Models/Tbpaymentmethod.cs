using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProyectoProgramacionII.Models;

[Table("tbpaymentmethods")]
[Index("Name", Name = "UQ__tbpaymen__72E12F1B75A5B1FF", IsUnique = true)]
public partial class Tbpaymentmethod
{
    [Key]
    [Column("PK_paymentmethod")]
    public int PkPaymentmethod { get; set; }

    [Column("name")]
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Column("description")]
    [StringLength(255)]
    public string? Description { get; set; }

    [Column("qrCodeImage")]
    [StringLength(255)]
    public string QrCodeImage { get; set; } = null!;

    [Column("status")]
    public bool? Status { get; set; }

    [Column("createdAt", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updatedAt", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [InverseProperty("FkPaymentmethodNavigation")]
    public virtual ICollection<Tbpaymentreceipt> Tbpaymentreceipts { get; set; } = new List<Tbpaymentreceipt>();
}
