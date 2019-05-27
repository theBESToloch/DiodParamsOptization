namespace GraphCreator
{
	partial class Graph
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.графикToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.масштабToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.logxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.logyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.СombineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.AddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.сохранитьSvgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.plotView1 = new OxyPlot.WindowsForms.PlotView();
			this.YMax = new System.Windows.Forms.TextBox();
			this.YMin = new System.Windows.Forms.TextBox();
			this.XMin = new System.Windows.Forms.TextBox();
			this.XMax = new System.Windows.Forms.TextBox();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.графикToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(581, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// графикToolStripMenuItem
			// 
			this.графикToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.масштабToolStripMenuItem,
            this.СombineToolStripMenuItem,
            this.AddToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.сохранитьSvgToolStripMenuItem});
			this.графикToolStripMenuItem.Name = "графикToolStripMenuItem";
			this.графикToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
			this.графикToolStripMenuItem.Text = "График";
			// 
			// масштабToolStripMenuItem
			// 
			this.масштабToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logxToolStripMenuItem,
            this.logyToolStripMenuItem});
			this.масштабToolStripMenuItem.Name = "масштабToolStripMenuItem";
			this.масштабToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			this.масштабToolStripMenuItem.Text = "масштаб";
			// 
			// logxToolStripMenuItem
			// 
			this.logxToolStripMenuItem.Name = "logxToolStripMenuItem";
			this.logxToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
			this.logxToolStripMenuItem.Text = "log(X)";
			this.logxToolStripMenuItem.Click += new System.EventHandler(this.LogxToolStripMenuItem_Click);
			// 
			// logyToolStripMenuItem
			// 
			this.logyToolStripMenuItem.Name = "logyToolStripMenuItem";
			this.logyToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
			this.logyToolStripMenuItem.Text = "log(Y)";
			this.logyToolStripMenuItem.Click += new System.EventHandler(this.LogyToolStripMenuItem_Click);
			// 
			// СombineToolStripMenuItem
			// 
			this.СombineToolStripMenuItem.Name = "СombineToolStripMenuItem";
			this.СombineToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			this.СombineToolStripMenuItem.Text = "совместить";
			this.СombineToolStripMenuItem.Click += new System.EventHandler(this.СombineToolStripMenuItem_Click);
			// 
			// AddToolStripMenuItem
			// 
			this.AddToolStripMenuItem.Name = "AddToolStripMenuItem";
			this.AddToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			this.AddToolStripMenuItem.Text = "добавить";
			this.AddToolStripMenuItem.Click += new System.EventHandler(this.AddToolStripMenuItem_Click);
			// 
			// сохранитьToolStripMenuItem
			// 
			this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
			this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			this.сохранитьToolStripMenuItem.Text = "сохранить";
			this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
			// 
			// сохранитьSvgToolStripMenuItem
			// 
			this.сохранитьSvgToolStripMenuItem.Name = "сохранитьSvgToolStripMenuItem";
			this.сохранитьSvgToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			this.сохранитьSvgToolStripMenuItem.Text = "сохранить svg";
			this.сохранитьSvgToolStripMenuItem.Click += new System.EventHandler(this.сохранитьSvgToolStripMenuItem_Click);
			// 
			// plotView1
			// 
			this.plotView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.plotView1.Location = new System.Drawing.Point(37, 22);
			this.plotView1.Name = "plotView1";
			this.plotView1.PanCursor = System.Windows.Forms.Cursors.Hand;
			this.plotView1.Size = new System.Drawing.Size(543, 460);
			this.plotView1.TabIndex = 2;
			this.plotView1.Text = "plotView1";
			this.plotView1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
			this.plotView1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
			this.plotView1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
			// 
			// YMax
			// 
			this.YMax.Location = new System.Drawing.Point(-1, 20);
			this.YMax.Name = "YMax";
			this.YMax.Size = new System.Drawing.Size(36, 20);
			this.YMax.TabIndex = 3;
			this.YMax.Leave += new System.EventHandler(this.YMax_Leave);
			// 
			// YMin
			// 
			this.YMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.YMin.Location = new System.Drawing.Point(0, 463);
			this.YMin.Name = "YMin";
			this.YMin.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.YMin.Size = new System.Drawing.Size(36, 20);
			this.YMin.TabIndex = 3;
			this.YMin.Leave += new System.EventHandler(this.YMin_Leave);
			// 
			// XMin
			// 
			this.XMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.XMin.Location = new System.Drawing.Point(36, 483);
			this.XMin.Name = "XMin";
			this.XMin.Size = new System.Drawing.Size(36, 20);
			this.XMin.TabIndex = 3;
			this.XMin.Leave += new System.EventHandler(this.XMin_Leave);
			// 
			// XMax
			// 
			this.XMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.XMax.Location = new System.Drawing.Point(545, 483);
			this.XMax.Name = "XMax";
			this.XMax.Size = new System.Drawing.Size(36, 20);
			this.XMax.TabIndex = 3;
			this.XMax.Leave += new System.EventHandler(this.XMax_Leave);
			// 
			// Graph
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(581, 501);
			this.Controls.Add(this.XMax);
			this.Controls.Add(this.XMin);
			this.Controls.Add(this.YMin);
			this.Controls.Add(this.YMax);
			this.Controls.Add(this.plotView1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Graph";
			this.Text = "Form1";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem графикToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem масштабToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem logxToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem logyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem СombineToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem AddToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
		private OxyPlot.WindowsForms.PlotView plotView1;
		private System.Windows.Forms.ToolStripMenuItem сохранитьSvgToolStripMenuItem;
		private System.Windows.Forms.TextBox YMax;
		private System.Windows.Forms.TextBox YMin;
		private System.Windows.Forms.TextBox XMin;
		private System.Windows.Forms.TextBox XMax;
	}
}

