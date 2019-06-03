using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
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

			this.graphs = graphs;
			var myModel = new PlotModel { Title = title };
			this.plotView1.Model = myModel;

			Chart chart = new Chart(x1, y1, title, xL, yL);
			charts.Add(chart);

			Plot(x1, y1, title, xL, yL);

		}

		public Graph(List<double[]> x1, List<double[]> y1, string title, string xL, string yL, List<Graph> graphs)
		{
			InitializeComponent();

			this.graphs = graphs;
			var myModel = new PlotModel { Title = title };
			this.plotView1.Model = myModel;

			for (int i = 0; i < x1.Count; i++)
			{
				Chart chart = new Chart(x1[i], y1[i], title, xL, yL);
				charts.Add(chart);
				Plot(x1[i], y1[i], title, xL, yL);
			}
		}

		void Plot(double[] x1, double[] y1, string title, string xL, string yL)
		{
			var lineSeries = new LineSeries();
			for (int i = 0; i < x1.Length; i++) lineSeries.Points.Add(new OxyPlot.DataPoint(x1[i], y1[i]));
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

		private void СombineToolStripMenuItem_Click(object sender, EventArgs e)
		{
			combine = true;
			this.Close();
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
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			String Path = "";

			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				Path = folderBrowserDialog.SelectedPath;
			}

			using (var stream = File.Create(Path + "\\" + this.plotView1.Model.Title + "-" + DateTime.Now.ToString().Replace(".", "-").Replace(":", "-") + ".svg"))
			{
				var exporter = new SvgExporter { Width = this.Width, Height = this.Height };
				exporter.Export(plotView1.Model, stream);
			}
		}


		double YdefMax = double.NaN;
		double Ymax;
		private void YMax_Leave(object sender, EventArgs e)
		{
			if (double.IsNaN(YdefMax)) YdefMax = plotView1.Model.Axes[1].ActualMaximum;
			try
			{
				if (YMax.Text != "")
				{
					double Ym = Convert.ToDouble(YMax.Text.Replace('.', ',').Replace("*10^", "e"));
					if (Ymax != Ym)
					{
						Ymax = Ym;
						plotView1.Model.Axes[1].Maximum = Ymax;
					}
				}
				else
				{
					this.plotView1.Model.Axes[1].Maximum = YdefMax;
					YMax.Text = YdefMax.ToString();
				}
			}
			catch (Exception ex) {
				Console.Out.WriteLine(ex);

				this.plotView1.Model.Axes[1].Maximum = YdefMax;
				YMax.Text = YdefMax.ToString();
			}
			plotView1.Model.InvalidatePlot(true);
		}

		double YdefMin = double.NaN;
		double Ymin;
		private void YMin_Leave(object sender, EventArgs e)
		{
			if (double.IsNaN(YdefMin)) YdefMin = plotView1.Model.Axes[1].ActualMinimum;
			try
			{
				if (YMin.Text != "")
				{
					double Ym = Convert.ToDouble(YMin.Text.Replace('.', ',').Replace("*10^", "e"));
					if (Ymin != Ym)
					{
						Ymin = Ym;
						this.plotView1.Model.Axes[1].Minimum = Ymin;
					}
				}
				else
				{
					this.plotView1.Model.Axes[1].Minimum = YdefMin;
					YMin.Text = YdefMin.ToString();
				}
			}
			catch (Exception ex)
			{
				Console.Out.WriteLine(ex);
				this.plotView1.Model.Axes[1].Minimum = YdefMin;
				YMin.Text = YdefMin.ToString();
			}
			plotView1.Model.InvalidatePlot(true);
		}

		double XdefMax = double.NaN;
		double Xmax;
		private void XMax_Leave(object sender, EventArgs e)
		{
			if (double.IsNaN(XdefMax)) XdefMax = plotView1.Model.Axes[0].ActualMaximum;
			try
			{
				if (XMax.Text != "")
				{
					double Xm = Convert.ToDouble(XMax.Text.Replace('.', ',').Replace("*10^", "e"));
					if (Xmax != Xm)
					{
						Xmax = Xm;
						this.plotView1.Model.Axes[0].Maximum = Xmax;
					}
				}
				else
				{
					this.plotView1.Model.Axes[0].Maximum = XdefMax;
					XMax.Text = XdefMax.ToString();
				}
			}
			catch (Exception ex)
			{
				Console.Out.WriteLine(ex);
				this.plotView1.Model.Axes[0].Maximum = XdefMax;
				XMax.Text = XdefMax.ToString();
			}
			plotView1.Model.InvalidatePlot(true);
		}

		double XdefMin = double.NaN;
		double Xmin;
		private void XMin_Leave(object sender, EventArgs e)
		{
			if (double.IsNaN(XdefMin)) XdefMin = plotView1.Model.Axes[0].ActualMinimum;
			try
			{
				if (XMin.Text != "")
				{
					double Xm = Convert.ToDouble(XMin.Text.Replace('.', ',').Replace("*10^", "e"));
					if (Xmin != Xm)
					{
						Xmin = Xm;
						this.plotView1.Model.Axes[0].Minimum = Xmin;
					}
				}
				else
				{
					this.plotView1.Model.Axes[0].Minimum = XdefMin;
					XMin.Text = XdefMin.ToString();
				}

			}
			catch (Exception ex)
			{
				Console.Out.WriteLine(ex);
				this.plotView1.Model.Axes[0].Minimum = XdefMin;
				XMin.Text = XdefMin.ToString();
			}
			plotView1.Model.InvalidatePlot(true);
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



		private void отобразитьТочкиToolStripMenuItem_Click(object sender, EventArgs e)
		{


			/*foreach(LineSeries ls in plotView1.Model.Series)
			{
				ls.MarkerFill = OxyColor.FromRgb(0, 0, 0);
				ls.MarkerType = MarkerType.Circle;
			}*/

			for(int i = 0; i < plotView1.Model.Series.Count; i++)
			{
				((LineSeries)plotView1.Model.Series[i]).MarkerFill = OxyColor.FromRgb(0, 0, 0);
				((LineSeries)plotView1.Model.Series[i]).MarkerType = MarkerType.Circle;
			}
		}

	}
}
