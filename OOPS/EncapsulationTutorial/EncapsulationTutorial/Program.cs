using System;

namespace EncapsulationTutorial
{
	class Program
	{
		static void Main(string[] args)
		{
			DoubleKey doubleKeyWithoutArgs = new DoubleKey();
			DoubleKey doubleKeyWithArgs = new DoubleKey("Argument - 1", "Argument - 2");

			doubleKeyWithoutArgs.SetKey2("Key 2 was Changed...");
			Console.WriteLine($"Double Key Without Args: Key1 => {doubleKeyWithoutArgs.GetKey1()}, Key2 => {doubleKeyWithoutArgs.GetKey2()}");

			doubleKeyWithArgs.SetKey1("Argument 1 was Changed...");
			Console.WriteLine($"Double Key Without Args: Key1 => {doubleKeyWithArgs.GetKey1()}, Key2 => {doubleKeyWithArgs.GetKey2()}");
		}
	}
}
