using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
	struct Range : IEnumerable<int>
	{
		private static readonly Random rand = new Random();
		int low,high;
		public Range(int a, int b)
		{
			if (a < b)
			{
				low = a;
				high = b;
			}
			else
			{
				low = b;
				high = a;
			}
		}
		public static Range GetRangeIn(int low, int high)
		{
			int a = rand.Next(low, high);
			int b = rand.Next(low, high);
			while ( b == a)
			{
				b = rand.Next(low, high);
			}
			return new Range(a,b);
		}

		public IEnumerator<int> GetEnumerator()
		{
			for (int i = low; i < high; i++)
			{
				yield return i;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
		public bool Contains(int i)
		{
			return i >= low && i < high;
		}
	}
}
