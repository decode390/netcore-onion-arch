using Application;
using Persistence;
using Shared;
using WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var conn = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceInfrastructure(builder.Configuration);

builder.Services.AddSharedInfrastructure();
builder.Services.AddApiVersioningExtension();
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    // options.AddPolicy(name: "corsApp",
    //                   policy  =>
    //                   {
    //                       policy.WithOrigins("http://example.com",
    //                                           "http://www.contoso.com");
    //                   });
    options.AddPolicy(name: "corsApp",
                      policy  =>
                      {
                          policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
                      });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("corsApp");

app.UseErrorHandlingMiddleware();

app.MapControllers();

app.Run();
