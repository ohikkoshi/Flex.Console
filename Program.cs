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

			// main loop
			var task = Task.Run(() => {
				for (int i = 1; i <= 3; i++) {
					Logger.Info($"Hello World!({i}/3)");
					Task.Yield();
					//Thread.Sleep(1000);
				}
			});

			task.Wait();

			Logger.Info($"Finish.");
		}
	}
}
