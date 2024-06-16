using HarshaApi1.Data;
using HarshaApi1.Filters;
using HarshaApi1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(
    options =>
    {
        var logger = builder?.Services?.BuildServiceProvider().GetRequiredService<ILogger<MethodExpiredFilter>>();
        options.Filters.Add(new MethodExpiredFilter(4, logger));
    });
builder.Services.AddTransient<MethodExpiredFilter2>();//using the service filter
builder.Services.AddControllers().AddXmlSerializerFormatters();//for receving the xml data
builder.Services.AddDbContext<HasrhaApiDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionStrings")));
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>().AddEntityFrameworkStores<HasrhaApiDbContext>()
    .AddDefaultTokenProviders()
    .AddUserStore<UserStore<ApplicationUser, ApplicationRole, HasrhaApiDbContext, Guid>>()
    .AddRoleStore<RoleStore<ApplicationRole, HasrhaApiDbContext, Guid>>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
