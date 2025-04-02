using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Hubs;

var builder = WebApplication.CreateBuilder(args);

// ✅ CORS AYARI EKLENİYOR
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueClient", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // Vue dev server adresi
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSignalR();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ✅ CORS AKTİF EDİLİYOR (Swagger'dan önce değil, middleware'lerden sonra!)
app.UseCors("AllowVueClient");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization(); // 👈 Eklemeyi unutma
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    ProductSeeder.Seed(db);
}
app.MapHub<ChatHub>("/ChatHub");
{ }

app.Run();
