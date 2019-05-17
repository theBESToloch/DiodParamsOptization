using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomDescent.Domain
{
	class OptimizeParams
	{
		//начальное значение
		public double[] Value { get; set; }
		//Текущее приближение
		public double[] CurrentValue { get; set; }
		//Диапозон приближений
		public double[] Range { get; set; }

		public double[] Vector { get; set; }

		internal OptimizeParams(double[] CurrentValue)
		{
			Value = new double[CurrentValue.Length];
			this.CurrentValue = new double[CurrentValue.Length];
			Range = new double[CurrentValue.Length];
			Vector = new double[CurrentValue.Length];

			for (int i = 0; i < CurrentValue.Length; i++)
			{
				Value[i] = CurrentValue[i];
				this.CurrentValue[i] = CurrentValue[i];
				Range[i] = CurrentValue[i] / 100;
			}
		}

		internal OptimizeParams(double[] CurrentValue, double[] Range)
		{
			Value = new double[CurrentValue.Length];
			this.CurrentValue = new double[CurrentValue.Length];
			Range = new double[CurrentValue.Length];
			Vector = new double[CurrentValue.Length];

			for (int i = 0; i < CurrentValue.Length; i++)
			{
				Value[i] = CurrentValue[i];
				this.CurrentValue[i] = CurrentValue[i];
				this.Range[i] = Range[i];
			}
		}

		public double[] GetNewValue()
		{
			for (int i = 0; i < Range.Length; i++)
			{
				Vector[i] = Math.Pow(RandomEngine.NextRandom(), 3);
				CurrentValue[i] = Value[i] + Vector[i] * Range[i];
			}
			return CurrentValue;
		}

		public void InitValue()
		{
			for (int i = 0; i < Range.Length; i++)
			{
				Range[i] *= 1.005;
				Value[i] = CurrentValue[i];
			}
		}

		public void MissValues()
		{
			for (int i = 0; i < Range.Length; i++)
				Range[i] /= 1.00001;
		}

	}
}
