using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeTest01;

namespace UnitTestForOfficeTest1
{
	[TestClass]
	public class UnitTestSolution
	{
		[TestMethod]
		public void GetUserInput_NumericInput_IsNumeric()
		{
			// Arrange
			

			// Act


			// Assert
		}

		[TestMethod]
		public void GetUserInput_LessThan1OrGreaterThan4999_ShowError()
		{
			// Arrange


			// Act


			// Assert
		}


		[TestMethod]
		public void GetUserInput_NonNumericInput_ShowError()
		{
			// Arrange


			// Act


			// Assert
		}
	}
}
