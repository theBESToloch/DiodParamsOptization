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

			string[] IsPar = new string[3];
			IsPar[0] = "Is";
			IsPar[1] = Is[0].ToString();
			IsPar[2] = Is[0].ToString();
			ParamsListViewer.Items.Add(new ListViewItem(IsPar));
			string[] fPar = new string[3];
			fPar[0] = "fi";
			fPar[1] = fi[0].ToString();
			fPar[2] = fi[0].ToString();
			ParamsListViewer.Items.Add(new ListViewItem(fPar));

			Perform.Click += OptimizeTwoParamsModel;
		}

		#region Поля

		Optimize obj;
		LOAD_CHARACTERISTICs VAX;

		double[] Is = { 22.3E-12 },
				 fi = { 0.029 },
				 IK = { 0.005 },
				  R = { 13 };

		#endregion

		#region вычисления

		void OptimizeTwoParamsModel(object sender, EventArgs e)
		{
			obj = new optimize2Params(VAX.I, VAX.U, 
				Convert.ToInt32(nSteps.Text), 
				Convert.ToDouble(ParamsListViewer.Items[0].SubItems[2].Text.Replace(".", ",")),
				Convert.ToDouble(ParamsListViewer.Items[1].SubItems[2].Text.Replace(".", ",")));
			DoWork();
			RunWorkerCompleted();
			MessageBox.Show(" вычисления выполнены");
		}

		private void OptimizeThreeParamsModel(object sender, EventArgs e)
		{
			obj = new Optimize3Params(VAX.I, VAX.U, Convert.ToInt32(nSteps.Text), Convert.ToDouble(ParamsListViewer.Items[0].SubItems[2].Text.Replace(".", ",")), Convert.ToDouble(ParamsListViewer.Items[1].SubItems[2].Text.Replace(".", ",")), Convert.ToDouble(ParamsListViewer.Items[3].SubItems[2].Text.Replace(".", ",")));
			DoWork();
			RunWorkerCompleted2();
			MessageBox.Show(" вычисления выполнены");
		}

		private void OptimizeFourParamsModel(object sender, EventArgs e)
		{
			obj = new Optimize4Params(VAX.I, VAX.U, Convert.ToInt32(nSteps.Text), Convert.ToDouble(ParamsListViewer.Items[0].SubItems[2].Text.Replace(".", ",")), Convert.ToDouble(ParamsListViewer.Items[1].SubItems[2].Text.Replace(".", ",")), Convert.ToDouble(ParamsListViewer.Items[2].SubItems[2].Text.Replace(".", ",")), Convert.ToDouble(ParamsListViewer.Items[3].SubItems[2].Text.Replace(".", ",")));
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

			ParamsListViewer.Items[0].SubItems[1].Text = opt.IS0.ToString();
			ParamsListViewer.Items[1].SubItems[1].Text = opt.F0.ToString();
			ParamsListViewer.Items[1].SubItems[2].Text = opt.F0.ToString();
			ParamsListViewer.Items[0].SubItems[2].Text = opt.IS0.ToString();
			label1.Text = opt.Z.ToString();

			initErr.Text = obj.initErr().ToString();
			Err.Text = obj.optimizeErr().ToString();

		}

		private void RunWorkerCompleted2()
		{
			Optimize3Params opt = (Optimize3Params)obj;

			ParamsListViewer.Items[0].SubItems[1].Text = opt.IS0.ToString();
			ParamsListViewer.Items[0].SubItems[2].Text = opt.IS0.ToString();
			ParamsListViewer.Items[1].SubItems[1].Text = opt.F0.ToString();
			ParamsListViewer.Items[1].SubItems[2].Text = opt.F0.ToString();
			ParamsListViewer.Items[2].SubItems[1].Text = opt.R00.ToString();
			ParamsListViewer.Items[2].SubItems[2].Text = opt.R00.ToString();
			label1.Text = opt.Z.ToString();

			initErr.Text = obj.initErr().ToString();
			Err.Text = obj.optimizeErr().ToString();
		}

		private void RunWorkerCompleted3()
		{
			Optimize4Params opt = (Optimize4Params)obj;

			ParamsListViewer.Items[0].SubItems[1].Text = opt.IS0.ToString();
			ParamsListViewer.Items[0].SubItems[2].Text = opt.IS0.ToString();
			ParamsListViewer.Items[1].SubItems[1].Text = opt.F0.ToString();
			ParamsListViewer.Items[1].SubItems[2].Text = opt.F0.ToString();
			ParamsListViewer.Items[2].SubItems[1].Text = opt.R00.ToString();
			ParamsListViewer.Items[2].SubItems[2].Text = opt.R00.ToString();
			ParamsListViewer.Items[3].SubItems[1].Text = opt.IKF0.ToString();
			ParamsListViewer.Items[3].SubItems[2].Text = opt.IKF0.ToString();
			label1.Text = opt.Z.ToString();

			initErr.Text = obj.initErr().ToString();
			Err.Text = obj.optimizeErr().ToString();
		}
		#endregion

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

		private void InitOptimizeModel_SelectedIndexChanged(object sender, EventArgs e)
		{
			int selectedState = InitOptimizeModel.SelectedIndex;

			switch (InitOptimizeModel.SelectedIndex)
			{
				case 0: {
						Perform.Click += OptimizeTwoParamsModel;
						break; }
				case 1: {
						Perform.Click += OptimizeThreeParamsModel;
						break; }
				case 2: {
						Perform.Click += OptimizeFourParamsModel;
						break; }
				case 3: {
						Perform.Click += null;
						break; }
				case 4: {
						Perform.Click += null;
						break; }
			}

		}

		private void ParamsListViewer_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Clicks > 1)
			{
				TextBox tbox = new TextBox();
				this.Controls.Add(tbox);
				tbox.Width = ParamsListViewer.Columns[2].Width;
				ListViewItem item = ParamsListViewer.GetItemAt(0, e.Y);
				if (item != null)
				{
					int x_cord = 0;
					for (int i = 0; i < ParamsListViewer.Columns.Count - 1; i++)
						x_cord += ParamsListViewer.Columns[i].Width;
					tbox.Left = x_cord;
					tbox.Top = item.Position.Y;
					tbox.Text = item.SubItems[2].Text;
					tbox.Leave += DisposeTextBox;
					tbox.KeyPress += TextBoxKeyPress;
					ParamsListViewer.Controls.Add(tbox);
					tbox.Focus();
					tbox.Select(tbox.Text.Length, 1);
				}
			}
		}

		private void DisposeTextBox(object sender, EventArgs e)
		{
			var tb = (sender as TextBox);
			var item = ParamsListViewer.GetItemAt(0, tb.Top + 1);
			if (item != null)
				item.SubItems[2].Text = tb.Text;
			tb.Dispose();
		}

		private void TextBoxKeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 13)
				DisposeTextBox((sender as TextBox), null);
			if (e.KeyChar == 27)
				(sender as TextBox).Dispose();

			if (!Char.IsDigit(e.KeyChar))
			{
				e.Handled = true;
			}

			if(e.KeyChar == 'e' || e.KeyChar == 'E' || e.KeyChar == 'е' || e.KeyChar == 'E')
			{
				if((sender as TextBox).Text.Contains("e") || (sender as TextBox).Text.Contains("E") || (sender as TextBox).Text.Contains("е") || (sender as TextBox).Text.Contains("Е")) e.Handled = true;
				else e.Handled = false;
			}

			if(e.KeyChar == 8 || e.KeyChar == '-')
			{
				e.Handled = false;
			}



		}


		#region ВАХ

		Graph[] graph;

		private void ИзмереннаяToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Graph graph = new Graph(VAX.U, VAX.I, "ВАХ", "U", "I", Color.Brown);
			graph.Show();
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