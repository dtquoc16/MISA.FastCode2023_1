using Microsoft.Extensions.DependencyInjection;
using MISA.QLTS.DEMO.Web04.DTQUOC.BL.AssetBL;
using MISA.QLTS.DEMO.Web04.DTQUOC.BL.AssetTypeBL;
using MISA.QLTS.DEMO.Web04.DTQUOC.BL.DepartmentBL;
using MISA.QLTS.DEMO.Web04.DTQUOC.DL.AssetDL;
using MISA.QLTS.DEMO.Web04.DTQUOC.DL.DepartmentDL;
using MISA.QLTS.DEMO.Web04.DTQUOC.DL;
using MISA.QLTS.DEMO.Web04.DTQUOC.DL.AssetTypeDL;
using MISA.QLTS.DEMO.Web04.DTQUOC.BL;
using Microsoft.AspNetCore.Mvc;
using MISA.QLTS.DEMO.Web04.DTQUOC.DL.DiscussDL;
using MISA.QLTS.DEMO.Web04.DTQUOC.BL.DiscussBL;
using MISA.QLTS.DEMO.Web04.DTQUOC.BL.AnswerBL;
using MISA.QLTS.DEMO.Web04.DTQUOC.DL.AnswerDL;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
                      });
});

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<AssetBL>();
builder.Services.AddTransient<IAssetBL, AssetBL>();
builder.Services.AddTransient<AssetDL>();
builder.Services.AddTransient<IAssetDL, AssetDL>();

builder.Services.AddTransient<DepartmentBL>();
builder.Services.AddTransient<IDepartmentBL, DepartmentBL>();
builder.Services.AddTransient<DepartmentDL>();
builder.Services.AddTransient<IDepartmentDL, DepartmentDL>();

builder.Services.AddTransient<AssetTypeBL>();
builder.Services.AddTransient<IAssetTypeBL, AssetTypeBL>();

builder.Services.AddTransient<AssetTypeDL>();
builder.Services.AddTransient<IAssetTypeDL, AssetTypeDL>();

builder.Services.AddTransient<DiscussBL>();
builder.Services.AddTransient<IDiscussBL, DiscussBL>();

builder.Services.AddTransient<DiscussDL>();
builder.Services.AddTransient<IDiscussDL, DiscussDL>();

builder.Services.AddTransient<AnswerBL>();
builder.Services.AddTransient<IAnswerBL, AnswerBL>();

builder.Services.AddTransient<AnswerDL>();
builder.Services.AddTransient<IAnswerDL, AnswerDL>();
//
builder.Services.AddScoped(typeof(IBaseBL<>), typeof(BaseBL<>));
builder.Services.AddScoped(typeof(IBaseDL<>), typeof(BaseDL<>));




DataBaseContext.ConnectionString = builder.Configuration.GetConnectionString("MySql");
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
/*builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);*/

/*builder.Services.AddControllers().ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);*/

var app = builder.Build();



app.UseCors(MyAllowSpecificOrigins);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
