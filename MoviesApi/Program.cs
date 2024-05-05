
using AutoMapper;
using MoviesApi.Servies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connectionstring = builder.Configuration.GetConnectionString("Defaultconnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
  options.UseSqlServer(connectionstring));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddTransient<IGenresService, GenresService>();
builder.Services.AddTransient<IMoviesService, MoviesService>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddCors();
builder.Services.AddSwaggerGen(Options =>
{
    //Options.SwaggerDoc("V1", new OpenApiInfo
    //{
    //    Version = "V1",
    //    Title = "TestApi",
    //    Description = "My First Api",
    //    TermsOfService = new Uri("https://wwww.google.com"),
    //    Contact = new OpenApiContact
    //    {
    //        Name = "Abu Benyamin",
    //        Email = "5any43@gmail.com",
    //        Url = new Uri("https://wwww.google.com"),

    //    },
    //    License = new OpenApiLicense
    //    {
    //        Name = "License",
    //        Url = new Uri("https://wwww.google.com"),
    //    }
    //});
    Options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "authrozation",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "enter your JWT key",
    });
    Options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference =new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer",
                },
                Name="Bearer",
                In=ParameterLocation.Header,
            },
            new List<String>()
        }
    }
);
});
    var app = builder.Build();
    
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

app.UseHttpsRedirection();

app.UseCors(C=>C.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
    
app.UseAuthorization();

app.MapControllers();

app.Run();
