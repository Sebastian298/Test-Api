using Test_Api.Attributes;
using Test_Api.Repositories;
using Test_Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().ConfigureApiBehaviorOptions(options => { options.InvalidModelStateResponseFactory = ModelStateValidator.ValidateModelState; }); ;
builder.Services.AddControllersWithViews().AddNewtonsoftJson();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped(typeof(ICategoryRepository<>), typeof(CategoryRepository<>));
builder.Services.AddTransient<IDapperService, DapperService>();
builder.Services.AddTransient<IBigqueryService, BigQueryService>();
builder.Services.AddScoped<IDalcecService, DalcecService>();
builder.Services.AddScoped<IDalcecRepository, DalcecRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
