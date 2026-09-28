using System;
using System.Collections.Generic;

namespace AcademicSystem.Domain.Entities;

public partial class PartialGrade
{
    public int Id { get; set; }

    public int StudentSubjectId { get; set; }

    public int AssessmentInstanceId { get; set; }

    public decimal Grade { get; set; }

    public DateTime RecordedAt { get; set; }

    public int RecordedByTeacherId { get; set; }

    public virtual AssessmentInstance AssessmentInstance { get; set; } = null!;

    public virtual Teacher RecordedByTeacher { get; set; } = null!;

    public virtual StudentSubject StudentSubject { get; set; } = null!;
}
