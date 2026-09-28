using System;
using System.Collections.Generic;

namespace AcademicSystem.Domain.Entities;

public partial class Exam
{
    public int Id { get; set; }

    public int SubjectId { get; set; }

    public int TeacherId { get; set; }

    public DateTime ExamDate { get; set; }

    public string ExamType { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
