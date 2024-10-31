using PlanItUp.API.Middlewares;
using PlanItUp.Configuration;
using PlanItUp.Data.Implementations;
using PlanItUp.Data.Interfaces;
using PlanItUp.Services.Implementations;
using PlanItUp.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);


//******************* start dependecies and options *********************

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//****************** Config ***************************
builder.Services.Configure<SQLServerConfig>(builder.Configuration.GetSection("DBTestConnection"));
//****************** DAOS  ****************************
builder.Services.AddScoped<IAuthDAO, AuthDAO>();
builder.Services.AddScoped<IRoleDAO, RoleDAO>();
builder.Services.AddScoped<IClientDAO, ClientDAO>();
//****************** Services *************************
builder.Services.AddScoped<IHasherService, BcryptHasher>();
builder.Services.AddScoped<IAuthService, AuthService>();

//******** end depencies and options **************************************

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GlobalErrorHandlingMiddleware>();

app.MapControllers();

app.Run();
