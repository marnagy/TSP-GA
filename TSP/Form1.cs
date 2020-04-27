using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSP
{
	public partial class Form1 : Form
	{

		Bitmap bmp;
		Graphics g;
		Brush bgBrush = new SolidBrush(Color.Black);
		Brush pointBrush = new SolidBrush(Color.White);
		Brush stringBrush = new SolidBrush(Color.Red);
		Pen linePen = new Pen(Color.Blue, 2f);
		//Color lineColor = Color.Blue;
		Pen bestLinePen = new Pen(Color.Green);
		//Color bestColor = Color.Green;
		int genCounter = 0;
		int maxGen;
		Point first;
		Point[] points;
		int pointWidth = 5;
		Rectangle[] pointRect;
		Random rand;
		int pointMargin = 10;
		bool train = false;
		Point[][] population;
		int populationLengthMultiplier = 10;
		int sleepAmount = 100;
		int showTimerIndex = 0;
		List<Point[]> nextPopulation;
		double[] fitnessVals;
		int numberOfPoints;

		Func<Point[], double> fitness;
		//double sum = 0;
		int populationSize = 50;
		double bestSolution;
		double crossoverFactor = 4/5D;
		double mutationFactor = 1/5D;
		int addedCrossovers = 0;
		int addedMutations = 0;
		int addedRandoms = 0;
		double mutationProb = 0.02;
		double badSolutionProb = 0.001;
		int crossoverNumber;
		int bestConst = 5;
		int newRandNum = 5;
		int maxGenMultiplier = 100;

		public Form1()
		{
			InitializeComponent();
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
			g = Graphics.FromImage(bmp);
			pictureBox1.Image = bmp;

			ClearPictureBox();
			pictureBox1.Refresh();
			generationsCounter.Text = "Generation: " + genCounter;
			UpdateMaxGenerations();

			rand = new Random();
		}
		private void ClearPictureBox()
		{
			g.FillRectangle(bgBrush, 0,0,pictureBox1.Width, pictureBox1.Height);
		}

		private void loadButton_Click(object sender, EventArgs e)
		{
			if ( int.TryParse(textBox1.Text, out numberOfPoints) && numberOfPoints > 1)
			{
				first = NewRandPoint();
				points = new Point[numberOfPoints - 1];

				for (int i = 0; i < points.Length; i++)
				{
					points[i] = NewRandPoint();
				}
			}
			MakePointRects();
			
			setFitnessFunction();

			ClearPictureBox();
			ShowPoints();
			pictureBox1.Refresh();
		}

		private void setFitnessFunction()
		{
			Func<Point, Point, double> dist = (p1,p2) =>
			{
				return Math.Sqrt((p1.X - p2.X)*(p1.X - p2.X) + (p1.Y - p2.Y)*(p1.Y - p2.Y));
				//return Math.Abs(p1.X - p2.X) + Math.Abs(p1.Y - p2.Y);
			};
			fitness = (arr) =>
			{
				double res = 0;

				res += dist(first, arr[0]);
				for (int i = 0; i < arr.Length - 1; i++)
				{
					res += dist(arr[i], arr[i+1]);
				}
				res += dist(first, arr[arr.Length - 1]);

				//made for better solution has higher fitness
				res = 1/res;

				if (res < bestSolution)
				{
					bestSolution = res;
				}
				return res;
			};
		}

		private void MakePointRects()
		{
			pointRect = new Rectangle[points.Length + 1];
			pointRect[points.Length] = new Rectangle(first.X - pointWidth, first.Y - pointWidth, pointWidth * 2, pointWidth * 2);
			for (int i = 0; i < points.Length; i++)
			{
				pointRect[i] = new Rectangle(points[i].X - pointWidth, points[i].Y - pointWidth, pointWidth * 2, pointWidth * 2);
			}
		}

		private void ShowPoints()
		{
			for (int i = 0; i < pointRect.Length; i++)
			{
				g.FillEllipse(pointBrush, pointRect[i]);
			}
		}

		private Point NewRandPoint()
		{
			return new Point(rand.Next(pointMargin, pictureBox1.Width - pointMargin), rand.Next(pointMargin, pictureBox1.Height - pointMargin));
		}

		private void button1_Click(object sender, EventArgs e)
		{
			genCounter = 0;
			crossoverNumber = (points.Length + 1) / 2;
			bestSolution = double.MaxValue;
			train = true;
			population = new Point[populationSize][];
			rand = new Random( rand.Next(int.MinValue, int.MaxValue) );

			for (int i = 0; i < population.Length; i++)
			{
				population[i] = GetNewChromosomeFrom(points);
			}
			if (checkBox1.Checked)
			{
				showTimerIndex = 0;
			}
			else
			{
				showTimerIndex = -1;
			}

			showTimer.Start();
		}

		private void ShowSolution(Point[] sol, double fitnessValue, int index = -1)
		{
			ClearPictureBox();
			ShowPoints();

			int i = 0;
			g.DrawLine(linePen, first, sol[i]);
			for (i = 0; i < sol.Length - 1; i++)
			{
				g.DrawLine(linePen, sol[i], sol[i+1]);
			}
			g.DrawLine(linePen, sol[sol.Length - 1], first);
			bestSolutionLabel.Text = "Value: " + fitnessValue;
			
			pictureBox1.Refresh();
		}

		private Point[] GetNewChromosomeFrom(Point[] points)
		{
			Point[] res = new Point[points.Length];
			for (int i = 0; i < points.Length; i++)
			{
				res[i] = points[i];
			}

			// shuffle alg
			Point temp;
			int index;
			int index2;
			for (int i = 0; i < res.Length; i++)
			{
				index = rand.Next(0,res.Length);
				index2 = rand.Next(0,res.Length);
				temp = res[index2];
				res[index2] = res[index];
				res[index] = temp;
			}
			return res;
		}

		private void trackBar1_Scroll(object sender, EventArgs e)
		{
			UpdateMaxGenerations();
		}

		private void UpdateMaxGenerations()
		{
			trainNum.Text = "Generations to train: " + trackBar1.Value * maxGenMultiplier;
			maxGen = trackBar1.Value * maxGenMultiplier;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (genCounter < maxGen)
			{
				generateNewGeneration();
				genCounter++;
				if (checkBox1.Checked){
					ShowSolution(population[populationSize - 1], fitnessValue: fitnessVals[populationSize - 1]);
				}
				generationsCounter.Text = "Generation: " + genCounter;
				if (checkBox1.Checked)
				{
					showTimerIndex = 0;
				}
			}
			else
			{
				//ClearPictureBox();
				//pictureBox1.Refresh();
				popIndexLabel.Text = "";
				showTimer.Stop();
			}
			//}
		}

		private void generateNewGeneration()
		{
			bestSolution = double.MaxValue;
			//fitnessVals = new double[fitnessVals.Length];
			Point[][] currGen = population;
			var nextPopulationFrom = currGen.ToList();
			nextPopulation = new List<Point[]>(currGen.Length);

			evaluatePopulation(currGen);
			double randNum;
			int choosingIndex;

			// add to next population from
			AddBest(amount: bestConst, from: currGen, to: nextPopulation);
			AddCrossovers(amount: population.Length - bestConst - newRandNum,from: nextPopulationFrom, to: nextPopulation);
			AddCrossoversWithMutation(probability: mutationProb, updGen: nextPopulation);
			AddNewRandom(amount: newRandNum,to: nextPopulation);
			population = nextPopulation.ToArray();
		}

		private void AddBest(int amount, IReadOnlyList<Point[]> from, List<Point[]> to)
		{
			for (int i = 0; i < amount; i++)
			{
				to.Add(from[from.Count - 1 - i]);
			}
		}

		private void AddNewRandom(List<Point[]> to, int amount = 0)
		{
			if (amount == 0)
			{
				amount = population.Length - addedCrossovers;
			}
			for (int i = 0; i < amount; i++)
			{
				to.Add(GetNewChromosomeFrom(points));
			}
			addedRandoms = amount;
		}

		private void AddCrossoversWithMutation(double probability, List<Point[]> updGen)
		{
			int amount = 0;
			for (int i = 0; i < updGen.Count; i++)
			{
				if (probability >= rand.NextDouble())
				{
					updGen[i] = Mutate(updGen[i]);
					amount++;
				}
			}
			addedMutations = amount;
		}

		private Point[] Mutate(Point[] point)
		{
			int gene1 = rand.Next(point.Length);
			int gene2 = rand.Next(point.Length);
			while (gene1 == gene2)
			{
				gene2 = rand.Next(point.Length);
			}
			Point temp;

			temp = point[gene1];
			point[gene1] = point[gene2];
			point[gene2] = temp;

			return point;
		}

		private void AddCrossovers(int amount, IReadOnlyList<Point[]> from, List<Point[]> to)
		{
			for (int i = 0; i < amount; i++)
			{
				Point[] parent1 = from.Accept_Reject(bestSolution, ref rand, fitness);
				Point[] parent2 = from.Accept_Reject(bestSolution, ref rand, fitness);
				double middle = (fitness(parent1) + fitness(parent2)) / 2;
				Point[] newSol = CrossOver(parent1, parent2);
				while (fitness(newSol) < middle)
				{
					if (badSolutionProb >= rand.NextDouble())
					{
						break;
					}
					newSol = CrossOver(parent1, parent2);
				}
				to.Add(newSol);
			}
			addedCrossovers = amount;
		}

		private Point[] CrossOver(Point[] parent1arr, Point[] parent2arr)
		{
			List<Point> newSolution = parent2arr.ToList();
			List<Point> parent1 = parent1arr.ToList();

			// CROSSOVER

			int index1 = rand.Next(0, parent1arr.Length);
			int index2 = index1 + crossoverNumber;
			if (index2 > parent1arr.Length)
			{
				index2 = index1 - crossoverNumber;
			}

			// remove Points in range
			//Range range = Range.GetRangeIn(0, parent1arr.Length);
			Range range = new Range(index1, index2);

			//foreach (int index in range)
			//{
			//	newSolution.Remove(parent1[index]);
			//}
			newSolution.RemoveAll((p) => range.Contains(parent1.IndexOf(p)));

			foreach (int index in range)
			{
				newSolution.Add(parent1arr[index]);
			}

			return newSolution.ToArray();
		}

		private void evaluatePopulation(Point[][] gen)
		{
			Array.Sort(gen, (a,b) => {
					return Math.Sign(fitness(a) - fitness(b));
				});
			fitnessVals = new double[gen.Length];
			for (int i = 0; i < gen.Length; i++)
			{
				fitnessVals[i] = fitness(gen[i]);
			}
		}

		private void clearBtn_Click(object sender, EventArgs e)
		{

			Array.Sort(population, (a,b) => Math.Sign(fitness(a) - fitness(b) ) );
			ShowSolution(population[population.Length - 1], fitnessVals[population.Length - 1]);
		}
	}
}
