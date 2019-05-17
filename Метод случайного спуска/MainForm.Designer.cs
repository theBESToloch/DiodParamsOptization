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
			this.label3 = new System.Windows.Forms.Label();
			this.nSteps = new System.Windows.Forms.TextBox();
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
			this.рамкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.IsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.FiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.label1 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.SCO_ABS = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.SCO_REL = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.Err = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.initErr = new System.Windows.Forms.Label();
			this.InitOptimizeModel = new System.Windows.Forms.ComboBox();
			this.Perform = new System.Windows.Forms.Button();
			this.ParamsListViewer = new System.Windows.Forms.ListView();
			this.ParamName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.approximation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ошибкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.syToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.ForeColor = System.Drawing.Color.Navy;
			this.label3.Location = new System.Drawing.Point(25, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(121, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Кол-во шагов:";
			// 
			// nSteps
			// 
			this.nSteps.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.nSteps.ForeColor = System.Drawing.Color.Navy;
			this.nSteps.Location = new System.Drawing.Point(27, 50);
			this.nSteps.Name = "nSteps";
			this.nSteps.Size = new System.Drawing.Size(119, 23);
			this.nSteps.TabIndex = 5;
			this.nSteps.Text = "100000";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.графикToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(440, 24);
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
			this.загрузитьВАХToolStripMenuItem.Click += new System.EventHandler(this.ЗагрузитьВАХToolStripMenuItem_Click);
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
            this.рамкаToolStripMenuItem,
            this.ошибкаToolStripMenuItem});
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
			this.вАХToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.вАХToolStripMenuItem.Text = "ВАХ";
			// 
			// измереннаяToolStripMenuItem
			// 
			this.измереннаяToolStripMenuItem.Name = "измереннаяToolStripMenuItem";
			this.измереннаяToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
			this.измереннаяToolStripMenuItem.Text = "измеренная";
			this.измереннаяToolStripMenuItem.Click += new System.EventHandler(this.ИзмереннаяToolStripMenuItem_Click);
			// 
			// аппроксимированнаяToolStripMenuItem
			// 
			this.аппроксимированнаяToolStripMenuItem.Name = "аппроксимированнаяToolStripMenuItem";
			this.аппроксимированнаяToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
			this.аппроксимированнаяToolStripMenuItem.Text = "Аппроксимированная";
			this.аппроксимированнаяToolStripMenuItem.Click += new System.EventHandler(this.АппроксимированнаяToolStripMenuItem_Click);
			// 
			// погрешностиToolStripMenuItem
			// 
			this.погрешностиToolStripMenuItem.Name = "погрешностиToolStripMenuItem";
			this.погрешностиToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
			this.погрешностиToolStripMenuItem.Text = "Погрешности по напряжению";
			this.погрешностиToolStripMenuItem.Click += new System.EventHandler(this.ПогрешностьПоНапряжениюToolStripMenuItem_Click);
			// 
			// погрешностьПоТокуToolStripMenuItem
			// 
			this.погрешностьПоТокуToolStripMenuItem.Name = "погрешностьПоТокуToolStripMenuItem";
			this.погрешностьПоТокуToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
			this.погрешностьПоТокуToolStripMenuItem.Text = "Погрешность по току";
			this.погрешностьПоТокуToolStripMenuItem.Click += new System.EventHandler(this.ПогрешностьПоТокуToolStripMenuItem_Click_1);
			// 
			// рамкаToolStripMenuItem
			// 
			this.рамкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IsToolStripMenuItem,
            this.FiToolStripMenuItem});
			this.рамкаToolStripMenuItem.Name = "рамкаToolStripMenuItem";
			this.рамкаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.рамкаToolStripMenuItem.Text = "рамка";
			// 
			// IsToolStripMenuItem
			// 
			this.IsToolStripMenuItem.Name = "IsToolStripMenuItem";
			this.IsToolStripMenuItem.Size = new System.Drawing.Size(82, 22);
			this.IsToolStripMenuItem.Text = "Is";
			this.IsToolStripMenuItem.Click += new System.EventHandler(this.IsToolStripMenuItem_Click);
			// 
			// FiToolStripMenuItem
			// 
			this.FiToolStripMenuItem.Name = "FiToolStripMenuItem";
			this.FiToolStripMenuItem.Size = new System.Drawing.Size(82, 22);
			this.FiToolStripMenuItem.Text = "fi";
			this.FiToolStripMenuItem.Click += new System.EventHandler(this.FiToolStripMenuItem_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(173, 55);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(13, 13);
			this.label1.TabIndex = 47;
			this.label1.Text = "0";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(20, 493);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(96, 13);
			this.label7.TabIndex = 57;
			this.label7.Text = "СКО, абсолютное";
			// 
			// SCO_ABS
			// 
			this.SCO_ABS.AutoSize = true;
			this.SCO_ABS.Location = new System.Drawing.Point(215, 493);
			this.SCO_ABS.Name = "SCO_ABS";
			this.SCO_ABS.Size = new System.Drawing.Size(13, 13);
			this.SCO_ABS.TabIndex = 53;
			this.SCO_ABS.Text = "1";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(20, 522);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(111, 13);
			this.label8.TabIndex = 59;
			this.label8.Text = "СКО, относительное";
			// 
			// SCO_REL
			// 
			this.SCO_REL.AutoSize = true;
			this.SCO_REL.Location = new System.Drawing.Point(215, 522);
			this.SCO_REL.Name = "SCO_REL";
			this.SCO_REL.Size = new System.Drawing.Size(13, 13);
			this.SCO_REL.TabIndex = 58;
			this.SCO_REL.Text = "1";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(19, 462);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(19, 13);
			this.label4.TabIndex = 69;
			this.label4.Text = "err";
			// 
			// Err
			// 
			this.Err.AutoSize = true;
			this.Err.Location = new System.Drawing.Point(214, 462);
			this.Err.Name = "Err";
			this.Err.Size = new System.Drawing.Size(13, 13);
			this.Err.TabIndex = 68;
			this.Err.Text = "1";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(19, 433);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(35, 13);
			this.label11.TabIndex = 67;
			this.label11.Text = "init err";
			// 
			// initErr
			// 
			this.initErr.AutoSize = true;
			this.initErr.Location = new System.Drawing.Point(214, 433);
			this.initErr.Name = "initErr";
			this.initErr.Size = new System.Drawing.Size(13, 13);
			this.initErr.TabIndex = 66;
			this.initErr.Text = "1";
			// 
			// InitOptimizeModel
			// 
			this.InitOptimizeModel.FormattingEnabled = true;
			this.InitOptimizeModel.Items.AddRange(new object[] {
            "2-х параметрическая модель",
            "3-х параметрическая модель",
            "4-х параметрическая модель",
            "замена f полиномом"});
			this.InitOptimizeModel.Location = new System.Drawing.Point(28, 79);
			this.InitOptimizeModel.Name = "InitOptimizeModel";
			this.InitOptimizeModel.Size = new System.Drawing.Size(347, 21);
			this.InitOptimizeModel.TabIndex = 70;
			this.InitOptimizeModel.Text = "2-х параметрическая модель";
			this.InitOptimizeModel.SelectedIndexChanged += new System.EventHandler(this.InitOptimizeModel_SelectedIndexChanged);
			// 
			// Perform
			// 
			this.Perform.Location = new System.Drawing.Point(378, 79);
			this.Perform.Name = "Perform";
			this.Perform.Size = new System.Drawing.Size(53, 21);
			this.Perform.TabIndex = 71;
			this.Perform.Text = "расчет";
			this.Perform.UseVisualStyleBackColor = true;
			this.Perform.Click += new System.EventHandler(this.Perform_Click);
			// 
			// ParamsListViewer
			// 
			this.ParamsListViewer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ParamName,
            this.Value,
            this.approximation});
			this.ParamsListViewer.Location = new System.Drawing.Point(28, 138);
			this.ParamsListViewer.Name = "ParamsListViewer";
			this.ParamsListViewer.Size = new System.Drawing.Size(403, 190);
			this.ParamsListViewer.TabIndex = 72;
			this.ParamsListViewer.UseCompatibleStateImageBehavior = false;
			this.ParamsListViewer.View = System.Windows.Forms.View.Details;
			this.ParamsListViewer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ParamsListViewer_MouseDown);
			// 
			// ParamName
			// 
			this.ParamName.Text = "Параметр";
			this.ParamName.Width = 64;
			// 
			// Value
			// 
			this.Value.Text = "Значение";
			this.Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.Value.Width = 185;
			// 
			// approximation
			// 
			this.approximation.Text = "Начальное приближение";
			this.approximation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.approximation.Width = 148;
			// 
			// ошибкаToolStripMenuItem
			// 
			this.ошибкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.syToolStripMenuItem});
			this.ошибкаToolStripMenuItem.Name = "ошибкаToolStripMenuItem";
			this.ошибкаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.ошибкаToolStripMenuItem.Text = "ошибка";
			// 
			// syToolStripMenuItem
			// 
			this.syToolStripMenuItem.Name = "syToolStripMenuItem";
			this.syToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.syToolStripMenuItem.Text = "Sy";
			this.syToolStripMenuItem.Click += new System.EventHandler(this.syToolStripMenuItem_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.GhostWhite;
			this.ClientSize = new System.Drawing.Size(440, 559);
			this.Controls.Add(this.ParamsListViewer);
			this.Controls.Add(this.Perform);
			this.Controls.Add(this.InitOptimizeModel);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.Err);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.initErr);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.SCO_REL);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.SCO_ABS);
			this.Controls.Add(this.label1);
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
        private System.Windows.Forms.ToolStripMenuItem загрузитьВАХToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem погрешностиToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label SCO_ABS;
        private System.Windows.Forms.ToolStripMenuItem погрешностьПоТокуToolStripMenuItem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label SCO_REL;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label Err;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label initErr;
		private System.Windows.Forms.ComboBox InitOptimizeModel;
		private System.Windows.Forms.Button Perform;
		private System.Windows.Forms.ListView ParamsListViewer;
		private System.Windows.Forms.ColumnHeader ParamName;
		private System.Windows.Forms.ColumnHeader Value;
		private System.Windows.Forms.ColumnHeader approximation;
		private System.Windows.Forms.ToolStripMenuItem рамкаToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem IsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem FiToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ошибкаToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem syToolStripMenuItem;
	}
}
