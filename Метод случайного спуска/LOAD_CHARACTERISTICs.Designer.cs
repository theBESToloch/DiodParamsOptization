namespace Метод_случайного_спуска
{
    partial class LOAD_CHARACTERISTICs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.params_cancel = new System.Windows.Forms.Button();
			this.params_save = new System.Windows.Forms.Button();
			this.PathToU = new System.Windows.Forms.TextBox();
			this.PathToI = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.open_U = new System.Windows.Forms.Button();
			this.open_I = new System.Windows.Forms.Button();
			this.error = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// params_cancel
			// 
			this.params_cancel.Location = new System.Drawing.Point(366, 229);
			this.params_cancel.Name = "params_cancel";
			this.params_cancel.Size = new System.Drawing.Size(81, 30);
			this.params_cancel.TabIndex = 9;
			this.params_cancel.Text = "отмена";
			this.params_cancel.UseVisualStyleBackColor = true;
			this.params_cancel.Click += new System.EventHandler(this.params_cancel_Click);
			// 
			// params_save
			// 
			this.params_save.Location = new System.Drawing.Point(453, 193);
			this.params_save.Name = "params_save";
			this.params_save.Size = new System.Drawing.Size(156, 66);
			this.params_save.TabIndex = 8;
			this.params_save.Text = "применить";
			this.params_save.UseVisualStyleBackColor = true;
			this.params_save.Click += new System.EventHandler(this.params_save_Click);
			// 
			// PathToU
			// 
			this.PathToU.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.PathToU.ForeColor = System.Drawing.Color.Navy;
			this.PathToU.Location = new System.Drawing.Point(25, 128);
			this.PathToU.Name = "PathToU";
			this.PathToU.Size = new System.Drawing.Size(492, 23);
			this.PathToU.TabIndex = 16;
			this.PathToU.Text = "U.txt";
			// 
			// PathToI
			// 
			this.PathToI.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.PathToI.ForeColor = System.Drawing.Color.Navy;
			this.PathToI.Location = new System.Drawing.Point(25, 79);
			this.PathToI.Name = "PathToI";
			this.PathToI.Size = new System.Drawing.Size(492, 23);
			this.PathToI.TabIndex = 15;
			this.PathToI.Text = "I.txt";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.ForeColor = System.Drawing.Color.Navy;
			this.label2.Location = new System.Drawing.Point(22, 106);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(71, 19);
			this.label2.TabIndex = 14;
			this.label2.Text = "Путь U:";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.ForeColor = System.Drawing.Color.Navy;
			this.label3.Location = new System.Drawing.Point(22, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(81, 24);
			this.label3.TabIndex = 12;
			this.label3.Text = "ВАХ:";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.ForeColor = System.Drawing.Color.Navy;
			this.label1.Location = new System.Drawing.Point(22, 52);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(81, 24);
			this.label1.TabIndex = 13;
			this.label1.Text = "Путь I:";
			// 
			// open_U
			// 
			this.open_U.Location = new System.Drawing.Point(523, 128);
			this.open_U.Name = "open_U";
			this.open_U.Size = new System.Drawing.Size(86, 23);
			this.open_U.TabIndex = 10;
			this.open_U.Text = "открыть";
			this.open_U.UseVisualStyleBackColor = true;
			this.open_U.Click += new System.EventHandler(this.open_U_Click);
			// 
			// open_I
			// 
			this.open_I.Location = new System.Drawing.Point(523, 79);
			this.open_I.Name = "open_I";
			this.open_I.Size = new System.Drawing.Size(86, 23);
			this.open_I.TabIndex = 11;
			this.open_I.Text = "открыть";
			this.open_I.UseVisualStyleBackColor = true;
			this.open_I.Click += new System.EventHandler(this.open_I_Click);
			// 
			// error
			// 
			this.error.AutoSize = true;
			this.error.Location = new System.Drawing.Point(29, 179);
			this.error.Name = "error";
			this.error.Size = new System.Drawing.Size(0, 13);
			this.error.TabIndex = 17;
			// 
			// LOAD_CHARACTERISTICs
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(621, 271);
			this.Controls.Add(this.error);
			this.Controls.Add(this.PathToU);
			this.Controls.Add(this.PathToI);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.open_U);
			this.Controls.Add(this.open_I);
			this.Controls.Add(this.params_cancel);
			this.Controls.Add(this.params_save);
			this.Name = "LOAD_CHARACTERISTICs";
			this.Text = "Загрузить ВАХ";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button params_cancel;
        private System.Windows.Forms.Button params_save;
        private System.Windows.Forms.TextBox PathToU;
        private System.Windows.Forms.TextBox PathToI;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button open_U;
        private System.Windows.Forms.Button open_I;
		private System.Windows.Forms.Label error;
	}
}