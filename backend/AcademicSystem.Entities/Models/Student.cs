using System;
using System.Collections.Generic;

namespace AcademicSystem.Entities.Models;

public partial class Student
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Dni { get; set; } = null!;

    public string RecordNumber { get; set; } = null!;

    public virtual ICollection<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();

    public virtual User User { get; set; } = null!;
}
