using System;
using System.Collections.Generic;

namespace AcademicSystem.Entities.Models;

public partial class UserDocument
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int DocumentTypeId { get; set; }

    public string FilePath { get; set; } = null!;

    public DateTime UploadedAt { get; set; }

    public DateTime? ExpiresAt { get; set; }

    public string Status { get; set; } = null!;

    public bool SubmittedPhysically { get; set; }

    public string? Comment { get; set; }

    public virtual DocumentType DocumentType { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
