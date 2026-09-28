using AcademicSystem.Entities.DTOs;

namespace AcademicSystem.Business.Services;

public interface IHealthService
{
    Task<HealthResponseDto> CheckAsync(CancellationToken cancellationToken = default);
}
