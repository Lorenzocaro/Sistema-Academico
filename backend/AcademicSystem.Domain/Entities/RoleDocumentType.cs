using System;
using System.Collections.Generic;

namespace AcademicSystem.Domain.Entities;

public partial class RoleDocumentType
{
    public int Id { get; set; }

    public int RoleId { get; set; }

    public int DocumentTypeId { get; set; }

    public bool IsMandatory { get; set; }

    public bool IsAnnual { get; set; }

    public virtual DocumentType DocumentType { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
