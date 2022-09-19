
using API.Services;
using Application.Pets;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add IdentityUserForAuth
builder.Services.AddIdentityCore<AppUser>(opt =>
{
  opt.Password.RequireNonAlphanumeric = false;
})
.AddEntityFrameworkStores<DataContext>()
.AddSignInManager<SignInManager<AppUser>>();

builder.Services.AddAuthentication();
builder.Services.AddScoped<TokenService>();
// var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"]));

// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//   .AddJwtBearer(opt =>
//   {
//       opt.TokenValidationParameters = new TokenValidationParameters
//       {
//           ValidateIssuerSigningKey = true,
//           IssuerSigningKey = key,
//           ValidateIssuer = false,
//           ValidateAudience = false
//       };
//   });
// builder.Services.AddAuthorization(opt => 
// {
//     opt.AddPolicy("IsActivityHost", policy =>
//     {
//         policy.Requirements.Add(new IsHostRequirement());
//     });
// });
// builder.Services.AddTransient<IAuthorizationHandler, IsHostRequirementHandler>();
// builder.Services.AddScoped<TokenService>();

builder.Services.AddDbContext<DataContext>(opt => {
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddMediatR(typeof(List.Handler).Assembly);

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


using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{

    var context = services.GetRequiredService<DataContext>();
    var userManager = services.GetRequiredService<UserManager<AppUser>>();
    await context.Database.MigrateAsync();
    await Seed.SeedData(context, userManager);
    
}
catch(Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "Il y à eu une erreur pendant la migration");
}

app.Run();
