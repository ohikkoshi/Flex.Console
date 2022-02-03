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
			System.Console.WriteLine($"{name.Name} ver.{name.Version}");

			// args
			foreach (var arg in args) {
				System.Console.WriteLine($"{arg}");
			}

			// main loop
			var task = Task.Run(() => {
				for (int i = 1; i <= 3; i++) {
					System.Console.WriteLine($"Hello World!({i}/3)");
					Task.Yield();
					//Thread.Sleep(1000);
				}
			});

			task.Wait();

			System.Console.WriteLine($"Finish.");
		}
	}
}
