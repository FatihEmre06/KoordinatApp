using Microsoft.EntityFrameworkCore;
using MapApplication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<PointDbContext>(options =>
	options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register IUnitOfWork and its implementation
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Swagger middleware
    app.UseSwaggerUI(); // Swagger UI middleware
}

app.UseHttpsRedirection(); // HTTPS y�nlendirme
app.UseCors("AllowAll"); // CORS politikas�
app.UseAuthorization(); // Yetkilendirme

app.MapControllers(); // API endpoint'lerini tan�mlar ve y�nlendirir

app.Run(); // Uygulamay� �al��t�r�r