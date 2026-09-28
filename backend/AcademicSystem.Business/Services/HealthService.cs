using AcademicSystem.Data.Context;
using AcademicSystem.Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace AcademicSystem.Business.Services;

/// <summary>
/// Checks that the database is reachable.
/// Example of the pattern every team follows: Controller (Api) -> Service (Business) -> Context (Data) -> Models (Entities).
/// </summary>
public class HealthService(AcademicSystemContext context) : IHealthService
{
    public async Task<HealthResponseDto> CheckAsync(CancellationToken cancellationToken = default)
    {
        if (!await context.Database.CanConnectAsync(cancellationToken))
        {
            return new HealthResponseDto("error", "unreachable", null);
        }

        var roles = await context.Roles.CountAsync(cancellationToken);

        return new HealthResponseDto("ok", context.Database.GetDbConnection().Database, roles);
    }
}
