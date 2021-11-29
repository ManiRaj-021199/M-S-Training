using System;

namespace CSharpEncryptionDecryption
{
	class EncodingDecoding
	{
		public void ViewMenu()
		{
			int nUserOption;

			Console.WriteLine("\nWhich Operation you want to Perform:");
			Console.WriteLine("1. Encoding");
			Console.WriteLine("2. Decoding");
			Console.WriteLine("3. Exit");

			Console.Write("\nEnter Your Choice: ");
			int.TryParse(Console.ReadLine(), out nUserOption);

			switch(nUserOption)
			{
				case 1:
					EncodeResult();
					break;
				case 2:
					DecodeResult();
					break;
				case 3:
					return;
				default:
					Console.WriteLine("\nYour Choice is not Valid.Try again...");
					break;
			}

			ViewMenu();
		}

		public string Approach1()
		{
			string strUserString = Console.ReadLine();
			string strOutputString = "";

			foreach(int i in strUserString)
			{
				if(i >= 65 && i <= 90)
				{
					if(i >= 65 && i <= 77)
					{
						strOutputString += ((char) (90 - (i - 65))).ToString();
					}
					else
					{
						strOutputString += ((char) (65 + (90 - i))).ToString();
					}
				}
				else if(i >= 97 && i <= 122)
				{
					if(i >= 97 && i <= 109)
					{
						strOutputString += ((char) (122 - (i - 97))).ToString();
					}
					else
					{
						strOutputString += ((char) (97 + (122 - i))).ToString();
					}
				}
				else
				{
					strOutputString += ((char) i).ToString();
				}
			}

			return strOutputString;
		}

		public string Approach2()
		{
			string strLowerCases = "abcdefghijklmnopqrstuvwxyz";
			string strUpperCases = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

			string strUserInput = Console.ReadLine();
			string strOutputString = "";

			foreach(char i in strUserInput)
			{
				int nLowerCaseIndex = strLowerCases.IndexOf(i);
				int nUpperCaseIndex = strUpperCases.IndexOf(i);

				if(nLowerCaseIndex != -1)
				{
					strOutputString += (strLowerCases[25 - nLowerCaseIndex]).ToString();
				}
				else if(nUpperCaseIndex != -1)
				{
					strOutputString += (strUpperCases[25 - nUpperCaseIndex]).ToString();
				}
				else
				{
					strOutputString += i.ToString();
				}
			}

			return strOutputString;
		}

		public void EncodeResult()
		{
			Console.Write("Enter a String you want to Encode: ");
			string strEncodedString = Approach1();

			Console.WriteLine($"Encoded String: {strEncodedString}");
		}

		public void DecodeResult()
		{
			Console.Write("Enter a String you want to Decode: ");
			string strDecodedString = Approach2();

			Console.WriteLine($"Decoded String: {strDecodedString}");
		}
	}
}
