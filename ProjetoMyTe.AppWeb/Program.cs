using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjetoMyTe.AppWeb.Models.Common;
using ProjetoMyTe.AppWeb.Models.Contexts;
using ProjetoMyTe.AppWeb.Models.Startup;
using ProjetoMyTe.AppWeb.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();
ConfigurationManager config = builder.Configuration;

// Add services to the container.
builder.Services.AddDbContext<MyTeContext>(options => options.UseSqlServer(config.GetConnectionString("MyTeConnection")));
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(config.GetConnectionString("IdentityConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
// regras para senha
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequiredUniqueChars = 3;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;

});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Autenticacao/Login";
    options.LogoutPath = "/Autenticacao/Logout";
    options.AccessDeniedPath = "/Autenticacao/AccessDenied";
});

// Habilitando o serviço cargos service para a injeção de dependência
builder.Services.AddScoped<CargosService>();
builder.Services.AddScoped<ColaboradoresService>();
builder.Services.AddScoped<WbssService>();
builder.Services.AddScoped<RegistroHorasService>();


builder.Services.AddControllersWithViews();

var app = builder.Build();



var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<MyTeContext>();

// sincronizando com o banco de dados
DbInitializer.Initialize(context);

// criando os roles 
Utils.CreateRoles(services).Wait();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Autenticacao}/{action=Login}/{id?}");

app.Run();
