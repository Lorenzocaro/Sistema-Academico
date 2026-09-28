using System;
using System.Collections.Generic;

namespace AcademicSystem.Domain.Entities;

public partial class StudentSubject
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int SubjectId { get; set; }

    public string Section { get; set; } = null!;

    public virtual CourseRecord? CourseRecord { get; set; }

    public virtual ICollection<PartialGrade> PartialGrades { get; set; } = new List<PartialGrade>();

    public virtual Student Student { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}
