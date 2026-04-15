var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();  // ✅ This serves CSS/JS files from wwwroot
app.UseRouting();

app.UseAuthorization();

app.MapControllers();  // ✅ Maps your controller actions

app.Run();