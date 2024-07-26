
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Business.Services;
using WebData;
using Business.Mappers;
using Business.Validators;

namespace Business
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options => {
                options.MapType<DateOnly>(() => new OpenApiSchema
                {
                    Type = "string",
                    Format = "date"
                });
            });
            builder.Services.AddDbContext<AppDbContext>(x =>
            {
                x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddTransient<IPatientService, PatientService>();
            builder.Services.AddScoped<IPatientMapper, PatientMapper>();
            builder.Services.AddTransient<IPatientValidator, PatientValidator>();

            builder.Services.AddTransient<IPostService, PostService>();
            builder.Services.AddScoped<IPostMapper, PostMapper>();
            builder.Services.AddTransient<IPostValidator, PostValidator>();

            builder.Services.AddTransient<IICDService, ICDService>();
            builder.Services.AddScoped<IICDMapper, ICDMapper>();
            builder.Services.AddTransient<IICDValidator, ICDValidator>();

            builder.Services.AddTransient<IDoctorService, DoctorService>();
            builder.Services.AddScoped<IDoctorMapper, DoctorMapper>();
            builder.Services.AddTransient<IDoctorValidator, DoctorValidator>();

            builder.Services.AddTransient<IReasonService, ReasonService>();
            builder.Services.AddScoped<IReasonMapper, ReasonMapper>();
            builder.Services.AddTransient<IReasonValidator, ReasonValidator>();

            builder.Services.AddTransient<IDispRegService, DispRegService>();
            builder.Services.AddScoped<IDispRegMapper, DispRegMapper>();
            builder.Services.AddTransient<IDispRegValidator, DispRegValidator>();

            builder.Services.AddTransient<IStatisticsService, StatisticsService>(); 

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
        }
    }
}
