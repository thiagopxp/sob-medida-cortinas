using SobMedidaCortinas.Web.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
    });

// Register application services
builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddScoped<IEmailService, SendGridEmailService>();
builder.Services.AddHttpClient<IReCaptchaService, ReCaptchaService>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Configure routes matching the old MVC 5 application
app.MapControllerRoute(
    name: "cortinas",
    pattern: "Cortinas/{id?}",
    defaults: new { controller = "Cortinas", action = "Index" });

app.MapControllerRoute(
    name: "persianas",
    pattern: "Persianas/{id?}",
    defaults: new { controller = "Persianas", action = "Index" });

app.MapControllerRoute(
    name: "ideias",
    pattern: "Ideias/{id?}",
    defaults: new { controller = "Ideias", action = "Index" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
