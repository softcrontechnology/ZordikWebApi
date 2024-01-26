using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Setup.BL.User.address;
using Setup.BL.User.auth;
using Setup.BL.User.banner;
using Setup.BL.User.cart;
using Setup.BL.User.order;
using Setup.BL.User.product;
using Setup.BL.User.productFeatures;
using Setup.BL.User.review;
using Setup.BL.User.wishlist;
using Setup.ITF.User.address;
using Setup.ITF.User.auth;
using Setup.ITF.User.banner;
using Setup.ITF.User.cart;
using Setup.ITF.User.order;
using Setup.ITF.User.product;
using Setup.ITF.User.productFeatures;
using Setup.ITF.User.review;
using Setup.ITF.User.wishlist;
using System.Text;
using Microsoft.AspNetCore.HttpOverrides;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

#region Add Services
builder.Services.AddScoped<ILogin, Login>();
builder.Services.AddScoped<ICreateAccount, CreateAccount>();
builder.Services.AddScoped<IGetCart, GetCart>();
builder.Services.AddScoped<IAddCart, AddCart>();
builder.Services.AddScoped<IDeleteCart, DeleteCart>();
builder.Services.AddScoped<IUpdateCart, UpdateCart>();
builder.Services.AddScoped<IAddWishlist, AddWishlist>();
builder.Services.AddScoped<IDeleteWishlist, DeleteWishlist>();
builder.Services.AddScoped<IGetWishlist, GetWishlist>();
builder.Services.AddScoped<IProductByTag, ProductByTag>();
builder.Services.AddScoped<IAllProduct, AllProduct>();
builder.Services.AddScoped<IProductById, ProductById>();
builder.Services.AddScoped<IproductByCategory, ProductByCategory>();
builder.Services.AddScoped<IProductBySubcategory, ProductBySubCategory>();
builder.Services.AddScoped<ICategory, Category>();
builder.Services.AddScoped<ISubCategory, SubCategory>();
builder.Services.AddScoped<IColor, Color>();
builder.Services.AddScoped<ISize, Size>();
builder.Services.AddScoped<ITestimonial, Testimonial>();
builder.Services.AddScoped<IAddReview, AddReview>();
builder.Services.AddScoped<IGetReview, GetReview>();
builder.Services.AddScoped<ISelectOrder, SelectOrder>();
builder.Services.AddScoped<ICancelOrder, CancelOrder>();
builder.Services.AddScoped<IAddressAdd, AddressAdd>();
builder.Services.AddScoped<IAddressSelect, AddressSelect>();
builder.Services.AddScoped<IAddressUpdate, AddressUpdate>();
builder.Services.AddScoped<IAddressDelete, AddressDelete>();
builder.Services.AddScoped<IHomeBanner, HomeBanner>();
builder.Services.AddScoped<IContactForm, ContactForm>();

#endregion



// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});



builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddAuthorization();

// Add configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "jwtToken_Auth_API",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "Jwt",
        In = ParameterLocation.Header,
        Description = "Enter Jwt Token With Bearer Format like bearer[space] token"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new List<string>()
        }
    });
});


//builder.Services.Configure<ForwardedHeadersOptions>(options =>
//{
//    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
//});

var app = builder.Build();

//app.UseForwardedHeaders();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();


// Use CORS before authentication and authorization
app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

IConfiguration configuration = app.Configuration;

IWebHostEnvironment environment = app.Environment;

app.MapControllers();

app.Run();
