using System;
using System.Collections.Generic;

namespace AcademicSystem.Entities.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string? TitlesJson { get; set; }

    public bool IsSubstituteDirector { get; set; }

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    public virtual ICollection<PartialGrade> PartialGrades { get; set; } = new List<PartialGrade>();

    public virtual ICollection<SubjectProgram> SubjectPrograms { get; set; } = new List<SubjectProgram>();

    public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();

    public virtual User User { get; set; } = null!;
}
