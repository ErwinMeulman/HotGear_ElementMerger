using System.Collections;
using System.Collections.Generic;

namespace Facet.Combinatorics
{
	public class SmallPrimeUtility
	{
		private static List<int> myPrimes;

		public static IList<int> PrimeTable
		{
			get
			{
				return SmallPrimeUtility.myPrimes;
			}
		}

		private SmallPrimeUtility()
		{
		}

		public static List<int> Factor(int i)
		{
			int num = 0;
			int num2 = SmallPrimeUtility.PrimeTable[num];
			List<int> list = new List<int>();
			while (i > 1)
			{
				if (i % num2 == 0)
				{
					list.Add(num2);
					i /= num2;
				}
				else
				{
					num++;
					num2 = SmallPrimeUtility.PrimeTable[num];
				}
			}
			return list;
		}

		public static List<int> MultiplyPrimeFactors(IList<int> lhs, IList<int> rhs)
		{
			List<int> list = new List<int>();
			foreach (int lh in lhs)
			{
				list.Add(lh);
			}
			foreach (int rh in rhs)
			{
				list.Add(rh);
			}
			list.Sort();
			return list;
		}

		public static List<int> DividePrimeFactors(IList<int> numerator, IList<int> denominator)
		{
			List<int> list = new List<int>();
			foreach (int item in numerator)
			{
				list.Add(item);
			}
			foreach (int item2 in denominator)
			{
				list.Remove(item2);
			}
			return list;
		}

		public static long EvaluatePrimeFactors(IList<int> value)
		{
			long num = 1L;
			foreach (int item in value)
			{
				num *= item;
			}
			return num;
		}

		static SmallPrimeUtility()
		{
			SmallPrimeUtility.myPrimes = new List<int>();
			SmallPrimeUtility.CalculatePrimes();
		}

		private static void CalculatePrimes()
		{
			BitArray bitArray = new BitArray(65536, true);
			for (int i = 2; i <= 256; i++)
			{
				if (bitArray[i])
				{
					for (int j = 2 * i; j < 65536; j += i)
					{
						bitArray[j] = false;
					}
				}
			}
			SmallPrimeUtility.myPrimes = new List<int>();
			for (int k = 2; k < 65536; k++)
			{
				if (bitArray[k])
				{
					SmallPrimeUtility.myPrimes.Add(k);
				}
			}
		}
	}
}
