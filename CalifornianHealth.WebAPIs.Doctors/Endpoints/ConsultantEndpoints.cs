using CalifornianHealth.Core.Consultant.Contracts;

namespace CalifornianHealth.WebAPIs.Doctors.Endpoints;

public static class ConsultantEndpoints
{
    public static void MapConsultantEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("api/Consultant", GetAllConsultants);
    }

    public static async Task<IResult> GetAllConsultants(IConsultantManager manager)
    {
        var consultantList = manager.ListConsultants();

        if (consultantList == null)
            return Results.NotFound("No consultants found");

        return Results.Ok(consultantList);
    }
}
