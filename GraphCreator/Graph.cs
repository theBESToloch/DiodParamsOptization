using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ZedGraph;

namespace GraphCreator
{
	public partial class Graph : Form
	{

		bool combine = false;
		List<Chart> charts = new List<Chart>();
		List<Graph> graphs;

		public Graph(double[] x1, double[] y1, string titel, string xL, string yL, Color col, List<Graph> graphs)
		{
			InitializeComponent();
			Graff(x1, y1, titel, xL, yL, col);
			Chart chart = new Chart(x1, y1, titel, xL, yL);
			charts.Add(chart);
			this.graphs = graphs;
		}

		public Graph(double[] x1, double[] y1, string titel, string xL, string yL, List<Graph> graphs)
		{
			InitializeComponent();
			Graff(x1, y1, titel, xL, yL);
			Chart chart = new Chart(x1, y1, titel, xL, yL);
			charts.Add(chart);
			this.graphs = graphs;
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
			GraphPanel.IsShowPointValues = true;
			GraphPanel.GraphPane.XAxis.Title.Text = xL;
			GraphPanel.GraphPane.YAxis.Title.Text = yL;
			GraphPanel.GraphPane.Title.Text = "";
			GraphPanel.GraphPane.AddCurve(titel, x1, y1, col, SymbolType.None);
			/*LineItem myCurve = GraphPanel.GraphPane.AddCurve("", x1, y1, col);
			myCurve.Line.Width = 1;
			myCurve.Symbol.Fill.Color = col;*/
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

		private void AddToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Graph[] graphsAr = graphs.ToArray();

			for (int i = 0; i < graphsAr.Length; i++)
			{
				if (graphsAr[i].combine == true)
				{
					charts.AddRange(graphsAr[i].charts);
					graphs.RemoveAt(i);
					Redraw();
					break;
				}
			}
		}

		Random ran = new Random();

		private void Redraw()
		{
			GraphPanel.GraphPane.CurveList.Clear();
			Chart[] chartsAr = charts.ToArray();
			for (int i = 0; i < chartsAr.Length; i++)
			{
				Graff(chartsAr[i].X, chartsAr[i].Y, chartsAr[i].Title, chartsAr[i].XL, chartsAr[i].YL, Color.FromArgb(ran.Next(255), ran.Next(255), ran.Next(255)));
			}
		}

		private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			String Path = "";

			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				Path = folderBrowserDialog.SelectedPath;
			}
			for (int i = 0; i < charts.Count; i++)
				WriteArray(Path + "\\" + (i + 1) + " ", charts[i].X, charts[i].Y);

		}

		void WriteArray(string path, double[] array1, double[] array2)
		{
			using (StreamWriter sw = new StreamWriter(path + DateTime.Now.ToString().Replace(".", "-").Replace(":", "-") + ".txt", false))
			{
				sw.WriteLine(array1.Length);

				string[] line = new string[array1.Length],
						 line1 = new string[array2.Length];

				for (int i = 0; i < array1.Length; i++)
				{
					line[i] = array1[i].ToString();
					line1[i] = array2[i].ToString();
				}
				sw.WriteLine(String.Join(" ", line));
				sw.WriteLine(String.Join(" ", line1));
			}
		}

		private void СombineToolStripMenuItem_Click(object sender, EventArgs e)
		{
			combine = true;
			this.Close();
		}

	}
}
