using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProyectoProgramacionII.Models;

[Table("tbsalesstatuses")]
[Index("Name", Name = "UQ__tbsaless__72E12F1B8DEDB20F", IsUnique = true)]
public partial class Tbsalesstatus
{
    [Key]
    [Column("PK_salestatus")]
    public int PkSalestatus { get; set; }

    [Column("name")]
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Column("description")]
    [StringLength(255)]
    public string? Description { get; set; }

    [Column("status")]
    public bool? Status { get; set; }

    [Column("createdAt", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updatedAt", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [InverseProperty("FkSalestatusNavigation")]
    public virtual ICollection<Tbsale> Tbsales { get; set; } = new List<Tbsale>();
}
