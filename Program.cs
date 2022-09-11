using CustomersApi.Repositories;
using CustomersApi.useCases;
using Microsoft.EntityFrameworkCore;

//CORS
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(routing => routing.LowercaseUrls = true);

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          /*policy.WithOrigins("http://example.com",
                                              "http://www.contoso.com");*/
                          policy.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost").AllowAnyHeader().AllowAnyMethod();
                      });
});

builder.Services.AddDbContext<CustomerDatabaseContext>(mysqlBuilder =>
{
    mysqlBuilder.UseMySQL("Server=localhost;Port=3306; Database=microservicios_schema; Uid=root;pwd=password123");//Esto es una mala practica

    //mysqlBuilder.UseMySQL(builder.Configuration.GetConnectionString("connection1"));

});

//Se añade el caso de uso al contenedor de dependencias
builder.Services.AddScoped<IUpdateCustomerUseCase, UpdateCustomerUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//CORS
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();