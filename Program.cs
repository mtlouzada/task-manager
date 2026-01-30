using Microsoft.EntityFrameworkCore;
using Teste.Estagio.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("DataSource=Animes.db;Cache=Shared"));


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(); 

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}"
);


app.Run();
