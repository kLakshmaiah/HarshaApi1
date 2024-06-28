using HarshaApi1.Data;
using HarshaApi1.Filters;
using HarshaApi1.Middleware;
using HarshaApi1.Models;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//serilog configuration.
builder.Host.UseSerilog((HostBuilderContext houseBuilderContext, IServiceProvider seriviceProvider, LoggerConfiguration loggerConfiguration) =>
{
    loggerConfiguration.ReadFrom.Configuration(houseBuilderContext.Configuration).ReadFrom.Services(seriviceProvider);
});


builder.WebHost.UseSentry(o =>
{
    o.Dsn = "https://85b2b30a132721d55fb68e11cdf40077@o4507508808679424.ingest.us.sentry.io/4507508813135872";
    o.Debug = true;
    o.TracesSampleRate = 1.0;
    o.ProfilesSampleRate = 1.0;
    o.Environment = "development";
    o.DiagnosticLevel = SentryLevel.Info;
});

//chaning Logger response and getting response and reques details

builder.Services.AddHttpLogging(o =>
{
    o.LoggingFields = HttpLoggingFields.RequestProperties | HttpLoggingFields.Response;
});
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(
    //options =>
    //{
    //    var logger = builder?.Services?.BuildServiceProvider().GetRequiredService<ILogger<MethodExpiredFilter>>();
    //    options.Filters.Add(new MethodExpiredFilter(4, logger));
    //}
    );
//autom mapper configuration
builder.Services.AddAutoMapper(typeof(MapperConfiguration));
builder.Services.AddTransient<MethodExpiredFilter2>();//using the service filter
builder.Services.AddControllers().AddXmlSerializerFormatters();//for receving the xml data
builder.Services.AddDbContext<HasrhaApiDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionStrings")));
builder.Services.AddIdentity<ApplicationUser, ApplicationRoles>().AddEntityFrameworkStores<HasrhaApiDbContext>()
    .AddDefaultTokenProviders()
    .AddUserStore<UserStore<ApplicationUser, ApplicationRoles, HasrhaApiDbContext, Guid>>()
    .AddRoleStore<RoleStore<ApplicationRoles, HasrhaApiDbContext, Guid>>();
var app = builder.Build();
app.UseSentryTracing();
app.UseMiddleware<ExceptionMiddleware>();
app.UseSerilogRequestLogging();//getting the response details using the serilog diagnostic
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
app.Run();
