using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace ApiGateway {
    public class Startup {
        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                //options.AddPolicy(MyAllowSpecificOrigins,
                options.AddDefaultPolicy(builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
                //.AllowCredentials());
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
            services.AddAuthentication(options => {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddJwtBearer("Bearer", options => {
                    options.Authority = "https://localhost:5011";
                    options.Audience = "IS4API";
                });
                //.AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options => {
                //    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                //    options.Authority = "https://localhost:5011";
                //    options.ClientId = "myApp";
                //    options.ResponseType = "code";
                //    options.Scope.Add("openid");
                //    options.Scope.Add("profile");
                //    options.Scope.Add("fullaccess");
                //    options.SaveTokens = true;
                //});


            //var secret = "myprivatekey";
            //var encodedKey = Encoding.ASCII.GetBytes(secret);
            //services.AddAuthentication(option =>
            //    {
            //        option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //        option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //    })
            //    .AddJwtBearer(options =>
            //    {
            //        options.RequireHttpsMetadata = false;
            //        options.SaveToken = true;
            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            IssuerSigningKey = new SymmetricSecurityKey(encodedKey),
            //            ValidateIssuerSigningKey = true,
            //            ValidateIssuer = false,
            //            ValidateAudience = false
            //        };
            //    });
            services.AddOcelot();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints => endpoints.MapGet(
                    "/", async context 
                        => await context.Response.WriteAsync(
                            "Hello World!")));
            app.UseOcelot().Wait();
        }
    }
}