using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

using Newtonsoft.Json;

using System.IO.Compression;

using Visa_Application_API.BusinessObjects;
using Visa_Application_API.DataAccessLayer.Helpers;
using Visa_Application_API.DataAccessLayer.Interface;
using Visa_Application_API.DataAccessLayer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// JSON Response compression
builder.Services.Configure<GzipCompressionProviderOptions>(options =>
{
	options.Level = CompressionLevel.Optimal;
});
builder.Services.AddResponseCompression(options =>
{
	options.EnableForHttps = true; options.Providers.Add<GzipCompressionProvider>();
});

builder.Services.AddCors();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers()
	.AddNewtonsoftJson(x =>
	{
		x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
		x.SerializerSettings.ContractResolver = new DefaultContractResolver();
	});

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<VisaApiDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("VisaAPIConnection")));

// configure DI for application services 
builder.Services.AddScoped<VisaService>();
builder.Services.AddScoped<IApplicantRepository, ApplicantRepository>();
builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddScoped<IVisaTypeRepository,VisaTypeRepository>();
builder.Services.AddSingleton<Utility>();

var app = builder.Build();
app.UseResponseCompression();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// global cors policy
app.UseCors(x => x
	.AllowAnyOrigin()
	.AllowAnyMethod()
	.AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
