using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProyectoProgramacionII.Models;

[Table("tbproducts")]
[Index("UrlProduct", Name = "UQ__tbproduc__678E314A091B0C9A", IsUnique = true)]
public partial class Tbproduct
{
    [Key]
    [Column("PK_product")]
    public int PkProduct { get; set; }

    [Column("FK_category")]
    public int FkCategory { get; set; }

    [Column("name")]
    [StringLength(80)]
    public string Name { get; set; } = null!;

    [Column("urlImage")]
    [StringLength(255)]
    public string UrlImage { get; set; } = null!;

    [Column("urlProduct")]
    [StringLength(80)]
    public string UrlProduct { get; set; } = null!;

    [Column("regularPrice", TypeName = "decimal(10, 2)")]
    public decimal RegularPrice { get; set; }

    [Column("offerPrice", TypeName = "decimal(10, 2)")]
    public decimal? OfferPrice { get; set; }

    [Column("stock")]
    public int Stock { get; set; }

    [Column("description")]
    [StringLength(255)]
    public string? Description { get; set; }

    [Column("profileImage")]
    [StringLength(255)]
    public string? ProfileImage { get; set; }

    [Column("status")]
    public bool? Status { get; set; }

    [Column("createdAt", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updatedAt", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("FkCategory")]
    [InverseProperty("Tbproducts")]
    public virtual Tbcategory FkCategoryNavigation { get; set; } = null!;

    [InverseProperty("FkProductNavigation")]
    public virtual ICollection<Tbsaledetail> Tbsaledetails { get; set; } = new List<Tbsaledetail>();
}
