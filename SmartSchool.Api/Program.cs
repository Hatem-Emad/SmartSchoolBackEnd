
////using JWT.Context;
//using JWT.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SmartSchool.Bl.Helpers;
using SmartSchool.BL.Interface;
using SmartSchool.BL.Repository;
using SmartSchool.BL.Services;
using SmartSchool.DAL;
using SmartSchool.DAL.Context;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace SmartSchool.Api
{
    
    public class Program
    {
        //16-05-2023 Ayman
     
        public static void Main(string[] args)
        {

            string txt = "hi";
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.Configure<JWTC>(builder.Configuration.GetSection("JWT"));

            //service of using jwt Authentication
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = false;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = builder.Configuration["JWT:Issuer"],
                    ValidAudience = builder.Configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
                };
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //services of using conection string
            builder.Services.AddDbContext<SmartSchoolContext>(opt =>
            opt.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));

            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
               .AddEntityFrameworkStores<SmartSchoolContext>();

            builder.Services.AddScoped<IRequestRepo, RequestRepo>();
            builder.Services.AddScoped<IGradeYearRepo, GradeYearRepo>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IClassRoomRepo, ClassRoomRepo>();
            builder.Services.AddScoped<IScheduleRepo, ScheduleRepo>();
            builder.Services.AddScoped<ISessionRepo, SessionRepo>();
            builder.Services.AddScoped<ISubjectRepo, SubjectRepo>();
            builder.Services.AddScoped<IParentRepo, ParentRepo>();
            builder.Services.AddScoped<IStudentRepo, StudentRepo>();
            builder.Services.AddScoped<IStudentAttendanceRepo, StudentAttendanceRepo>();
            builder.Services.AddScoped<ITeacherAttendanceRepo, TeacherAttendanceRepo>();

            //builder.Services.AddScoped<IComplaintRepo, ComplaintRepo>();
            //builder.Services.AddScoped<IRequestRepo, RequestRepo>();

            builder.Services.AddScoped<ITeacherRepo, TeacherRepo>();

            builder.Services.AddCors(o =>
            {
                o.AddPolicy(txt, builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });

            var app = builder.Build();

            app.UseCors(txt);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseStaticFiles();

            app.MapControllers();

            app.Run();
        }
    }
}