namespace UserProductMinimal
{
    public static class ExtensionsMethods
    {
        public static void SetCorsConfig(this IServiceCollection services)
        {
            var MyAllowSpecificOrigins = "PolicyBase";
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder
                                        .AllowAnyOrigin()
                                        .WithHeaders("Accept, Origin, Content-type, X-CSRF-Token, X-Requested-With, api_key, Authorization, origem")
                                        .WithMethods("POST", "GET", "PUT", "DELETE", "OPTIONS");
                                  });
            });
        }
    }
}
