using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProyectoProgramacionII.Models;

[Table("tbusers")]
[Index("Email", Name = "UQ__tbusers__AB6E616462976EE3", IsUnique = true)]
public partial class Tbuser
{
    [Key]
    [Column("PK_user")]
    public int PkUser { get; set; }

    [Column("FK_role")]
    public int FkRole { get; set; }

    [Column("firstName")]
    [StringLength(80)]
    public string FirstName { get; set; } = null!;

    [Column("lastName")]
    [StringLength(80)]
    public string LastName { get; set; } = null!;

    [Column("email")]
    [StringLength(255)]
    public string Email { get; set; } = null!;

    [Column("password")]
    [StringLength(255)]
    public string Password { get; set; } = null!;

    [Column("profileImage")]
    [StringLength(255)]
    public string? ProfileImage { get; set; }

    [Column("status")]
    public bool Status { get; set; }

    [Column("createdAt", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updatedAt", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("FkRole")]
    [InverseProperty("Tbusers")]
    public virtual Tbrole FkRoleNavigation { get; set; } = null!;

    [InverseProperty("FkUserNavigation")]
    public virtual ICollection<Tbsale> Tbsales { get; set; } = new List<Tbsale>();
}
