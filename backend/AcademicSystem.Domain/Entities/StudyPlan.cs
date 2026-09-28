using System;
using System.Collections.Generic;

namespace AcademicSystem.Domain.Entities;

public partial class StudyPlan
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string PlanCode { get; set; } = null!;

    public int? CareerDurationYears { get; set; }

    public string? AttendanceMode { get; set; }

    public int? TotalWorkloadHours { get; set; }

    public int StartYear { get; set; }

    public int? EndYear { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Prerequisite> Prerequisites { get; set; } = new List<Prerequisite>();

    public virtual ICollection<StudyPlanSubject> StudyPlanSubjects { get; set; } = new List<StudyPlanSubject>();
}
