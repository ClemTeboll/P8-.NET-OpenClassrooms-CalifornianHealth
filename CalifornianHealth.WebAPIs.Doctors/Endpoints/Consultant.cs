using CalifornianHealth.WebAPIs.Doctors.Routes;

namespace CalifornianHealth.WebAPIs.Doctors.Endpoints
{
    public static class Consultant
    {
        public static IEndpointRouteBuilder MapConsultant(this IEndpointRouteBuilder app)
        {
            app.MapGet(ApiRoutes.Consultant.GetTags, ConsultantManager.ListConsultant);
        }
    }
}
