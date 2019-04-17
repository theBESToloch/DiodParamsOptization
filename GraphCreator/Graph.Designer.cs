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
			this.components = new System.ComponentModel.Container();
			this.Graffik = new ZedGraph.ZedGraphControl();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.графикToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.масштабToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.logxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.logyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// Graffik
			// 
			this.Graffik.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Graffik.Location = new System.Drawing.Point(0, 27);
			this.Graffik.Name = "Graffik";
			this.Graffik.ScrollGrace = 0D;
			this.Graffik.ScrollMaxX = 0D;
			this.Graffik.ScrollMaxY = 0D;
			this.Graffik.ScrollMaxY2 = 0D;
			this.Graffik.ScrollMinX = 0D;
			this.Graffik.ScrollMinY = 0D;
			this.Graffik.ScrollMinY2 = 0D;
			this.Graffik.Size = new System.Drawing.Size(633, 423);
			this.Graffik.TabIndex = 0;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.графикToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(633, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// графикToolStripMenuItem
			// 
			this.графикToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.масштабToolStripMenuItem});
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
			this.масштабToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
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
			// Graph
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(633, 450);
			this.Controls.Add(this.Graffik);
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

		private ZedGraph.ZedGraphControl Graffik;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem графикToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem масштабToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem logxToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem logyToolStripMenuItem;
	}
}

