using ApplicationCore.Contract.Repositories;
using ApplicationCore.Contract.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<HRAntraTrainningDbContext>(option => {
    option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    //this need for migrations
    option.UseSqlServer(builder.Configuration.GetConnectionString("HRAntraTrainningDb")); // this line of code help Program.cs locate the connection string in appsetting.json
});
// dependencies injection for repository
builder.Services.AddScoped<ICandidatesRepository, CandidatesRepository>();
builder.Services.AddScoped<IEmployeeRequirementTypeRepository, EmployeeRequirementTypeRepository>();
builder.Services.AddScoped<IEmployeeTypeRepository, EmployeeTypeRepository>();
builder.Services.AddScoped<IJobCategoryRepository, JobCategoryRepository>();
builder.Services.AddScoped<IJobRequirementRepository, JobRequirementRepository>();
builder.Services.AddScoped<IStatusRepository, StatusRepository>();
builder.Services.AddScoped<ISubmissionRepository, SubmissionRepository>();

// dependencies injection for service
builder.Services.AddScoped<ICandidatesService, CandidatesService>();
builder.Services.AddScoped<IEmployeeTypeService, EmployeeTypeService>();
builder.Services.AddScoped<IJobRequirementService, JobRequirementService>();
builder.Services.AddScoped<IStatusService, StatusService>();
builder.Services.AddScoped<ISubmissionService, SubmissionService>();

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
