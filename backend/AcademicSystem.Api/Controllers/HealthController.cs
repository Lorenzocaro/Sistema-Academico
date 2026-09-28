using AcademicSystem.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcademicSystem.Api.Controllers;

/// <summary>
/// Quick check that the API is running and can reach the database.
/// GET /api/health
/// </summary>
[ApiController]
[Route("api/health")]
public class HealthController(AcademicSystemContext context) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        if (!await context.Database.CanConnectAsync(cancellationToken))
        {
            return StatusCode(StatusCodes.Status503ServiceUnavailable,
                new { status = "error", database = "unreachable" });
        }

        var roles = await context.Roles.CountAsync(cancellationToken);

        return Ok(new
        {
            status = "ok",
            database = context.Database.GetDbConnection().Database,
            roles,
        });
    }
}
