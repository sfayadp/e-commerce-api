using e_commerce_api.Application.Contracts;
using e_commerce_api.Application.Estados;
using e_commerce_api.Domain.Contracts;
using e_commerce_api.Domain.Estados;
using e_commerce_api.Models;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200",
                                              "https://localhost:4200/");
                      });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection 
#region Dependency Injection

builder.Services.AddDbContext<ecommerceContext>();
builder.Services.AddScoped<IEstadosApplicationService, EstadosApplicationService>();
builder.Services.AddScoped<IEstadosDomainService, EstadosDomainService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

#endregion Dependency Injection

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
