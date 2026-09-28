using System;
using System.Collections.Generic;

namespace AcademicSystem.Entities.Models;

public partial class ProgramContent
{
    public int Id { get; set; }

    public int ProgramId { get; set; }

    public int UnitNumber { get; set; }

    public string UnitTitle { get; set; } = null!;

    public string? Content { get; set; }

    public string? MandatoryBibliography { get; set; }

    public string? SupplementaryBibliography { get; set; }

    public virtual SubjectProgram Program { get; set; } = null!;
}
