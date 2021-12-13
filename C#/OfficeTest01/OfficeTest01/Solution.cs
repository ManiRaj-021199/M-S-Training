using System;
using System.Collections.Generic;

namespace OfficeTest01
{
	class Solution
	{
		private List<int> lstDecimals;
		private Dictionary<int, char> dictDigitCounts;

		public Solution()
		{
			lstDecimals = new List<int> { 1, 10, 100, 1000 };
			dictDigitCounts = new Dictionary<int, char>();
		}


		public void TestSolution()
		{
			string strInput, strAnswer;

			strInput = GetUserInput();
			SeparateDecimalCounts(strInput);
			strAnswer = DecimalToRoman();

			Console.WriteLine($"Answer is : {strAnswer}");
		}


		public string GetUserInput()
		{
			int nNumber;

			Console.Write("Enter an Input Number (1 - 4999): ");

			if(Int32.TryParse(Console.ReadLine(), out nNumber))
			{
				if(nNumber >= 1 && nNumber <= 4999)
				{
					return nNumber.ToString();
				}
				else
				{
					Console.WriteLine("Enter a value in given range...");
					return GetUserInput();
				}
			}

			Console.WriteLine("Enter only Numerical Values...");
			return GetUserInput();
		}


		public void SeparateDecimalCounts(string strInput)
		{
			for(int i = strInput.Length - 1; i >= 0; i--)
			{
				dictDigitCounts.Add(lstDecimals[(strInput.Length - 1) - i], strInput[i]);
			}
		}


		public string DecimalToRoman()
		{
			string strValue = "", strAnswer = "";

			foreach(var keyValuePair in dictDigitCounts)
			{
				switch(keyValuePair.Key)
				{
					case 1:
						switch(keyValuePair.Value)
						{
							case '1':
								strValue += "I";
								break;
							case '2':
								strValue += "II";
								break;
							case '3':
								strValue += "III";
								break;
							case '4':
								strValue += "IV";
								break;
							case '5':
								strValue += "V";
								break;
							case '6':
								strValue += "VI";
								break;
							case '7':
								strValue += "VII";
								break;
							case '8':
								strValue += "VIII";
								break;
							case '9':
								strValue += "IX";
								break;
						}
						break;
					case 10:
						switch(keyValuePair.Value)
						{
							case '1':
								strValue += "X";
								break;
							case '2':
								strValue += "XX";
								break;
							case '3':
								strValue += "XXX";
								break;
							case '4':
								strValue += "XL";
								break;
							case '5':
								strValue += "L";
								break;
							case '6':
								strValue += "LX";
								break;
							case '7':
								strValue += "LXX";
								break;
							case '8':
								strValue += "LXXX";
								break;
							case '9':
								strValue += "XC";
								break;
						}
						break;
					case 100:
						switch(keyValuePair.Value)
						{
							case '1':
								strValue += "C";
								break;
							case '2':
								strValue += "CC";
								break;
							case '3':
								strValue += "CCC";
								break;
							case '4':
								strValue += "CD";
								break;
							case '5':
								strValue += "D";
								break;
							case '6':
								strValue += "DC";
								break;
							case '7':
								strValue += "DCC";
								break;
							case '8':
								strValue += "DCCC";
								break;
							case '9':
								strValue += "CM";
								break;
						}
						break;
					case 1000:
						switch(keyValuePair.Value)
						{
							case '1':
								strValue += "M";
								break;
							case '2':
								strValue += "MM";
								break;
							case '3':
								strValue += "MMM";
								break;
							case '4':
								strValue += "MMMM";
								break;
						}
						break;
				}

				strValue += strAnswer;
				strAnswer = strValue;
				strValue = "";
			}

			return strAnswer;
		}
	}
}
