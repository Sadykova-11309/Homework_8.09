using FluentValidation;
using FluentValidation.AspNetCore;
using Homework_8._09.DataBase;
using Homework_8._09.DataBase.Repository;
using Homework_8._09.DataBase.Repository.Extensions;
using Homework_8._09.Service.Services;
using Homework_8._09.Service.Validators;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Homework_8._09
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
			builder.Services.AddDbContext<AppDbContext>(options =>
				options.UseNpgsql(builder.Configuration.GetConnectionString("DbContext")));
			builder.Services.AddScoped<UserService>();
			builder.Services.AddScoped<IUserRepository, UserRepository>();
			builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
			builder.Services.AddMapster();
			builder.Services.AddValidatorsFromAssemblyContaining<UserService>();
			builder.Services.AddFluentValidationAutoValidation();
			builder.Services.AddValidatorsFromAssemblyContaining<CreateRequestValidator>();
			builder.Services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
			builder.Services.AddValidatorsFromAssemblyContaining<UpdateRequestValidator>();

			var app = builder.Build();

			//// Configure the HTTP request pipeline.
			//if (app.Environment.IsDevelopment())
			//{
			//    app.UseSwagger();
			//    app.UseSwaggerUI();
			//}

			app.UseSwagger();
			app.UseSwaggerUI();

			app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
