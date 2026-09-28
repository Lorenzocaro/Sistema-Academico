using System;
using System.Collections.Generic;

namespace AcademicSystem.Domain.Entities;

public partial class TeacherSubject
{
    public int Id { get; set; }

    public int TeacherId { get; set; }

    public int SubjectId { get; set; }

    public string Section { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
