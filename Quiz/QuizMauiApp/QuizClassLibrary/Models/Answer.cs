using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuizClassLibrary.Models;

[Table("answers")]
public partial class Answer
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("question_id", TypeName = "int(11)")]
    public int QuestionId { get; set; }

    [Column("answer")]
    [StringLength(255)]
    public string Answer1 { get; set; } = null!;

    [Column("isCorrect")]
    public bool IsCorrect { get; set; }
}
