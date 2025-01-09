using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProyectoProgramacionII.Models;

[Table("tbroles")]
[Index("Role", Name = "UQ__tbroles__863D2148B8383F07", IsUnique = true)]
public partial class Tbrole
{
    [Key]
    [Column("PK_role")]
    public int PkRole { get; set; }

    [Column("role")]
    [StringLength(50)]
    public string Role { get; set; } = null!;

    [Column("status")]
    public bool? Status { get; set; }

    [Column("createdAt", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updatedAt", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [InverseProperty("FkRoleNavigation")]
    public virtual ICollection<Tbuser> Tbusers { get; set; } = new List<Tbuser>();
}
