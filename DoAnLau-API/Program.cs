using DoAnLau_API.Data;
using DoAnLau_API.Interface;
using DoAnLau_API.Responsitory;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// responsitory
builder.Services.AddScoped<IAccountResponsitory, AccountResponsitory>();
builder.Services.AddScoped<IMenuResponsitory, MenuResponsitory>();
builder.Services.AddScoped<IMenuCategoryResponsitory, MenuCategoryResponsitory>();
builder.Services.AddScoped<IPageResponsitory, PageResponsitory>();
builder.Services.AddScoped<IAddresssRepository, AddressRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<IDistrictRepository, DistrictRepository>();
builder.Services.AddScoped<IWardRepository, WardRepository>();
builder.Services.AddScoped<IPromotionRepository, PromotionRepository>();
builder.Services.AddScoped<ISYS_INDEX, SysIndexRepository>();
builder.Services.AddScoped<IBranch, BranchRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

// khởi tạo service Indentity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
    options =>
   options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 -._@+!*'(),"
    )
    .AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();

builder.Services.AddDbContext<DataContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddAuthentication(options =>
{
    // khi yêu cầu xác thực thành công 
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    // khi có yêu cầu xác thực 
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

/*
    // khi có những yêu cầu không đòi hỏi xác thực 
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;*/
}).AddJwtBearer(options =>
{
  /*  options.SaveToken = true;
    options.RequireHttpsMetadata = false;*/
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});

builder.Services.Configure<IdentityOptions>(options =>
{
    options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier;
});
builder.Services.AddHttpContextAccessor();
// cấp quyền cho API 
builder.Services.AddCors(options => 
{
    options.AddPolicy("AllowAngularOrigins",
    builder =>
    {
        builder.WithOrigins(
                            "http://localhost:4200"
                            )
                            .AllowAnyHeader()
                            .AllowAnyMethod();
    });
});



var app = builder.Build();
//app.UseCors("AllowAngularOrigins");
app.UseCors("AllowAngularOrigins");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
