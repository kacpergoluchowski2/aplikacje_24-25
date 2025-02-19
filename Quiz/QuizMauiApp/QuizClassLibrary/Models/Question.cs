using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuizClassLibrary.Models;

[Table("questions")]
public partial class Question
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("question")]
    [StringLength(500)]
    public string Question1 { get; set; } = null!;
}
