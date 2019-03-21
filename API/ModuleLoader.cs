using Bot.DAI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace API
{
	public static class ModuleLoader
	{
		public static IEnumerable<IModule> GetModules()
		{
			var dir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "plugins");
			if (!Directory.Exists(dir))
				Directory.CreateDirectory(dir);

			var plugins = new List<IModule>();
			foreach (var pluginPath in Directory.GetFiles(dir,"*.dll"))
			{
				var pluginAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(Path.Combine(dir, pluginPath));
				try
				{
					foreach (var ti in pluginAssembly.DefinedTypes)
						if (ti.ImplementedInterfaces.Contains(typeof(IModule)))
						{
							var plugin = pluginAssembly.CreateInstance(ti.FullName) as IModule;
							plugins.Add(plugin);
							WarningConsole.WriteLine($"Module ({plugin}) is loaded");
						}
				}
				catch (Exception ex)
				{
					ErrorConsole.WriteLine($"Module loading error: {ex.Message}");
				}
			}
			return plugins;
		}
	}
}
