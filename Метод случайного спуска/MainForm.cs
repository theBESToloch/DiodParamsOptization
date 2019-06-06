using System;
using System.Collections.Generic;
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

		public MainForm()
		{
			InitializeComponent();

			VAX = new LOAD_CHARACTERISTICs("", "");
			graphs = new List<Graph>();
			par = new Dictionary<string, double>
			{
				{ "IKF", 0.001425 },
				{ "R", 24.064 },
				{ "fi", 38.536E-3 },
				{ "Is", 1.535E-6 },
				{ "a1", 4.19E-3 },
				{ "a2", 1.04E-3 }
			};

			ParamsListViewer.Items.Add(new ListViewItem(new string[] { "Is", par["Is"].ToString(), par["Is"].ToString() }));
			ParamsListViewer.Items.Add(new ListViewItem(new string[] { "fi", par["fi"].ToString(), par["fi"].ToString() }));

			d += OptimizeTwoParamsModel;
		}

		#region вычисления

		private void DoWork()
		{
			try
			{
				obj.DoOptimize(Convert.ToInt32(nSteps.Text));
			}
			catch(Exception e)
			{
				Console.WriteLine("Ошибка вычислений" + e);
			}

		}

		private void OptimizeTwoParamsModel()
		{
			if (obj == null || obj.GetType() != typeof(Optimize2Params_fi_1))
			{
				obj = new Optimize2Params_fi_1(VAX.I, VAX.U,
					Convert.ToDouble(ParamsListViewer.Items[0].SubItems[2].Text.Replace(".", ",")),
					Convert.ToDouble(ParamsListViewer.Items[1].SubItems[2].Text.Replace(".", ",")));
			}
			DoWork();
			CompleteTwoParamsModelOptimize();
			MessageBox.Show(" вычисления выполнены");
		}
		private void CompleteTwoParamsModelOptimize()
		{
			Optimize2Params_fi_1 opt = (Optimize2Params_fi_1)obj;

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
			if (!(obj != null && obj.GetType() == typeof(OptimizeParams_Is_and_Fi_2)))
				obj = new OptimizeParams_Is_and_Fi_2(VAX.I, VAX.U,
				Convert.ToDouble(ParamsListViewer.Items[0].SubItems[2].Text.Replace(".", ",")),
				Convert.ToDouble(ParamsListViewer.Items[1].SubItems[2].Text.Replace(".", ",")),
				Convert.ToDouble(ParamsListViewer.Items[2].SubItems[2].Text.Replace(".", ",")),
				Convert.ToDouble(ParamsListViewer.Items[3].SubItems[2].Text.Replace(".", ",")),
				new double[]
				{
					Convert.ToDouble(ParamsListViewer.Items[4].SubItems[2].Text.Replace(".", ",")),
					Convert.ToDouble(ParamsListViewer.Items[5].SubItems[2].Text.Replace(".", ",")),
				}
				);
			DoWork();
			CompleteFiParamsModelOptimize();
			MessageBox.Show(" вычисления выполнены");
		}
		private void CompleteFiParamsModelOptimize()
		{
			OptimizeParams_Is_and_Fi_2 opt = (OptimizeParams_Is_and_Fi_2)obj;

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
			Graph graph = new Graph(VAX.U, VAX.I, "ВАХ", "U", "I", graphs);
			graph.Owner = this;
			graph.Show();
			graphs.Add(graph);
		}

		private void АппроксимированнаяToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Graph graph = new Graph(((IVAX)obj).GetU(), ((IVAX)obj).GetI(), "ВАХ(аппроксимированная)", "U", "I", graphs)
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

			Graph graph = new Graph(VAX.U, I, "погрешность", "U", "%", graphs);
			graph.Owner = this;
			graph.Show();
			graphs.Add(graph);
		}

		private void ПогрешностьПоНапряжениюToolStripMenuItem_Click(object sender, EventArgs e)
		{
			double[] U = ((IInaccuracy)obj).InaccuracyOfVoltage();

			SCO_ABS.Text = ((IInaccuracy)obj).GetSCO_ABS_vol().ToString();
			SCO_REL.Text = ((IInaccuracy)obj).GetSCO_REL_vol().ToString();

			Graph graph = new Graph(VAX.I, U, "погрешность", "I", "%", graphs);
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
				x[1999] = arg[arg.Length - 1];
				y[1999] = S[S.Length - 1];
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

		OptimizeParams_Is_and_Fi_2[] optimize;
		int count = 0;
		private void PerformAllFiftyPercentMenuItem2_Click(object sender, EventArgs e)
		{
			if (optimize == null)
			{
				count = ParamsListViewer.Items.Count;

				//массив параметров
				var param = new Dictionary<string, double>
				{
					{ "IKF", Convert.ToDouble(ParamsListViewer.Items[3].SubItems[2].Text.Replace(".", ",")) },
					{ "R",   Convert.ToDouble(ParamsListViewer.Items[2].SubItems[2].Text.Replace(".", ",")) },
					{ "fi",  Convert.ToDouble(ParamsListViewer.Items[1].SubItems[2].Text.Replace(".", ",")) },
					{ "Is",  Convert.ToDouble(ParamsListViewer.Items[0].SubItems[2].Text.Replace(".", ",")) },
					{ "a1",  Convert.ToDouble(ParamsListViewer.Items[4].SubItems[2].Text.Replace(".", ",")) },
					{ "a2",  Convert.ToDouble(ParamsListViewer.Items[5].SubItems[2].Text.Replace(".", ",")) }
				};
				//массив приближений параметров
				var delparam = new Dictionary<string, double>
				{
					{ "dIKF", Convert.ToDouble(ParamsListViewer.Items[3].SubItems[2].Text.Replace(".", ","))/2 },
					{ "dR",   Convert.ToDouble(ParamsListViewer.Items[2].SubItems[2].Text.Replace(".", ","))/2 },
					{ "dfi",  Convert.ToDouble(ParamsListViewer.Items[1].SubItems[2].Text.Replace(".", ","))/2 },
					{ "dIs",  Convert.ToDouble(ParamsListViewer.Items[0].SubItems[2].Text.Replace(".", ","))/2 },
					{ "da1",  Convert.ToDouble(ParamsListViewer.Items[4].SubItems[2].Text.Replace(".", ","))/2 },
					{ "da2",  Convert.ToDouble(ParamsListViewer.Items[5].SubItems[2].Text.Replace(".", ","))/2 }
				};

				double[,] mas = new double[Convert.ToInt16(Math.Pow(2, count)), count];
				int aa = Convert.ToInt16(Math.Pow(2, count)) * 2 - 1;  // *2 нужно чтобы была первая единица, иначе если будет 0, в аа массив будет на 1 меньше 
																	   //двумерная двуричная матрица
				for (int j = 0; j < Convert.ToInt16(Math.Pow(2, count)); j++)
				{
					string a = Convert.ToString(aa, 2);
					for (int i = 0; i < count; i++)
					{
						if (a[count - i] == '1') mas[j, i] = 1;
						else mas[j, i] = -1;
					}
					aa--;
				}


				int len = Convert.ToInt16(Math.Pow(2, count)) > 10 ? 10 : Convert.ToInt16(Math.Pow(2, count));
				optimize = new OptimizeParams_Is_and_Fi_2[len];
				for (int i = 0; i < len; i++)
					optimize[i] = new OptimizeParams_Is_and_Fi_2(
						VAX.I,
						VAX.U,
						param["Is"]  + delparam["dIs"]  * mas[i, 0],
						param["fi"]  + delparam["dfi"]  * mas[i, 1],
						param["R"]   + delparam["dR"]   * mas[i, 2],
						param["IKF"] + delparam["dIKF"] * mas[i, 3],
						new double[]
						{
						param["a1"] + delparam["da1"] * mas[i, 4],
						param["a2"] + delparam["da2"] * mas[i, 5],
						}
					);

			}

			for (int i = 0; i < optimize.Length; i++)
			{
				obj = optimize[i];
				DoWork();
			}
		}

		private void sОтNToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(optimize != null)
			{
				List<double[]> x = new List<double[]>();
				List<double[]> y = new List<double[]>();

				foreach(OptimizeParams_Is_and_Fi_2 opf in optimize)
				{
					x.Add(opf.Y());
					y.Add(opf.Error());
				}

				Graph graph = new Graph(x, y, "S от n", "n", "S", graphs);
				graph.Owner = this;
				graph.Show();
				graphs.Add(graph);
			}
		}

		private void isОтNToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (optimize != null)
			{
				List<double[]> x = new List<double[]>();
				List<double[]> y = new List<double[]>();

				foreach (OptimizeParams_Is_and_Fi_2 opf in optimize)
				{
					x.Add(opf.Y());
					y.Add(opf.ISY());
				}

				Graph graph = new Graph(x, y, "Is от n", "n", "Is", graphs);
				graph.Owner = this;
				graph.Show();
				graphs.Add(graph);
			}
		}

		private void fiОтNToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (optimize != null)
			{
				List<double[]> x = new List<double[]>();
				List<double[]> y = new List<double[]>();

				foreach (OptimizeParams_Is_and_Fi_2 opf in optimize)
				{
					x.Add(opf.Y());
					y.Add(opf.FY());
				}

				Graph graph = new Graph(x, y, "f от n", "n", "f", graphs);
				graph.Owner = this;
				graph.Show();
				graphs.Add(graph);
			}
		}
	}
}