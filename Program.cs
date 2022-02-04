using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Flex.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			// assembly
			var name = Assembly.GetExecutingAssembly().GetName();
			Logger.Info($"{name.Name} ver.{name.Version}");

			// args
			foreach (var arg in args) {
				Logger.Info($"{arg}");
			}

			// tasks
			var tasks = new List<Task>();
			{
				var task = Task.Run(() => {
					for (int i = 1; i <= 3; i++) {
						Logger.Trace($"Hello World!({i}/3)");
						Logger.Info($"Hello World!({i}/3)");
						Logger.Debug($"Hello World!({i}/3)");
						Logger.Error($"Hello World!({i}/3)");
						Logger.Warn($"Hello World!({i}/3)");
						Logger.Fatal($"Hello World!({i}/3)");
						Task.Yield();
						//Thread.Sleep(1000);
					}
				});

				tasks.Add(task);
			}

			Task.WaitAll(tasks.ToArray());

			Logger.Info($"Finish.");
		}
	}
}
