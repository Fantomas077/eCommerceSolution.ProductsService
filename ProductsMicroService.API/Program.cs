using BusinessLogicLayer.Mappers;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Services.IServices;
using BusinessLogicLayer.Validators;
using DataAccessLayer.Data;
using DataAccessLayer.IRepositories;
using DataAccessLayer.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ProductsMicroService.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

//add automapper
builder.Services.AddAutoMapper(

    cfg => { }, typeof(ProductsMappingProfile).Assembly

);
//Add Controllers
builder.Services.AddControllers();
//AddDbContext
builder.Services.AddDbContext<AppDbContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));
//
builder.Services.AddTransient<IProductRepository, ProductsRepository>();
builder.Services.AddTransient<IProductService, ProductService>();

//AddFluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<ProductUpdateRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<ProductAddRequestValidator>();
var app = builder.Build();

//Add Middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();
//routing
app.UseRouting();


//Controller routes
app.MapControllers();


app.Run();
