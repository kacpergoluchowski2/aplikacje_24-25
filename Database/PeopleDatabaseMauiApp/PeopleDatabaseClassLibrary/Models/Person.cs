using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PeopleDatabaseClassLibrary.Models;

[Table("person")]
[Index("AddressId", Name = "fk_address")]
public partial class Person
{
    [Key]
    [Column("ID", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(20)]
    public string Name { get; set; } = null!;

    [Column("surname")]
    [StringLength(20)]
    public string Surname { get; set; } = null!;

    [Column("age", TypeName = "int(11)")]
    public int Age { get; set; }

    [Column("address_id", TypeName = "int(11)")]
    public int AddressId { get; set; }

    [ForeignKey("AddressId")]
    [InverseProperty("People")]
    public virtual Address Address { get; set; } = null!;
}
