using System;
using System.Collections.Generic;

namespace AcademicSystem.Domain.Entities;

public partial class CourseRecord
{
    public int Id { get; set; }

    public int StudentSubjectId { get; set; }

    public decimal? AttendancePercentage { get; set; }

    public decimal? NumericGrade { get; set; }

    public string? LetterGrade { get; set; }

    public string? FinalStatus { get; set; }

    public string? Observations { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual StudentSubject StudentSubject { get; set; } = null!;
}
