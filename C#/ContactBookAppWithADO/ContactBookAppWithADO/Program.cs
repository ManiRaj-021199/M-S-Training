using System;

namespace ContactBookAppWithADO
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Contack Book");
			new ContactBook().ViewMenu();
		}
	}
}
