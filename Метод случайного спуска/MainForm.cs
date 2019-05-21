using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using RandomDescent;
using GraphCreator;

namespace Метод_случайного_спуска
{
	delegate void MyEventHandler();

	public partial class MainForm : Form
	{

		#region Поля

		private IOptimize obj;

		private LOAD_CHARACTERISTICs VAX;

		private Dictionary<string, double> par;

		private MyEventHandler d;

		private List<Graph> graphs;
		#endregion

		int OptimizeMethodVal = 0;

		public MainForm()
		{
			InitializeComponent();

			VAX = new LOAD_CHARACTERISTICs("", "");
			graphs = new List<Graph>();
			par = new Dictionary<string, double>
			{
				{ "IKF", 0.005 },
				{ "R", 13 },
				{ "fi", 0.029 },
				{ "Is", 22.3E-12 },
				{ "a1", 0.029 },
				{ "a2", 0.001 }
			};

			ParamsListViewer.Items.Add(new ListViewItem(new string[] { "Is", par["Is"].ToString(), par["Is"].ToString() }));
			ParamsListViewer.Items.Add(new ListViewItem(new string[] { "fi", par["fi"].ToString(), par["fi"].ToString() }));

			d += OptimizeTwoParamsModel;

			OptimizeMethodVal = Convert.ToInt32(OptimizeMethod.Text);
		}

		#region вычисления

		private void DoWork()
		{
			try
			{

				switch (OptimizeMethodVal)
				{
					case 1: obj.DoOptimize(Convert.ToInt32(nSteps.Text)); break;
					case 2: obj.DoOptimizeUniform(Convert.ToInt32(nSteps.Text)); break;
					case 3: obj.DoOptimizeUniformAndNormalize(Convert.ToInt32(nSteps.Text)); break;
					case 4: obj.DoOptimizeAndNormalize(Convert.ToInt32(nSteps.Text)); break;
				}

			}
			catch
			{
				MessageBox.Show("Ошибка вычислений");
			}

		}

		private void OptimizeTwoParamsModel()
		{
			if (obj == null || obj.GetType() != typeof(Optimize2Params) || OptimizeMethodVal != Convert.ToInt32(OptimizeMethod.Text))
			{
				obj = new Optimize2Params(VAX.I, VAX.U,
					Convert.ToDouble(ParamsListViewer.Items[0].SubItems[2].Text.Replace(".", ",")),
					Convert.ToDouble(ParamsListViewer.Items[1].SubItems[2].Text.Replace(".", ",")));
				OptimizeMethodVal = Convert.ToInt32(OptimizeMethod.Text);
			}
			DoWork();
			CompleteTwoParamsModelOptimize();
			MessageBox.Show(" вычисления выполнены");
		}
		private void CompleteTwoParamsModelOptimize()
		{
			Optimize2Params opt = (Optimize2Params)obj;

			ParamsListViewer.Items[0].SubItems[1].Text = opt.IS0.ToString();
			ParamsListViewer.Items[1].SubItems[1].Text = opt.F0.ToString();
			ParamsListViewer.Items[1].SubItems[2].Text = opt.F0.ToString();
			ParamsListViewer.Items[0].SubItems[2].Text = opt.IS0.ToString();
			label1.Text = opt.Z.ToString();

			Err.Text = obj.OptimizeErr().ToString();
		}

		private void OptimizeThreeParamsModel()
		{
			if (!(obj != null && obj.GetType() == typeof(Optimize3Params)))
				obj = new Optimize3Params(VAX.I, VAX.U,
				Convert.ToDouble(ParamsListViewer.Items[0].SubItems[2].Text.Replace(".", ",")),
				Convert.ToDouble(ParamsListViewer.Items[1].SubItems[2].Text.Replace(".", ",")),
				Convert.ToDouble(ParamsListViewer.Items[2].SubItems[2].Text.Replace(".", ",")));
			DoWork();
			CompleteThreeParamsModelOptimize();
			MessageBox.Show(" вычисления выполнены");
		}
		private void CompleteThreeParamsModelOptimize()
		{
			Optimize3Params opt = (Optimize3Params)obj;

			ParamsListViewer.Items[0].SubItems[1].Text = opt.IS0.ToString();
			ParamsListViewer.Items[0].SubItems[2].Text = opt.IS0.ToString();
			ParamsListViewer.Items[1].SubItems[1].Text = opt.F0.ToString();
			ParamsListViewer.Items[1].SubItems[2].Text = opt.F0.ToString();
			ParamsListViewer.Items[2].SubItems[1].Text = opt.R0.ToString();
			ParamsListViewer.Items[2].SubItems[2].Text = opt.R0.ToString();
			label1.Text = opt.Z.ToString();

			Err.Text = obj.OptimizeErr().ToString();
		}

		private void OptimizeFourParamsModel()
		{
			if (!(obj != null && obj.GetType() == typeof(Optimize4Params)))
				obj = new Optimize4Params(VAX.I, VAX.U,
				Convert.ToDouble(ParamsListViewer.Items[0].SubItems[2].Text.Replace(".", ",")),
				Convert.ToDouble(ParamsListViewer.Items[1].SubItems[2].Text.Replace(".", ",")),
				Convert.ToDouble(ParamsListViewer.Items[2].SubItems[2].Text.Replace(".", ",")),
				Convert.ToDouble(ParamsListViewer.Items[3].SubItems[2].Text.Replace(".", ",")));
			DoWork();
			CompleteFourParamsModelOptimize();
			MessageBox.Show(" вычисления выполнены");
		}
		private void CompleteFourParamsModelOptimize()
		{
			Optimize4Params opt = (Optimize4Params)obj;

			ParamsListViewer.Items[0].SubItems[1].Text = opt.IS0.ToString();
			ParamsListViewer.Items[0].SubItems[2].Text = opt.IS0.ToString();
			ParamsListViewer.Items[1].SubItems[1].Text = opt.F0.ToString();
			ParamsListViewer.Items[1].SubItems[2].Text = opt.F0.ToString();
			ParamsListViewer.Items[2].SubItems[1].Text = opt.R0.ToString();
			ParamsListViewer.Items[2].SubItems[2].Text = opt.R0.ToString();
			ParamsListViewer.Items[3].SubItems[1].Text = opt.IKF0.ToString();
			ParamsListViewer.Items[3].SubItems[2].Text = opt.IKF0.ToString();
			label1.Text = opt.Z.ToString();

			Err.Text = obj.OptimizeErr().ToString();
		}

		private void OptimizeFiParamsModel()
		{
			if (!(obj != null && obj.GetType() == typeof(OptimizeParams_Fi)))
				obj = new OptimizeParams_Fi(VAX.I, VAX.U,
				Convert.ToDouble(ParamsListViewer.Items[0].SubItems[2].Text.Replace(".", ",")),
				Convert.ToDouble(ParamsListViewer.Items[1].SubItems[2].Text.Replace(".", ",")),
				Convert.ToDouble(ParamsListViewer.Items[2].SubItems[2].Text.Replace(".", ",")),
				Convert.ToDouble(ParamsListViewer.Items[3].SubItems[2].Text.Replace(".", ",")),
				new double[]
				{
					Convert.ToDouble(ParamsListViewer.Items[4].SubItems[2].Text.Replace(".", ",")),
					Convert.ToDouble(ParamsListViewer.Items[5].SubItems[2].Text.Replace(".", ",")),
					Convert.ToDouble(ParamsListViewer.Items[6].SubItems[2].Text.Replace(".", ","))
				}
				);
			DoWork();
			CompleteFiParamsModelOptimize();
			MessageBox.Show(" вычисления выполнены");
		}
		private void CompleteFiParamsModelOptimize()
		{
			OptimizeParams_Fi opt = (OptimizeParams_Fi)obj;

			ParamsListViewer.Items[0].SubItems[1].Text = opt.IS0.ToString();
			ParamsListViewer.Items[0].SubItems[2].Text = opt.IS0.ToString();
			ParamsListViewer.Items[1].SubItems[1].Text = opt.F0.ToString();
			ParamsListViewer.Items[1].SubItems[2].Text = opt.F0.ToString();
			ParamsListViewer.Items[2].SubItems[1].Text = opt.R0.ToString();
			ParamsListViewer.Items[2].SubItems[2].Text = opt.R0.ToString();
			ParamsListViewer.Items[3].SubItems[1].Text = opt.IKF0.ToString();
			ParamsListViewer.Items[3].SubItems[2].Text = opt.IKF0.ToString();

			ParamsListViewer.Items[4].SubItems[1].Text = opt.FPAR0[0].ToString();
			ParamsListViewer.Items[4].SubItems[2].Text = opt.FPAR0[0].ToString();
			ParamsListViewer.Items[5].SubItems[1].Text = opt.FPAR0[1].ToString();
			ParamsListViewer.Items[5].SubItems[2].Text = opt.FPAR0[1].ToString();
			ParamsListViewer.Items[6].SubItems[1].Text = opt.FPAR0[2].ToString();
			ParamsListViewer.Items[6].SubItems[2].Text = opt.FPAR0[2].ToString();
			label1.Text = opt.Z.ToString();

			Err.Text = obj.OptimizeErr().ToString();
		}

		private void Perform_Click(object sender, EventArgs e)
		{
			d?.Invoke();
		}

		#endregion

		private void ЗагрузитьВАХToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				VAX.ShowDialog();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка:" + ex);
			}
		}

		#region обработчики выбора модели

		private void InitOptimizeModel_SelectedIndexChanged(object sender, EventArgs e)
		{
			d = null;

			switch (InitOptimizeModel.SelectedIndex)
			{
				case 0:
					{
						d += OptimizeTwoParamsModel;
						break;
					}
				case 1:
					{
						d += OptimizeThreeParamsModel;
						break;
					}
				case 2:
					{
						d += OptimizeFourParamsModel;
						break;
					}
				case 3:
					{
						d += OptimizeFiParamsModel;
						break;
					}
				case 4:
					{
						d += null;
						break;
					}
			}
			InitParamsList();
		}

		private void InitParamsList()
		{
			for (int i = ParamsListViewer.Items.Count; i > 0; i--)
			{
				par[ParamsListViewer.Items[i - 1].SubItems[0].Text] = Convert.ToDouble(ParamsListViewer.Items[i - 1].SubItems[2].Text);
			}
			ParamsListViewer.Items.Clear();
			switch (InitOptimizeModel.SelectedIndex)
			{
				case 0:
					{
						ParamsListViewer.Items.Add(new ListViewItem(new string[] { "Is", par["Is"].ToString(), par["Is"].ToString() }));
						ParamsListViewer.Items.Add(new ListViewItem(new string[] { "fi", par["fi"].ToString(), par["fi"].ToString() }));
						break;
					}
				case 1:
					{
						ParamsListViewer.Items.Add(new ListViewItem(new string[] { "Is", par["Is"].ToString(), par["Is"].ToString() }));
						ParamsListViewer.Items.Add(new ListViewItem(new string[] { "fi", par["fi"].ToString(), par["fi"].ToString() }));
						ParamsListViewer.Items.Add(new ListViewItem(new string[] { "R", par["R"].ToString(), par["R"].ToString() }));
						break;
					}
				case 2:
					{
						ParamsListViewer.Items.Add(new ListViewItem(new string[] { "Is", par["Is"].ToString(), par["Is"].ToString() }));
						ParamsListViewer.Items.Add(new ListViewItem(new string[] { "fi", par["fi"].ToString(), par["fi"].ToString() }));
						ParamsListViewer.Items.Add(new ListViewItem(new string[] { "R", par["R"].ToString(), par["R"].ToString() }));
						ParamsListViewer.Items.Add(new ListViewItem(new string[] { "IKF", par["IKF"].ToString(), par["IKF"].ToString() }));
						break;
					}
				case 3:
					{

						ParamsListViewer.Items.Add(new ListViewItem(new string[] { "Is", par["Is"].ToString(), par["Is"].ToString() }));
						ParamsListViewer.Items.Add(new ListViewItem(new string[] { "fi", par["fi"].ToString(), par["fi"].ToString() }));
						ParamsListViewer.Items.Add(new ListViewItem(new string[] { "R", par["R"].ToString(), par["R"].ToString() }));
						ParamsListViewer.Items.Add(new ListViewItem(new string[] { "IKF", par["IKF"].ToString(), par["IKF"].ToString() }));

						ParamsListViewer.Items.Add(new ListViewItem(new string[] { "a1", par["a1"].ToString(), par["a1"].ToString() }));
						ParamsListViewer.Items.Add(new ListViewItem(new string[] { "a2", par["a2"].ToString(), par["a2"].ToString() }));
						break;
					}
			}
		}

		#region обработчики изменения поля в listview
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

			if (e.KeyChar == 'e' || e.KeyChar == 'E' || e.KeyChar == 'е' || e.KeyChar == 'E')
			{
				if ((sender as TextBox).Text.Contains("e") || (sender as TextBox).Text.Contains("E") || (sender as TextBox).Text.Contains("е") || (sender as TextBox).Text.Contains("Е")) e.Handled = true;
				else e.Handled = false;
			}

			if (e.KeyChar == 8 || e.KeyChar == '-')
			{
				e.Handled = false;
			}
		}
		#endregion
		#endregion

		#region обработчики кнопок пункта меню - ВАХ

		private void ИзмереннаяToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Graph graph = new Graph(VAX.U, VAX.I, "ВАХ", "U", "I", Color.Brown, graphs);
			graph.Owner = this;
			graph.Show();
			graphs.Add(graph);
		}

		private void АппроксимированнаяToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Graph graph = new Graph(((IVAX)obj).GetU(), ((IVAX)obj).GetI(), "ВАХ(аппроксимированная)", "U", "I", Color.Black, graphs)
			{
				Owner = this
			};
			graph.Show();
			graphs.Add(graph);
		}

		private void ПогрешностьПоТокуToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			double[] I = ((IInaccuracy)obj).InaccuracyOfCUrrent();

			SCO_ABS.Text = ((IInaccuracy)obj).GetSCO_ABS_cur().ToString();
			SCO_REL.Text = ((IInaccuracy)obj).GetSCO_REL_cur().ToString();

			Graph graph = new Graph(VAX.U, I, "погрешность", "U", "%", Color.Green, graphs);
			graph.Owner = this;
			graph.Show();
			graphs.Add(graph);
		}

		private void ПогрешностьПоНапряжениюToolStripMenuItem_Click(object sender, EventArgs e)
		{
			double[] U = ((IInaccuracy)obj).InaccuracyOfVoltage();

			SCO_ABS.Text = ((IInaccuracy)obj).GetSCO_ABS_vol().ToString();
			SCO_REL.Text = ((IInaccuracy)obj).GetSCO_REL_vol().ToString();

			Graph graph = new Graph(VAX.I, U, "погрешность", "I", "%", Color.Red, graphs);
			graph.Owner = this;
			graph.Show();
			graphs.Add(graph);
		}

		#endregion

		private void IsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			/*double[] Is = obj.DISY();
			int length = Is.Length;
			double step = 0;
			double[] x = new double[2000];
			double[] y = new double[2000];

			if (length > 2000)
			{
				step = length / 2000;
				for (int i = 0; i < 2000; i += 1)
				{
					x[i] = i * step;
					y[i] = Is[Convert.ToInt32(i * step)];
				}

			}
			else
			{
				x = new double[length];
				for (int i = 0; i < x.Length; i++) { x[i] = i; }
				y = Is;
			}


			Graph graph = new Graph(x, y, "dIs от n", "n", "Is", graphs)
			{
				Owner = this
			};
			graph.Show();
			graphs.Add(graph);*/
		}
		private void FiToolStripMenuItem_Click(object sender, EventArgs e)
		{
			/*double[] fi = obj.DFY();
			int length = fi.Length;
			double step = 0;
			double[] x = new double[2000];
			double[] y = new double[2000];

			if (length > 2000)
			{
				step = length / 2000;
				for (int i = 0; i < 2000; i += 1)
				{
					x[i] = i * step;
					y[i] = fi[Convert.ToInt32(i * step)];
				}

			}
			else
			{
				x = new double[length];
				for (int i = 0; i < x.Length; i++) { x[i] = i; }
				y = fi;
			}

			Graph graph = new Graph(x, y, "dFi от n", "n", "Fi", graphs)
			{
				Owner = this
			};
			graph.Show();
			graphs.Add(graph);*/
		}
		private void syToolStripMenuItem_Click(object sender, EventArgs e)
		{
			double[] S = obj.Error();
			double[] arg = obj.Y();
			int length = S.Length;
			double step = 0;
			double[] x = new double[2000];
			double[] y = new double[2000];

			if (length > 2000)
			{
				step = (double)length / 2000;
				for (int i = 0; i < 1999; i += 1)
				{
					x[i] = arg[Convert.ToInt32(i * step)];
					y[i] = S[Convert.ToInt32(i * step)];
				}
				x[1999] = arg[arg.Length-1];
				y[1999] = S[S.Length-1];
			}
			else
			{
				x = arg;
				y = S;
			}

			Graph graph = new Graph(x, y, "s от n", "n", "S", graphs)
			{
				Owner = this
			};
			graph.Show();
			graphs.Add(graph);
		}
	}
}