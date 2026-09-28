using System;
using System.Collections.Generic;

namespace AcademicSystem.Entities.Models;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<RoleDocumentType> RoleDocumentTypes { get; set; } = new List<RoleDocumentType>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
