// Check if a number is Prime or Not

using System;

public class Test
{
	public static void Main()
	{
	    
	    int nInput;
		
        try
        {
            nInput = Convert.ToInt32(Console.ReadLine());
        }
        catch(Exception e) 
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("Give a Proper Number.");
            return;
        }

		bool bPrime = true;
		
		if(nInput <= 1) 
		{
		    bPrime = false;
		}
		else 
		{
		    for(int i = 2; i < nInput; i++) 
		    {
		        if(nInput % i == 0) 
		        {
		            bPrime = false;
		            break;
		        }
		    }
		}
		
		if(bPrime) Console.WriteLine("Prime Number");
		else Console.WriteLine("Not Prime");
	}
}
