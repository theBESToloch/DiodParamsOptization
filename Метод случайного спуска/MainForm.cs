using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using RandomDescent;
using GraphCreator;

namespace Метод_случайного_спуска
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();

			//настраиваем форму
			VAX = new LOAD_CHARACTERISTICs("", "");

			par_Is1.Text = Is[0].ToString();
			textBox1.Text = Is[0].ToString();
			par_fi1.Text = fi[0].ToString();
			textBox2.Text = fi[0].ToString();
			par_fi1.Text = fi[0].ToString();
			textBox2.Text = fi[0].ToString();
			par_R.Text = R[0].ToString();
			textBox3.Text = R[0].ToString();
			par_IKF.Text = IK[0].ToString();
			textBox4.Text = IK[0].ToString();
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

		#region вычисления

		void Button2Click(object sender, EventArgs e)
		{
			obj = new optimize2Params(VAX.I, VAX.U, Convert.ToInt32(nSteps.Text), Convert.ToDouble(textBox1.Text.Replace(".", ",")), Convert.ToDouble(textBox2.Text.Replace(".", ",")));
			DoWork();
			RunWorkerCompleted();
			MessageBox.Show(" вычисления выполнены");
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			obj = new Optimize3Params(VAX.I, VAX.U, Convert.ToInt32(nSteps.Text), Convert.ToDouble(textBox1.Text.Replace(".", ",")), Convert.ToDouble(textBox2.Text.Replace(".", ",")), Convert.ToDouble(textBox3.Text.Replace(".", ",")));
			DoWork();
			RunWorkerCompleted2();
			MessageBox.Show(" вычисления выполнены");
		}

		private void Button3_Click(object sender, EventArgs e)
		{
			obj = new Optimize4Params(VAX.I, VAX.U, Convert.ToInt32(nSteps.Text), Convert.ToDouble(textBox1.Text.Replace(".", ",")), Convert.ToDouble(textBox2.Text.Replace(".", ",")), Convert.ToDouble(textBox3.Text.Replace(".", ",")), Convert.ToDouble(textBox4.Text.Replace(".", ",")));
			DoWork();
			RunWorkerCompleted3();
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

			initErr.Text = obj.initErr().ToString();
			Err.Text = obj.optimizeErr().ToString();

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

			initErr.Text = obj.initErr().ToString();
			Err.Text = obj.optimizeErr().ToString();
		}

		private void RunWorkerCompleted3()
		{
			Optimize4Params opt = (Optimize4Params)obj;

			par_Is1.Text = opt.IS0.ToString();
			textBox1.Text = opt.IS0.ToString();
			par_fi1.Text = opt.F0.ToString();
			textBox2.Text = opt.F0.ToString();
			par_R.Text = opt.R00.ToString();
			textBox3.Text = opt.R00.ToString();
			par_IKF.Text = opt.IKF0.ToString();
			textBox4.Text = opt.IKF0.ToString();
			label1.Text = opt.Z.ToString();

			initErr.Text = obj.initErr().ToString();
			Err.Text = obj.optimizeErr().ToString();
		}
		#endregion

		#region ВАХ
		private void ЗагрузитьВАХToolStripMenuItem_Click(object sender, EventArgs e)
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

		private void ИзмереннаяToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new Graph(VAX.U, VAX.I, "ВАХ", "U", "I", Color.Brown).Show();
		}

		private void АппроксимированнаяToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Graph graph = new Graph(obj.getMassU(), obj.getMassI(), "ВАХ(аппроксимированная)", "U", "I", Color.Black);
			graph.Show();
		}

		private void ПогрешностьПоТокуToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			double[] I = obj.inaccuracyOfCUrrent();

			SCO_ABS.Text = obj.getSCO_ABS_cur().ToString();
			SCO_REL.Text = obj.getSCO_REL_cur().ToString();

			Graph graph = new Graph(obj.getMassU(), I, "погрешность", "U", "%", Color.Green);
			graph.Show();
		}

		private void ПогрешностьПоНапряжениюToolStripMenuItem_Click(object sender, EventArgs e)
		{
			double[] U = obj.inaccuracyOfVoltage();

			SCO_ABS.Text = obj.getSCO_ABS_vol().ToString();
			SCO_REL.Text = obj.getSCO_REL_vol().ToString();

			Graph graph = new Graph(obj.getMassI(), U, "погрешность", "I", "%", Color.Red);
			graph.Show();
		}

		#endregion

	}
}