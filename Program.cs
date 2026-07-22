using Backend.Repositories;
using Backend.Services;

var builder = WebApplication.CreateBuilder(args);

// ==== ลงทะเบียน service ตาม Clean Architecture ====
// Infrastructure layer: ตอนนี้ใช้ in-memory ก่อน (Singleton เพื่อให้ข้อมูลไม่หายระหว่าง request)
builder.Services.AddSingleton<IItemRepository, InMemoryItemRepository>();
// Application layer
builder.Services.AddScoped<IItemService, ItemService>();

builder.Services.AddControllers();

// หมายเหตุ: เวอร์ชันนี้ตัด Swagger ออกชั่วคราว เพื่อไม่ต้องติดตั้ง
// package Swashbuckle.AspNetCore เพิ่ม (เผื่อเครื่องมีปัญหาเรื่อง permission
// ตอนติดตั้ง package ใหม่) ทดสอบ API ผ่าน backend.http หรือเปิด URL
// ตรงในเบราว์เซอร์/Postman แทนได้ ถ้าติดตั้ง Swashbuckle.AspNetCore สำเร็จแล้ว
// ในอนาคต ค่อยเปิดใช้ Swagger กลับมาได้โดยเพิ่ม 3 บรรทัดนี้กลับเข้าไป:
//   builder.Services.AddEndpointsApiExplorer();
//   builder.Services.AddSwaggerGen();
//   app.UseSwagger(); app.UseSwaggerUI();  (ในส่วน Development ด้านล่าง)

// อนุญาตให้ Flutter (คนละ origin/port) เรียก API นี้ได้ระหว่างพัฒนา
// หมายเหตุ: ตอน deploy จริงควรจำกัด origin ให้เจาะจงแทน AllowAnyOrigin
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

// endpoint ทดสอบง่ายๆ เปิดผ่านเบราว์เซอร์ได้เลยเพื่อเช็คว่า server รันอยู่
app.MapGet("/", () => "Backend API is running. ลองเปิด /api/items ดูข้อมูลตัวอย่าง");

app.Run();
