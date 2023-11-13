using System.Reflection;
using System.Text;
using apiweb;
using apiweb.interfaces;
using apiweb.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddNpgsql<PubContext>(builder.Configuration.GetConnectionString("TaskDb")) ;


// JWToken
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options=>{
    options.TokenValidationParameters = new TokenValidationParameters(){
        ValidateIssuer= false,
        ValidateAudience= false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["ConfigurationJwt:Key"]?? string.Empty)
        )
    };
});


builder.Services.AddControllers().ConfigureApiBehaviorOptions(options=>{
    options.InvalidModelStateResponseFactory = actionContext => {
    return new BadRequestObjectResult(new {
        success = false,
        message = "Bad request",
        errors = actionContext.ModelState.Values.SelectMany(x => x.Errors)
            .Select(x => x.ErrorMessage)
    });
};
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen((x =>
            {
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        x.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    }));

//Dependency injection

builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<ITaskService,TaskService>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

//app.UseWelcomePage();

app.useTimeMiddleware();

app.MapControllers();

app.Run();