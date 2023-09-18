using AgreementManagement.Validation.CustomErrorConfiguration;
using ams.DataAccess.Database;
using ams.DataAccess.Repository.Agreement;
using ams.DataAccess.Repository.VendorInfo;
using ams.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json;

namespace AgreementManagement.DependencyInjection
{
    public class DependencyServices
    {
        public static void Inject(IServiceCollection services, IConfiguration config)
        {
            //Add Mapper
            services.AddAutoMapper(typeof(Program));

            //Fluent Validation
            services.AddControllers()
                    .ConfigureApiBehaviorOptions(options =>
                    {
                        options.InvalidModelStateResponseFactory = context =>
                        {
                            var errors = context.ModelState.Values
                                .SelectMany(v => v.Errors)
                                .Select(e => JsonSerializer.Deserialize<Error>(e.ErrorMessage));

                            var errorResponse = new HttpResponseModel(data: errors, success: false, message: "validation failed.");
                            return new BadRequestObjectResult(errorResponse);
                        };
                    });
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            var connectionString = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<AmsDbContext>(x =>
            {
                x.UseSqlServer(connectionString);
            });

            //Fluent Validation Custom Error Model Interceptor
            services.AddTransient<IValidatorInterceptor, CustomErrorModelInterceptor>();

            //Repository
            services.AddTransient<IVendorInfoRepository, VendorInfoRepository>();
            services.AddTransient<IAgreementRepository, AgreementRepository>();
            //Business
        }
    }
}
