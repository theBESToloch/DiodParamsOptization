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
				GraphPanel.GraphPane.YAxis.Type = AxisType.Log;
				press_y = true;
			}
			else
			{
				GraphPanel.GraphPane.YAxis.Type = AxisType.Linear;
				press_y = false;
			}

			GraphPanel.AxisChange();
			GraphPanel.Invalidate();
		}

		private void LogxToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (press_x == false)
			{
				GraphPanel.GraphPane.XAxis.Type = AxisType.Log;
				press_x = true;
			}
			else
			{
				GraphPanel.GraphPane.XAxis.Type = AxisType.Linear;
				press_x = false;
			}
			GraphPanel.AxisChange();
			GraphPanel.Invalidate();
		}

		//главная функция вывода графиков
		void Graff(double[] x1, double[] y1, string titel, string xL, string yL, Color col)
		{
			Color color = Color.FromArgb(0, 0, 0);
			GraphPanel.IsShowPointValues = true;
			GraphPanel.GraphPane.XAxis.Title.Text = xL;
			GraphPanel.GraphPane.YAxis.Title.Text = yL;
			GraphPanel.GraphPane.Title.Text = "";
			GraphPanel.GraphPane.AddCurve(titel, x1, y1, color, SymbolType.None);
			LineItem myCurve = GraphPanel.GraphPane.AddCurve("", x1, y1, color);
			myCurve.Symbol.Fill.Color = color;
			GraphPanel.GraphPane.XAxis.MajorGrid.IsVisible = true;
			GraphPanel.GraphPane.YAxis.MajorGrid.IsVisible = true;
			GraphPanel.AxisChange();
			GraphPanel.Invalidate();
		}

		void Graff(double[] x1, double[] y1, string titel, string xL, string yL)
		{

			Color color = Color.FromArgb(0, 0, 0);
			GraphPanel.IsShowPointValues = true;
			GraphPanel.GraphPane.XAxis.Title.Text = xL;
			GraphPanel.GraphPane.YAxis.Title.Text = yL;
			GraphPanel.GraphPane.Title.Text = "";
			GraphPanel.GraphPane.AddCurve(titel, x1, y1, color, SymbolType.None);
			GraphPanel.GraphPane.XAxis.MajorGrid.IsVisible = true;
			GraphPanel.GraphPane.YAxis.MajorGrid.IsVisible = true;
			GraphPanel.AxisChange();
			GraphPanel.Invalidate();
		}

		void GraffSyY(double[] x1, double[] y1, string titel, string xL, string yL, Color a)
		{
			GraphPanel.IsShowPointValues = true;
			GraphPanel.GraphPane.XAxis.Title.Text = xL;
			GraphPanel.GraphPane.YAxis.Title.Text = yL;
			GraphPanel.GraphPane.Title.Text = "";
			GraphPanel.GraphPane.AddCurve(titel, x1, y1, a, SymbolType.None);
			GraphPanel.GraphPane.XAxis.MajorGrid.IsVisible = true;
			GraphPanel.GraphPane.YAxis.MajorGrid.IsVisible = true;
			GraphPanel.AxisChange();
			GraphPanel.Invalidate();
		}
	}
}
