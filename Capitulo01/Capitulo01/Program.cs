using Capitulo01.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("IESConnection");

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddEntityFrameworkNpgsql().AddDbContext<IESContext>(options => options.UseNpgsql(connectionString));

var app = builder.Build();

// Certifique-se de aplicar a inicialização do banco de dados
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<IESContext>();
        IESDbInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
        // Adicione aqui a lógica para tratar erros durante a inicialização
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Um erro ocorreu ao criar o banco de dados.");
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
