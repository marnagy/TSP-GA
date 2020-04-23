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
			double randNum = rand.NextDouble();
			double rightSide = bestSolution * randNum;
			double leftSide = fitness(from[index]);
			while (leftSide < rightSide )
			{
				index = rand.Next(from.Count);
				randNum = rand.NextDouble();
				rightSide = bestSolution * randNum;
				leftSide = fitness(from[index]);
			}
			return from[index];
		}
	}
}
