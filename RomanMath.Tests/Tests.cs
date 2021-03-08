using NUnit.Framework;
using RomanMath.Impl;
using System;

namespace RomanMath.Tests
{
	public class Tests
	{
		[Test]
		public void Expression_Result_Test()
		{
			try
			{
				var result = Service.Evaluate("D+L*V+X*VIII+V*XXXIV-M");
				Assert.AreEqual(0, result);
			}
			catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
		}

		[Test]
		public void Expression_With_Digit_Test()
		{
			try
			{
				Service.Evaluate("XXI-XX*2");
				Assert.Fail();
			}
			catch (Exception e)
			{
				System.Console.WriteLine(e.Message);
			}
		}

		[Test]
		public void Misplaced_Operations_Test()
		{
			try
			{
				Service.Evaluate("*XXI-XX*2");
				Assert.Fail();
			}
			catch(Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
		}

		[Test]
		public void Unresolved_Symbols_Test()
		{
			try
			{
				Service.Evaluate("S*XXI-XX*2");
				Assert.Fail();
			}
			catch (Exception e)
			{
				System.Console.WriteLine(e.Message);
			}
		}
	}
}