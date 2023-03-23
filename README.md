# team-be-2

## Docker Build Image
docker build -t dockerdemo .


## Docker Run
docker run -p 8088:80 --name myapp dockerdemo

## Db Migration
1. Install dotnet ef dengan command: (informasi lebih lanjut: https://learn.microsoft.com/en-us/ef/core/cli/dotnet)
dotnet tool install --global dotnet-ef
2. Perika apakah dotnet sudah diinstall dengan command:
dotnet ef
3. Periksa koneksi ke database pada appsettings.json
4. Jika dotnet sudah ada, dan koneksi ke database aman, jalankan migrasi dengan command:
dotnet ef migrations add InitMigration
5. Pada folder migration, buka file migration yang baru terbuat
6. Pada Up, jika perubahannya sudah sesuai (kosong jika ada perubahan), jalankan update database dengan command:
dotnet ef database update