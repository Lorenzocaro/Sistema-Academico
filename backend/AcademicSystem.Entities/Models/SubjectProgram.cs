using System;
using System.Collections.Generic;

namespace AcademicSystem.Entities.Models;

public partial class SubjectProgram
{
    public int Id { get; set; }

    public int SubjectId { get; set; }

    public int TeacherId { get; set; }

    public int AcademicYear { get; set; }

    public string? SpecificObjectives { get; set; }

    public string? GeneralObjectives { get; set; }

    public string? WeeklyHours { get; set; }

    public string? TermHours { get; set; }

    public string? Assessment { get; set; }

    public string? AssessmentCriteria { get; set; }

    public string? TeachingStrategies { get; set; }

    public string? RemoteSupportStrategies { get; set; }

    public string? RegularConditions { get; set; }

    public string? PromotionConditions { get; set; }

    public string? FreeStudentConditions { get; set; }

    public string? VirtualExams { get; set; }

    public string? CurricularFormat { get; set; }

    public string? SubjectCondition { get; set; }

    public virtual ICollection<ProgramContent> ProgramContents { get; set; } = new List<ProgramContent>();

    public virtual Subject Subject { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
