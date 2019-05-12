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

		public double Vector { get; set; }

		internal OptimizeParams(double[] CurrentValue)
		{
			Value = CurrentValue;
			this.CurrentValue = CurrentValue;
			for(int i = 0; i < CurrentValue.Length; i++)
			Range[i] = CurrentValue[i] / 100;
		}

		internal OptimizeParams(double[] CurrentValue, double[] Range)
		{
			this.Value = CurrentValue;
			this.CurrentValue = CurrentValue;
			this.Range = Range;
		}

		public double[] GetNewValue()
		{
			Vector = Math.Pow(RandomEngine.NextRandom(), 3);
			for (int i = 0; i < Range.Length; i++)
				 CurrentValue[i] = Value[i] + Vector * Range[i];
			return CurrentValue;
		}

		public void InitValue()
		{
			for (int i = 0; i < Range.Length; i++)
				Range[i] *= 1.005;
			Value = CurrentValue;
		}

		public void MissValues()
		{
			for (int i = 0; i < Range.Length; i++)
				Range[i] /=1.00001;
		}

	}
}
