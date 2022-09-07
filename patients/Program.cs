var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<IDoctor,SDoctor>();
builder.Services.AddScoped<IUser,SUser>();
builder.Services.AddScoped<IPatient,SPatient>();
builder.Services.AddScoped<IRequestForm,SRequestForm>();
builder.Services.AddScoped<IOffice,SOffice>();
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
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

    app.MapControllerRoute(
    name: "Question",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.Run();
