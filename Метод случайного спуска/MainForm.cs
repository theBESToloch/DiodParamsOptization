using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using RandomDescent;
using ZedGraph;

namespace Метод_случайного_спуска
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();

			//настраиваем форму
			VAX = new LOAD_CHARACTERISTICs("","");

			Graffik.GraphPane.Title.Text = "";
			Graffik.GraphPane.XAxis.Title.Text = "";
			Graffik.GraphPane.YAxis.Title.Text = "";

			par_Is1.Text = Is[0].ToString();
			textBox1.Text = Is[0].ToString();
			par_fi1.Text = fi[0].ToString();
			textBox2.Text = fi[0].ToString();
			par_fi1.Text = fi[0].ToString();
			textBox2.Text = fi[0].ToString();
			par_R.Text = R[0].ToString();
		}

		#region Поля

		Optimize obj;
		LOAD_CHARACTERISTICs VAX;


		List<double> Sy = new List<double>(),
					  y = new List<double>(),
					ISy = new List<double>(),
					 fy = new List<double>(),
					IKy = new List<double>(),
					 Ry = new List<double>();

		List<int> z = new List<int>();

		public double length = 0;
		
		double[] Is = { 22.3E-12 },
				 fi = { 0.029 },
				 IK = { 0.005 },
				  R = { 13 };

		//вывод в окне
		List<double> two_x = new List<double>();
		List<double> two_y = new List<double>();
		#endregion

		#region Формы

		#endregion

		#region графики и их вывод
		Random ran = new Random();

		//главная функция вывода графиков

		void Graff(double[] x1, double[] y1, string titel, string xL, string yL, Color col)
		{
			Color color = Color.FromArgb(ran.Next(255), ran.Next(255), ran.Next(255));
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

			Color color = Color.FromArgb(ran.Next(255), ran.Next(255), ran.Next(255));
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

		private void очститьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Graffik.GraphPane.CurveList.Clear();
			Graffik.IsShowPointValues = true;
			Graffik.GraphPane.XAxis.Title.Text = "";
			Graffik.GraphPane.YAxis.Title.Text = "";
			Graffik.GraphPane.Title.Text = "";
			Graffik.GraphPane.XAxis.MajorGrid.IsVisible = true;
			Graffik.GraphPane.YAxis.MajorGrid.IsVisible = true;
			Graffik.AxisChange();
			Graffik.Invalidate();

			two_x.Clear();
			two_y.Clear();

		}
		//масштаб логарифмический
		bool press_x = false, press_y = false;
		private void button4_Click(object sender, EventArgs e)
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

		private void button5_Click(object sender, EventArgs e)
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

		#endregion

		#region вычисления

		void Button2Click(object sender, EventArgs e)
		{
			obj = new optimize2Params(VAX.I, VAX.U, Convert.ToInt32(nSteps.Text), Convert.ToDouble(textBox1.Text.Replace(".", ",")), Convert.ToDouble(textBox2.Text.Replace(".", ",")));

			DoWork();
			RunWorkerCompleted();
			MessageBox.Show(" вычисления выполнены");
		}

		private void DoWork()
		{
			try
			{
				obj.doOptimize();
			}
			catch
			{
				MessageBox.Show("Ошибка вычислений");
			}

		}

		private void RunWorkerCompleted()
		{
			optimize2Params opt = (optimize2Params)obj;

			par_Is1.Text = opt.IS0.ToString();
			textBox1.Text = opt.IS0.ToString();
			par_fi1.Text = opt.F0.ToString();
			textBox2.Text = opt.F0.ToString();
			label1.Text = opt.Z.ToString();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			obj = new Optimize3Params(VAX.I, VAX.U, Convert.ToInt32(nSteps.Text), Convert.ToDouble(textBox1.Text.Replace(".", ",")), Convert.ToDouble(textBox2.Text.Replace(".", ",")), Convert.ToDouble(textBox3.Text.Replace(".", ",")));
			DoWork();
			RunWorkerCompleted2();
			MessageBox.Show(" вычисления выполнены");
		}

		private void RunWorkerCompleted2()
		{
			Optimize3Params opt = (Optimize3Params)obj;

			par_Is1.Text = opt.IS0.ToString();
			textBox1.Text = opt.IS0.ToString();
			par_fi1.Text = opt.F0.ToString();
			textBox2.Text = opt.F0.ToString();
			par_R.Text = opt.R00.ToString();
			textBox3.Text = opt.R00.ToString();

			label1.Text = opt.Z.ToString();
		}

		#endregion

		#region ВАХ
		private void загрузитьВАХToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				VAX.ShowDialog();
			}
			catch
			{
				MessageBox.Show("ошибка");
			}
		}

		private void измереннаяToolStripMenuItem_Click(object sender, EventArgs e)
		{
			GraffSyY(VAX.U, VAX.I, "ВАХ", "U", "I", Color.Brown);
		}

		private void аппроксимированнаяToolStripMenuItem_Click(object sender, EventArgs e)
		{
			GraffSyY(obj.getMassU(), obj.getMassI(), "ВАХ(аппроксимированная)", "U", "I", Color.Black);
		}

		private void погрешностьПоТокуToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			double[] I = obj.inaccuracyOfCUrrent();

			SCO_ABS.Text = obj.getSCO_ABS_cur().ToString();
			SCO_REL.Text = obj.getSCO_REL_cur().ToString();
			GraffSyY(obj.getMassU(), I, "погрешность", "U", "%", Color.Green);
		}

		private void погрешностьПоНапряжениюToolStripMenuItem_Click(object sender, EventArgs e)
		{
			double[] U = obj.inaccuracyOfVoltage();

			SCO_ABS.Text = obj.getSCO_ABS_vol().ToString();
			SCO_REL.Text = obj.getSCO_REL_vol().ToString();

			GraffSyY(obj.getMassI(), U, "погрешность", "I", "%", Color.Red);
		}

		#endregion

	}
}