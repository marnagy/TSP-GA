using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
		Pen linePen = new Pen(Color.Blue);
		//Color lineColor = Color.Blue;
		Pen bestLinePen = new Pen(Color.Green);
		//Color bestColor = Color.Green;
		int genCounter = 0;
		Point first;
		Point[] points;
		int pointWidth = 5;
		Rectangle[] pointRect;
		Random rand;
		int pointMargin = 10;
		bool train = false;
		Point[][] population;
		int populationLengthMultiplier = 10;
		int sleepAmount = 1000/60;
		int showTimerIndex = 0;

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
			trainNum.Text = "Generations to train: " + trackBar1.Value;
			rand = new Random();
		}
		private void ClearPictureBox()
		{
			g.FillRectangle(bgBrush, 0,0,pictureBox1.Width, pictureBox1.Height);
		}

		private void loadButton_Click(object sender, EventArgs e)
		{
			int numberOfPoints;
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

			ClearPictureBox();
			ShowPoints();
			pictureBox1.Refresh();
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
			train = true;
			population = new Point[(points.Length + 1) * populationLengthMultiplier][];

			for (int i = 0; i < population.Length; i++)
			{
				population[i] = GetNewChromosomeFrom(points);
			}
			if (checkBox1.Checked)
			{
				showTimerIndex = 0;
				showTimer.Start();
			}
			//Thread.Sleep(population.Length * 150);

			// start training
		}

		private void ShowSolution(Point[] sol, int index)
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
			for (int i = 0; i < res.Length * 2; i++)
			{
				//if (i > 0)
				//{
				index = rand.Next(0,res.Length);
				index2 = rand.Next(0,res.Length);
				temp = res[index2];
				res[index2] = res[index];
				res[index] = temp;
				//}
			}
			return res;
		}

		private void trackBar1_Scroll(object sender, EventArgs e)
		{
			trainNum.Text = "Generations to train: " + trackBar1.Value;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (showTimerIndex >= 0 && showTimerIndex < population.Length)
			{
				ShowSolution(population[showTimerIndex], showTimerIndex);
				popIndexLabel.Text = "Population index: " + (showTimerIndex + 1);
				showTimerIndex++;
			}
			else
			{
				ClearPictureBox();
				pictureBox1.Refresh();
				popIndexLabel.Text = "";
				showTimer.Stop();
			}
		}
	}
}
