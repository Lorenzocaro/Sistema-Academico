using System;
using System.Collections.Generic;

namespace AcademicSystem.Domain.Entities;

public partial class AbsenceJustification
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int? AuditorUserId { get; set; }

    public string AbsenceType { get; set; } = null!;

    public string? FilePath { get; set; }

    public string? AdditionalNote { get; set; }

    public DateTime UploadedAt { get; set; }

    public string Status { get; set; } = null!;

    public virtual User? AuditorUser { get; set; }

    public virtual User User { get; set; } = null!;
}
