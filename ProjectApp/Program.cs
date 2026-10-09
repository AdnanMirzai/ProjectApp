using ProjectApp.Core;
using ProjectApp.Core.Interfaces;

var builder = WebApplication.CreateBuilder(args); //used to add new frameworks

// Add services to the container.
builder.Services.AddControllersWithViews();

//Här är kopplingen! Dependency Injection! När applikationen körs och kompilator hittar referens till interfacet ser den till att objektet som skapas är av typen Mock!!
builder.Services.AddScoped<IProjectService, MockProjectService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); //Must use https
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

//routing rules
app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();