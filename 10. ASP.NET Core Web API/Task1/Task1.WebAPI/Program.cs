using Microsoft.EntityFrameworkCore;
using Task1.BusinessLogic.Services;
using Task1.DataAccess;
using Task1.DataAccess.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext> (
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("Default")
    ),
    ServiceLifetime.Transient);

builder.Services.AddScoped(typeof(IGenericRepository<> ), typeof(GenericRepository<>));
builder.Services.AddScoped<IArticleService, ArticleService>();

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

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();
//app.UseMvc();

app.Run();