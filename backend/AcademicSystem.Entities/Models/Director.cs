using System;
using System.Collections.Generic;

namespace AcademicSystem.Entities.Models;

public partial class Director
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string? TitlesJson { get; set; }

    public virtual User User { get; set; } = null!;
}
