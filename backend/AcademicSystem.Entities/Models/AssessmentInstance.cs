using System;
using System.Collections.Generic;

namespace AcademicSystem.Entities.Models;

public partial class AssessmentInstance
{
    public int Id { get; set; }

    public int StudyPlanSubjectId { get; set; }

    public string InstanceType { get; set; } = null!;

    public int Number { get; set; }

    public int? RetakeOfInstanceId { get; set; }

    public DateTime? InstanceDate { get; set; }

    public virtual ICollection<AssessmentInstance> InverseRetakeOfInstance { get; set; } = new List<AssessmentInstance>();

    public virtual ICollection<PartialGrade> PartialGrades { get; set; } = new List<PartialGrade>();

    public virtual AssessmentInstance? RetakeOfInstance { get; set; }

    public virtual StudyPlanSubject StudyPlanSubject { get; set; } = null!;
}
