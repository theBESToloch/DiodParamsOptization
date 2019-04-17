using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace GraphCreator
{
	public partial class Graph : Form
	{
		Graph()
		{
			InitializeComponent();
		}

		public Graph(double[] x1, double[] y1, string titel, string xL, string yL, Color col)
		{
			InitializeComponent();
			Graff(x1, y1, titel, xL, yL, col);
		}

		public Graph(double[] x1, double[] y1, string titel, string xL, string yL)
		{
			InitializeComponent();
			Graff(x1, y1, titel, xL, yL);
		}


		//масштаб логарифмический
		bool press_x = false, press_y = false;

		private void LogyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (press_y == false)
			{
				Graffik.GraphPane.YAxis.Type = AxisType.Log;
				press_y = true;
			}
			else
			{
				Graffik.GraphPane.YAxis.Type = AxisType.Linear;
				press_y = false;
			}

			Graffik.AxisChange();
			Graffik.Invalidate();
		}

		private void LogxToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (press_x == false)
			{
				Graffik.GraphPane.XAxis.Type = AxisType.Log;
				press_x = true;
			}
			else
			{
				Graffik.GraphPane.XAxis.Type = AxisType.Linear;
				press_x = false;
			}
			Graffik.AxisChange();
			Graffik.Invalidate();
		}

		//главная функция вывода графиков
		void Graff(double[] x1, double[] y1, string titel, string xL, string yL, Color col)
		{
			Color color = Color.FromArgb(0, 0, 0);
			Graffik.IsShowPointValues = true;
			Graffik.GraphPane.XAxis.Title.Text = xL;
			Graffik.GraphPane.YAxis.Title.Text = yL;
			Graffik.GraphPane.Title.Text = "";
			Graffik.GraphPane.AddCurve(titel, x1, y1, color, SymbolType.None);
			LineItem myCurve = Graffik.GraphPane.AddCurve("Scatter", x1, y1, color);
			myCurve.Symbol.Fill.Color = color;
			Graffik.GraphPane.XAxis.MajorGrid.IsVisible = true;
			Graffik.GraphPane.YAxis.MajorGrid.IsVisible = true;
			Graffik.AxisChange();
			Graffik.Invalidate();
		}

		void Graff(double[] x1, double[] y1, string titel, string xL, string yL)
		{

			Color color = Color.FromArgb(0, 0, 0);
			Graffik.IsShowPointValues = true;
			Graffik.GraphPane.XAxis.Title.Text = xL;
			Graffik.GraphPane.YAxis.Title.Text = yL;
			Graffik.GraphPane.Title.Text = "";
			Graffik.GraphPane.AddCurve(titel, x1, y1, color, SymbolType.None);
			Graffik.GraphPane.XAxis.MajorGrid.IsVisible = true;
			Graffik.GraphPane.YAxis.MajorGrid.IsVisible = true;
			Graffik.AxisChange();
			Graffik.Invalidate();
		}

		void GraffSyY(double[] x1, double[] y1, string titel, string xL, string yL, Color a)
		{
			Graffik.IsShowPointValues = true;
			Graffik.GraphPane.XAxis.Title.Text = xL;
			Graffik.GraphPane.YAxis.Title.Text = yL;
			Graffik.GraphPane.Title.Text = "";
			Graffik.GraphPane.AddCurve(titel, x1, y1, a, SymbolType.None);
			Graffik.GraphPane.XAxis.MajorGrid.IsVisible = true;
			Graffik.GraphPane.YAxis.MajorGrid.IsVisible = true;
			Graffik.AxisChange();
			Graffik.Invalidate();
		}
	}
}
