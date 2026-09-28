using System;
using System.Collections.Generic;

namespace AcademicSystem.Domain.Entities;

public partial class DocumentType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<RoleDocumentType> RoleDocumentTypes { get; set; } = new List<RoleDocumentType>();

    public virtual ICollection<UserDocument> UserDocuments { get; set; } = new List<UserDocument>();
}
