using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphCreator
{
	class Chart
	{
		public Chart(double[] x, double[] y, string title, string xL, string yL)
		{
			this.x = x;
			this.y = y;
			this.title = title;
			this.xL = xL;
			this.yL = yL;
		}

		private double[] x, y;
		private string title, xL, yL;

		public double[] X { get => x; set => x = value; }
		public double[] Y { get => y; set => y = value; }
		public string Title { get => title; set => title = value; }
		public string XL { get => xL; set => xL = value; }
		public string YL { get => yL; set => yL = value; }
	}
}
