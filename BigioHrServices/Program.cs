using Microsoft.EntityFrameworkCore;
using BigioHrServices.Db;
using BigioHrServices.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IEmployeeService), typeof(EmployeeServices));
builder.Services.AddScoped(typeof(INotificationService), typeof(NotificationServices));
builder.Services.AddScoped(typeof(IDelegationMatrixService), typeof(DelegationMatrixServices));
builder.Services.AddScoped(typeof(ILeaveApplicationService), typeof(LeaveApplicationServices));
// builder.Services.AddScoped(typeof(IPinSignatureService), typeof(PinSignatureService));
builder.Services.AddScoped(typeof(IPositionService), typeof(PositionServices));
// builder.Services.AddScoped(typeof(IAuditLogService), typeof(AuditLogService));

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
