using API.Extensions;
using API.Middleware;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(opt =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    opt.Filters.Add(new AuthorizeFilter(policy));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAppServiceExtensions(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();
if (app.Environment.IsDevelopment())
{
    // app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
// app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    var context = services.GetRequiredService<AppDbContext>();
    var userManager = services.GetRequiredService<UserManager<AppUser>>();
    await context.Database.MigrateAsync();
    await Seed.SeedData(userManager, context);
    await Seed.SeedAgama(context);
    await Seed.SeedBahasa(context);
    await Seed.SeedGender(context);
    await Seed.SeedGolongan(context);
    await Seed.SeedJabatan(context);
    await Seed.SeedZone(context);
    await Seed.SeedOrgType(context);
    await Seed.SeedOrg(context);
    await Seed.SeedLocationType(context);
    await Seed.SeedLocation(context);
    await Seed.SeedNegara(context);
    await Seed.SeedPendidikan(context);
    await Seed.SeedPendidikan1(context);
    await Seed.SeedPendidikan2(context);
    await Seed.SeedPendidikan3(context);
    await Seed.SeedPerkawinan(context);
    await Seed.SeedSuku(context);
    await Seed.SeedPegawai(context);

    await Seed2.SeedRegion(context);
    // await Seed2.SeedKabKota( context);


    // await Seed.SeedData(context);

}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "Error during migration on program.cs");
}

app.Run();
// }
