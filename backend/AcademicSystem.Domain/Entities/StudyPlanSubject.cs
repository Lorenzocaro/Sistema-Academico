using System;
using System.Collections.Generic;

namespace AcademicSystem.Domain.Entities;

public partial class StudyPlanSubject
{
    public int Id { get; set; }

    public int StudyPlanId { get; set; }

    public int SubjectId { get; set; }

    public int CourseYear { get; set; }

    public byte? Term { get; set; }

    public virtual ICollection<AssessmentInstance> AssessmentInstances { get; set; } = new List<AssessmentInstance>();

    public virtual StudyPlan StudyPlan { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}
