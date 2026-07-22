# วิธีนำ backend ชุดนี้ไปใช้กับโปรเจคเดิม (แบบง่าย ไม่ต้องแยกหลาย .csproj)

โครงสร้างนี้จัดเป็น "Clean Architecture แบบย่อ" คือแยกด้วยโฟลเดอร์ภายใน
โปรเจคเดียวกัน (ไม่ได้แยกเป็นหลาย project/solution) เพื่อให้ setup ง่าย
ไม่ต้องยุ่งกับ .sln เพิ่ม แต่ยังคงหลักการแยกหน้าที่ชัดเจนตาม layer:

```
Controllers/   -> API layer (รับ request, ไม่มี logic)
Services/      -> Application layer (business logic, validation)
Repositories/  -> Infrastructure layer (วิธีเก็บข้อมูลจริง)
Models/        -> Domain layer (โครงสร้างข้อมูล)
```

## วิธีติดตั้ง

1. คัดลอกโฟลเดอร์ `Models/`, `Repositories/`, `Services/`, `Controllers/`
   ไปวางในโฟลเดอร์ `backend/` ของคุณ (ตำแหน่งเดียวกับ `Program.cs` เดิม)

2. เปิดไฟล์ `Program.cs` เดิมของคุณ แล้ว**แทนที่เนื้อหาทั้งหมด**ด้วยไฟล์
   `Program.cs` ที่แนบมา (หรือคัดลอกเฉพาะส่วนลงทะเบียน service/CORS
   เข้าไปรวมกับของเดิมก็ได้ ถ้ามีโค้ดอื่นที่ไม่อยากลบ)

3. รันโปรเจค:
   ```
   dotnet run
   ```

4. เปิดดู Swagger เพื่อทดสอบ endpoint:
   ```
   https://localhost:5001/swagger
   ```
   (พอร์ตจริงดูได้จาก terminal ตอนรัน หรือไฟล์ `Properties/launchSettings.json`)

## Endpoint ที่มีให้

| Method | Path              | คำอธิบาย                     |
|--------|-------------------|-------------------------------|
| GET    | /api/items        | ดึงข้อมูลทั้งหมด              |
| GET    | /api/items/{id}   | ดึงข้อมูล 1 รายการตาม id      |
| POST   | /api/items        | สร้างรายการใหม่               |

รูปแบบ JSON ที่ใช้ (ตรงกับ `Item` model ฝั่ง Flutter):
```json
{
  "id": 1,
  "name": "จัดซื้ออุปกรณ์สำนักงาน",
  "description": "สั่งซื้อกระดาษและหมึกพิมพ์",
  "category": "General"
}
```

## ข้อมูลตัวอย่าง
ตอนนี้เก็บข้อมูลแบบ **in-memory** (เก็บใน List ธรรมดา) มีข้อมูลตัวอย่างมาให้ 3 รายการ
เพื่อให้ทดสอบกับหน้า Flutter ได้ทันที **ข้อมูลจะหายเมื่อ restart โปรแกรม**
ถ้าต้องการเก็บถาวรจริง ค่อยเปลี่ยนเฉพาะไฟล์ `Repositories/InMemoryItemRepository.cs`
ไปต่อ Entity Framework Core + ฐานข้อมูลจริงภายหลัง โดยไม่กระทบ Controller/Service เลย

## เชื่อมกับ Flutter
แก้ `baseUrl` ในไฟล์ `lib/config/app_config.dart` ของ Flutter ให้ตรงกับ URL
ของ backend (ดูจาก terminal ตอนรัน `dotnet run`) เช่น
`https://localhost:5001/api` — ตอนนี้เข้ากันได้พอดีกับ `ApiService`
ที่เขียนไว้ให้ก่อนหน้านี้แล้ว ไม่ต้องแก้อะไรฝั่ง Flutter เพิ่ม
