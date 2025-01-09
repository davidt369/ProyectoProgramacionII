using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProyectoProgramacionII.Models;

[Table("tbcategories")]
[Index("Name", Name = "UQ__tbcatego__72E12F1B5EE99C22", IsUnique = true)]
[Index("UrlCategory", Name = "UQ__tbcatego__B1978B956DBF40AE", IsUnique = true)]
public partial class Tbcategory
{
    [Key]
    [Column("PK_category")]
    public int PkCategory { get; set; }

    [Column("name")]
    [StringLength(30)]
    public string Name { get; set; } = null!;

    [Column("urlCategory")]
    [StringLength(20)]
    public string UrlCategory { get; set; } = null!;

    [Column("description")]
    [StringLength(255)]
    public string? Description { get; set; }

    [Column("status")]
    public bool Status { get; set; }

    [Column("createdAt", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updatedAt", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [InverseProperty("FkCategoryNavigation")]
    public virtual ICollection<Tbproduct> Tbproducts { get; set; } = new List<Tbproduct>();
}
