using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ZedGraph;

using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;

namespace GraphCreator
{
	public partial class Graph : Form
	{

		bool combine = false;
		List<Chart> charts = new List<Chart>();
		List<Graph> graphs;

		public Graph(double[] x1, double[] y1, string title, string xL, string yL, List<Graph> graphs)
		{
			InitializeComponent();
			Chart chart = new Chart(x1, y1, title, xL, yL);
			charts.Add(chart);
			this.graphs = graphs;

			var myModel = new PlotModel { Title = title };
			this.plotView1.Model = myModel;

			Plot(x1, y1, title, xL, yL);
		}

		bool press_x = false, press_y = false;

		private void LogyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			plotView1.Model.InvalidatePlot(true);
			if (press_y == false)
			{
				plotView1.Model.Axes[1] = new LogarithmicAxis { Position = AxisPosition.Left };
				press_y = true;
			}
			else
			{
				plotView1.Model.Axes[1] = new LinearAxis { Position = AxisPosition.Left };
				press_y = false;
			}
		}

		private void LogxToolStripMenuItem_Click(object sender, EventArgs e)
		{
			plotView1.Model.InvalidatePlot(true);
			if (press_x == false)
			{
				plotView1.Model.Axes[0] = new LogarithmicAxis { Position = AxisPosition.Bottom };
				press_x = true;
			}
			else
			{
				plotView1.Model.Axes[0] = new LinearAxis { Position = AxisPosition.Bottom };
				press_x = false;
			}
		}

		void Plot(double[] x1, double[] y1, string title, string xL, string yL)
		{
			
			var lineSeries = new LineSeries();
			for(int i = 0; i < x1.Length;i++) lineSeries.Points.Add(new OxyPlot.DataPoint(x1[i], y1[i]));
			this.plotView1.Model.Series.Add(lineSeries);
			
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

		private void Redraw()
		{
			Chart[] chartsAr = charts.ToArray();
			for (int i = 0; i < chartsAr.Length; i++)
			{
				Plot(chartsAr[i].X, chartsAr[i].Y, chartsAr[i].Title, chartsAr[i].XL, chartsAr[i].YL);
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

		private void сохранитьSvgToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (var stream = File.Create("1234.svg"))
			{
				var exporter = new SvgExporter { Width = 600, Height = 400 };
				exporter.Export(plotView1.Model, stream);
			}
		}

		private void СombineToolStripMenuItem_Click(object sender, EventArgs e)
		{
			combine = true;
			this.Close();
		}

	}
}
