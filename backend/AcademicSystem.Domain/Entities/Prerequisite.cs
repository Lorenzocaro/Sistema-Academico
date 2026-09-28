using System;
using System.Collections.Generic;

namespace AcademicSystem.Domain.Entities;

public partial class Prerequisite
{
    public int Id { get; set; }

    public int StudyPlanId { get; set; }

    public int SubjectId { get; set; }

    public int PrerequisiteSubjectId { get; set; }

    public virtual Subject PrerequisiteSubject { get; set; } = null!;

    public virtual StudyPlan StudyPlan { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}
