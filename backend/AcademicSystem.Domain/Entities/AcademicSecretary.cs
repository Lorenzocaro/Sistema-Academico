using System;
using System.Collections.Generic;

namespace AcademicSystem.Domain.Entities;

public partial class AcademicSecretary
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string? TitlesJson { get; set; }

    public virtual User User { get; set; } = null!;
}
