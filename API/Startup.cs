using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Bot.DAI.Defaults;
using Bot.DAI;
using System.Reflection;
using System.Runtime.Loader;
using System.IO;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			var vkApiString = Configuration.GetValue<string>("VkApiString");
			var token = Environment.GetEnvironmentVariable("ACCESS_TOKEN");
			var version = Environment.GetEnvironmentVariable("VERSION");
			services.AddSingleton<IMessageSender>(new DefaultMessageSender(token, version, vkApiString));
			
			var plugins = ModuleLoader.GetModules();
			if (plugins.Count() == 0)
				ErrorConsole.WriteLine($"Did not find modules");
			else
				services.AddSingleton(plugins);

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
