using PokemonFight.Data.EF;
using PokemonFight.Servicios;
using PokemonFight.Web.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<PokemonFightContext>();
builder.Services.AddScoped<IPokemonServicio, PokemonServicio>();
builder.Services.AddRazorPages();
builder.Services.AddSignalR();
builder.Services.AddSession();


var app = builder.Build();

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

app.UseSession();

app.UseEndpoints(endpoints =>{
    endpoints.MapRazorPages();
    endpoints.MapHub<PokemonHub>("/pokemonHub");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Pokemon}/{action=elegirPokemon}/{id?}");

app.Run();
