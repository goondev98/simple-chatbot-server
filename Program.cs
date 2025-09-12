using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Step 1: Add CORS services
builder.Services.AddCors(options =>
{
    var urls = Environment.GetEnvironmentVariable("ASPNETCORE_URLS");

    // If not set, try to get from launchSettings.json via configuration
    if (string.IsNullOrEmpty(urls))
    {
        urls = builder.Configuration["applicationUrl"];
    }

    // Optional: fallback to a hardcoded default
    urls ??= "http://localhost:5173";


    options.AddPolicy("AllowFrontend",
        policy => policy
            .WithOrigins(urls)
            .AllowAnyHeader()
            .AllowAnyMethod());
});

// DI
builder.Services.AddScoped<IConversationRepository, ConversationRepository>();
builder.Services.AddScoped<IConversationService, ConversationService>();
// End DI

// ✅ Register controller support
builder.Services.AddControllers();

// Register DbContext with PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Step 2: Use CORS middleware
app.UseCors("AllowFrontend");

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
