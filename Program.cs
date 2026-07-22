using Backend.Repositories;
using Backend.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IItemRepository, InMemoryItemRepository>();

builder.Services.AddScoped<IItemService, ItemService>();

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFlutterDev", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors("AllowFlutterDev");
app.UseAuthorization();
app.MapControllers();

app.MapGet("/", () => "Backend API is running. ลองเปิด /api/items ดูข้อมูลตัวอย่าง");

app.Run();
