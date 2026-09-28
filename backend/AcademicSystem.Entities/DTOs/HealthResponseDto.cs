namespace AcademicSystem.Entities.DTOs;

/// <summary>
/// What GET /api/health returns.
/// DTOs are the shapes the API sends and receives. Models are the database tables.
/// </summary>
public record HealthResponseDto(string Status, string Database, int? Roles);
