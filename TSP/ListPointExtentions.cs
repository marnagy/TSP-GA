using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
	static class ListPointExtentions
	{
		public static Point[] Accept_Reject(this IReadOnlyList<Point[]> from, double bestSolution, ref Random rand, Func<Point[], double> fitness)
		{
			int index = rand.Next(from.Count);
			while (fitness(from[index]) < bestSolution * rand.NextDouble() )
			{
				index = rand.Next(from.Count);
			}
			return from[index];
		}
	}
}
