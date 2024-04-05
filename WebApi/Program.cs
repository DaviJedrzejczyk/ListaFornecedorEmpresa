using BusinessLogicalLayer.Implements;
using BusinessLogicalLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Implements;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ListDbContext>(opt =>
{
    opt.UseSqlServer("name=ConnectionStrings:ConnectionString");
});

builder.Services.AddTransient<IUnityOfWork, UnityOfWork>();
builder.Services.AddTransient<ICompanyDAL, CompanyDAL>();
builder.Services.AddTransient<ISupplierDAL, SupplierDAL>();
builder.Services.AddTransient<ISupplierService, SupplierService>();
builder.Services.AddTransient<ICompanyService, CompanyService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
