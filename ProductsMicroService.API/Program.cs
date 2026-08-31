using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Add Controllers
builder.Services.AddControllers();
//AddDbContext
builder.Services.AddDbContext<AppDbContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));
var app = builder.Build();



app.Run();
