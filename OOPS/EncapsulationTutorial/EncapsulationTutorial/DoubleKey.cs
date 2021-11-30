namespace EncapsulationTutorial
{
	class DoubleKey
	{
		private string strKey1, strKey2;

		public DoubleKey()
		{
			strKey1 = "Key 1";
			strKey2 = "Key 2";
		}

		public DoubleKey(string key1, string key2)
		{
			strKey1 = key1;
			strKey2 = key2;
		}

		public string GetKey1()
		{
			return strKey1;
		}

		public void SetKey1(string key1)
		{
			strKey1 = key1;
		}

		public string GetKey2() 
		{
			return strKey2;
		}

		public void SetKey2(string key2)
		{
			strKey2 = key2;
		}
	}
}
