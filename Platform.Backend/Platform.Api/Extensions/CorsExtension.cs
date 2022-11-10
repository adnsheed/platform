namespace Platform.Api.Extensions
{
    public static class CorsExtension
    {
        public static void SetupCors(this IServiceCollection service)
        {
            service.AddCors(options =>
            {
                options.AddPolicy(name: "AllowOrigin",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });
        }
    }
}
