namespace CalifornianHealth.WebAPIs.Doctors.Routes
{
    public static class ApiRoutes
    {
        public static class Consultant
        {
            private const string RelativePath = "consultant";
            public const string Tag = "Consultant";
            public const string GetTags = RelativePath;
            public const string GetSingleTag = RelativePath + "/{:id:int}";
        }
    }
}
