using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PeopleDatabaseClassLibrary.Models;

[Table("addresses")]
public partial class Address
{
    [StringLength(100)]
    public string Street { get; set; } = null!;

    [StringLength(100)]
    public string HouseNumber { get; set; } = null!;

    [StringLength(100)]
    public string Country { get; set; } = null!;

    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [InverseProperty("Address")]
    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
