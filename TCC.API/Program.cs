var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString)) throw new InvalidOperationException("Connection string not found.");

builder.Services.AddDbContext<TccDbContext>(
    options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IEncryptionService, EncryptionService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidatePersonalKeyFilter>();
});

// Add API Versioning
builder.Services.AddApiVersioning(
    config =>
    {
        config.DefaultApiVersion = new(1, 0);
        config.AssumeDefaultVersionWhenUnspecified = true;
        config.ReportApiVersions = true;
        config.ApiVersionReader = new UrlSegmentApiVersionReader();
    });

// Add Swagger
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc(
            "v1",
            new()
                { Title = "Your API", Version = "v1" });
    });

// Add Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
       .AddJwtBearer(
            options =>
            {
                options.TokenValidationParameters = ValidationParameters(builder.Configuration);

                options.Events = new()
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Headers[AuthHeader];
                        return Task.CompletedTask;
                    },
                };
            });

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<TccDbContext>();
    context.Database.Migrate();
    foreach (var role in TccDbContext.DefaultRoles
                                     .Where(role => context.Roles.FirstOrDefault(r => r.Id == role.Id) == null))
        context.Roles.Add(role);
    context.SaveChanges();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API v1"));
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();