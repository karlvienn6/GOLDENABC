using Goldenabc.Controllers;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// builder.Services.AddTransient<MySqlConnection>(_ => 
//     new MySqlConnection(builder.Configuration.GetConnectionString["Default"])
// );

// builder.Services.AddTransient<MySqlConnection>(_ =>
//     new MySqlConnection(builder.Configuration.GetConnectionString["Default"]));

builder.Services.AddDbContext<AppDbContext>();
// builder.Services.AddTransient<MySqlConnection>(_ => new MySqlConnection(builder.Configuration.GetConnectionString("Default")));

// using var connection = new MySqlConnection("Server=localhost;User ID=root;Password=karlrak321;Database=Golden;Port=3306;");



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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



// await connection.OpenAsync();

// using var command = new MySqlCommand("SELECT branchName FROM Branch;", connection);
// using var reader = await command.ExecuteReaderAsync();
// while(await reader.ReadAsync()){
//     var value = reader.GetValue(0);
//     Console.WriteLine(value);
// }


app.Run();
