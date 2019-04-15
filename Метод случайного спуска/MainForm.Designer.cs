/*
 * Created by SharpDevelop.
 * User: 01
 * Date: 27.11.2015
 * Time: 22:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Метод_случайного_спуска
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nSteps;
        private System.Windows.Forms.Button button2;
        private ZedGraph.ZedGraphControl Graffik;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.label3 = new System.Windows.Forms.Label();
			this.nSteps = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.Graffik = new ZedGraph.ZedGraphControl();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.загрузитьВАХToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.графикToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.вАХToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.измереннаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.аппроксимированнаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.погрешностиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.погрешностьПоТокуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.очститьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.масштабToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lnXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lnYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.par_Is = new System.Windows.Forms.Label();
			this.par_fi = new System.Windows.Forms.Label();
			this.par_Is1 = new System.Windows.Forms.Label();
			this.par_fi1 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.SCO_ABS = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.SCO_REL = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.par_R = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.ForeColor = System.Drawing.Color.Navy;
			this.label3.Location = new System.Drawing.Point(-3, 29);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(121, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Кол-во шагов:";
			// 
			// nSteps
			// 
			this.nSteps.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.nSteps.ForeColor = System.Drawing.Color.Navy;
			this.nSteps.Location = new System.Drawing.Point(-1, 55);
			this.nSteps.Name = "nSteps";
			this.nSteps.Size = new System.Drawing.Size(119, 23);
			this.nSteps.TabIndex = 5;
			this.nSteps.Text = "100000";
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.White;
			this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.button2.Location = new System.Drawing.Point(0, 84);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(134, 34);
			this.button2.TabIndex = 9;
			this.button2.Text = "Расчет 2-х парам. модель";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// Graffik
			// 
			this.Graffik.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Graffik.IsZoomOnMouseCenter = true;
			this.Graffik.Location = new System.Drawing.Point(537, 27);
			this.Graffik.Name = "Graffik";
			this.Graffik.ScrollGrace = 0D;
			this.Graffik.ScrollMaxX = 0D;
			this.Graffik.ScrollMaxY = 0D;
			this.Graffik.ScrollMaxY2 = 0D;
			this.Graffik.ScrollMinX = 0D;
			this.Graffik.ScrollMinY = 0D;
			this.Graffik.ScrollMinY2 = 0D;
			this.Graffik.Size = new System.Drawing.Size(868, 662);
			this.Graffik.TabIndex = 14;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.графикToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1417, 24);
			this.menuStrip1.TabIndex = 40;
			this.menuStrip1.TabStop = true;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// файлToolStripMenuItem
			// 
			this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьВАХToolStripMenuItem,
            this.открытьToolStripMenuItem});
			this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
			this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.файлToolStripMenuItem.Text = "файл";
			// 
			// загрузитьВАХToolStripMenuItem
			// 
			this.загрузитьВАХToolStripMenuItem.Name = "загрузитьВАХToolStripMenuItem";
			this.загрузитьВАХToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.загрузитьВАХToolStripMenuItem.Text = "Загрузить ВАХ";
			this.загрузитьВАХToolStripMenuItem.Click += new System.EventHandler(this.загрузитьВАХToolStripMenuItem_Click);
			// 
			// открытьToolStripMenuItem
			// 
			this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
			this.открытьToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.открытьToolStripMenuItem.Text = "открыть";
			// 
			// графикToolStripMenuItem
			// 
			this.графикToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вАХToolStripMenuItem,
            this.очститьToolStripMenuItem,
            this.масштабToolStripMenuItem});
			this.графикToolStripMenuItem.Name = "графикToolStripMenuItem";
			this.графикToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
			this.графикToolStripMenuItem.Text = "Графики";
			// 
			// вАХToolStripMenuItem
			// 
			this.вАХToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.измереннаяToolStripMenuItem,
            this.аппроксимированнаяToolStripMenuItem,
            this.погрешностиToolStripMenuItem,
            this.погрешностьПоТокуToolStripMenuItem});
			this.вАХToolStripMenuItem.Name = "вАХToolStripMenuItem";
			this.вАХToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
			this.вАХToolStripMenuItem.Text = "ВАХ";
			// 
			// измереннаяToolStripMenuItem
			// 
			this.измереннаяToolStripMenuItem.Name = "измереннаяToolStripMenuItem";
			this.измереннаяToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
			this.измереннаяToolStripMenuItem.Text = "измеренная";
			this.измереннаяToolStripMenuItem.Click += new System.EventHandler(this.измереннаяToolStripMenuItem_Click);
			// 
			// аппроксимированнаяToolStripMenuItem
			// 
			this.аппроксимированнаяToolStripMenuItem.Name = "аппроксимированнаяToolStripMenuItem";
			this.аппроксимированнаяToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
			this.аппроксимированнаяToolStripMenuItem.Text = "Аппроксимированная";
			this.аппроксимированнаяToolStripMenuItem.Click += new System.EventHandler(this.аппроксимированнаяToolStripMenuItem_Click);
			// 
			// погрешностиToolStripMenuItem
			// 
			this.погрешностиToolStripMenuItem.Name = "погрешностиToolStripMenuItem";
			this.погрешностиToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
			this.погрешностиToolStripMenuItem.Text = "Погрешности по напряжению";
			this.погрешностиToolStripMenuItem.Click += new System.EventHandler(this.погрешностьПоНапряжениюToolStripMenuItem_Click);
			// 
			// погрешностьПоТокуToolStripMenuItem
			// 
			this.погрешностьПоТокуToolStripMenuItem.Name = "погрешностьПоТокуToolStripMenuItem";
			this.погрешностьПоТокуToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
			this.погрешностьПоТокуToolStripMenuItem.Text = "Погрешность по току";
			this.погрешностьПоТокуToolStripMenuItem.Click += new System.EventHandler(this.погрешностьПоТокуToolStripMenuItem_Click_1);
			// 
			// очститьToolStripMenuItem
			// 
			this.очститьToolStripMenuItem.Name = "очститьToolStripMenuItem";
			this.очститьToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
			this.очститьToolStripMenuItem.Text = "Очистить";
			this.очститьToolStripMenuItem.Click += new System.EventHandler(this.очститьToolStripMenuItem_Click);
			// 
			// масштабToolStripMenuItem
			// 
			this.масштабToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lnXToolStripMenuItem,
            this.lnYToolStripMenuItem});
			this.масштабToolStripMenuItem.Name = "масштабToolStripMenuItem";
			this.масштабToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
			this.масштабToolStripMenuItem.Text = "масштаб";
			// 
			// lnXToolStripMenuItem
			// 
			this.lnXToolStripMenuItem.Name = "lnXToolStripMenuItem";
			this.lnXToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
			this.lnXToolStripMenuItem.Text = "log(X)";
			this.lnXToolStripMenuItem.Click += new System.EventHandler(this.button4_Click);
			// 
			// lnYToolStripMenuItem
			// 
			this.lnYToolStripMenuItem.Name = "lnYToolStripMenuItem";
			this.lnYToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
			this.lnYToolStripMenuItem.Text = "log(Y)";
			this.lnYToolStripMenuItem.Click += new System.EventHandler(this.button5_Click);
			// 
			// par_Is
			// 
			this.par_Is.AutoSize = true;
			this.par_Is.Location = new System.Drawing.Point(20, 204);
			this.par_Is.Name = "par_Is";
			this.par_Is.Size = new System.Drawing.Size(15, 13);
			this.par_Is.TabIndex = 41;
			this.par_Is.Text = "Is";
			// 
			// par_fi
			// 
			this.par_fi.AutoSize = true;
			this.par_fi.Location = new System.Drawing.Point(20, 237);
			this.par_fi.Name = "par_fi";
			this.par_fi.Size = new System.Drawing.Size(12, 13);
			this.par_fi.TabIndex = 41;
			this.par_fi.Text = "fi";
			// 
			// par_Is1
			// 
			this.par_Is1.AutoSize = true;
			this.par_Is1.Location = new System.Drawing.Point(41, 204);
			this.par_Is1.Name = "par_Is1";
			this.par_Is1.Size = new System.Drawing.Size(13, 13);
			this.par_Is1.TabIndex = 42;
			this.par_Is1.Text = "1";
			// 
			// par_fi1
			// 
			this.par_fi1.AutoSize = true;
			this.par_fi1.Location = new System.Drawing.Point(41, 237);
			this.par_fi1.Name = "par_fi1";
			this.par_fi1.Size = new System.Drawing.Size(13, 13);
			this.par_fi1.TabIndex = 42;
			this.par_fi1.Text = "1";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(145, 171);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(138, 13);
			this.label9.TabIndex = 44;
			this.label9.Text = "Начальные приближения:";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(148, 204);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(135, 20);
			this.textBox1.TabIndex = 45;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(148, 237);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(135, 20);
			this.textBox2.TabIndex = 45;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(145, 60);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(13, 13);
			this.label1.TabIndex = 47;
			this.label1.Text = "0";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 171);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(122, 13);
			this.label2.TabIndex = 48;
			this.label2.Text = "Значение параметров:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(234, 427);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(96, 13);
			this.label7.TabIndex = 57;
			this.label7.Text = "СКО, абсолютное";
			// 
			// SCO_ABS
			// 
			this.SCO_ABS.AutoSize = true;
			this.SCO_ABS.Location = new System.Drawing.Point(429, 427);
			this.SCO_ABS.Name = "SCO_ABS";
			this.SCO_ABS.Size = new System.Drawing.Size(13, 13);
			this.SCO_ABS.TabIndex = 53;
			this.SCO_ABS.Text = "1";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(234, 456);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(111, 13);
			this.label8.TabIndex = 59;
			this.label8.Text = "СКО, относительное";
			// 
			// SCO_REL
			// 
			this.SCO_REL.AutoSize = true;
			this.SCO_REL.Location = new System.Drawing.Point(429, 456);
			this.SCO_REL.Name = "SCO_REL";
			this.SCO_REL.Size = new System.Drawing.Size(13, 13);
			this.SCO_REL.TabIndex = 58;
			this.SCO_REL.Text = "1";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(148, 272);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(135, 20);
			this.textBox3.TabIndex = 62;
			// 
			// par_R
			// 
			this.par_R.AutoSize = true;
			this.par_R.Location = new System.Drawing.Point(41, 272);
			this.par_R.Name = "par_R";
			this.par_R.Size = new System.Drawing.Size(13, 13);
			this.par_R.TabIndex = 61;
			this.par_R.Text = "1";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(20, 272);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(15, 13);
			this.label6.TabIndex = 60;
			this.label6.Text = "R";
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.White;
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.button1.Location = new System.Drawing.Point(140, 84);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(134, 34);
			this.button1.TabIndex = 9;
			this.button1.Text = "Расчет 3-х парам. модель";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.GhostWhite;
			this.ClientSize = new System.Drawing.Size(1417, 701);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.par_R);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.SCO_REL);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.SCO_ABS);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.par_fi1);
			this.Controls.Add(this.par_Is1);
			this.Controls.Add(this.par_fi);
			this.Controls.Add(this.par_Is);
			this.Controls.Add(this.Graffik);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.nSteps);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem графикToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вАХToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem измереннаяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem аппроксимированнаяToolStripMenuItem;
        private System.Windows.Forms.Label par_Is;
        private System.Windows.Forms.Label par_fi;
        private System.Windows.Forms.Label par_Is1;
        private System.Windows.Forms.Label par_fi1;
        private System.Windows.Forms.ToolStripMenuItem очститьToolStripMenuItem;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ToolStripMenuItem загрузитьВАХToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem масштабToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lnXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lnYToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem погрешностиToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label SCO_ABS;
        private System.Windows.Forms.ToolStripMenuItem погрешностьПоТокуToolStripMenuItem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label SCO_REL;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label par_R;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button button1;
	}
}
