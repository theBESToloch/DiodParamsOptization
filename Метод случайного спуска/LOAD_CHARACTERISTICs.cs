using System;
using System.IO;
using System.Windows.Forms;

namespace Метод_случайного_спуска
{
    public partial class LOAD_CHARACTERISTICs : Form
    {
        private string Path_To_I = "", Path_To_U = "";
		private int len;
		private double[] UU, II;

		public int Len { get => len; set => len = value; }
		public double[] U { get => UU; set => UU = value; }
		public double[] I { get => II; set => II = value; }

		public LOAD_CHARACTERISTICs(String pathToI, String pathToU)
        {
            InitializeComponent();

			Path_To_I = pathToI;
			Path_To_U = pathToU;

			PathToI.Text = pathToI;
            PathToU.Text = pathToU;
        }

        private void open_I_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = PathToI.Text;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PathToI.Text = openFileDialog1.FileName;
            }
        }

        private void open_U_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = PathToU.Text;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PathToU.Text = openFileDialog1.FileName;
            }
        }

		private void params_cancel_Click(object sender, EventArgs e)
		{
			LOAD_CHARACTERISTICs.ActiveForm.Close();
		}

		private void params_save_Click(object sender, EventArgs e)
        {
			error.Text = "";
			if (LoadCharacteristics())
			{
				LOAD_CHARACTERISTICs.ActiveForm.Close();
			}
        }


		private bool LoadCharacteristics() {

			try {
				Path_To_I = PathToI.Text.ToString();
				Path_To_U = PathToU.Text.ToString();

				string[] BaxI, BaxU;

				BaxI = File.ReadAllLines(Path_To_I);
				BaxU = File.ReadAllLines(Path_To_U);

				if (BaxI.Length == BaxU.Length) len = BaxI.Length;
				else { error.Text = "массивы разной длины.";return false; }

				UU = new double[len];
				II = new double[len];

				for (int i = 0; i < len; i++)
				{
					UU[i] = Convert.ToDouble(BaxU[i].Replace('.', ','));
					II[i] = Convert.ToDouble(BaxI[i].Replace('.', ',').Replace("*10^", "e"));
				}
			}
			catch (FormatException fe)
			{
				error.Text = "Не удалось преобразовать строку в массиве." + fe.ToString(); return false;
			}
			catch(Exception e) {
				error.Text = "Неудалось загрузить массивы." + e.ToString(); return false;
			}
			return true;
		}
	}
}
