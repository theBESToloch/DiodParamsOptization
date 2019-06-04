using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomDescent
{
	class OptimizeParam
	{
		//начальное значение
		public double Value { get; set; }
		//Текущее приближение
		public double CurrentValue { get; set; }
		//Диапозон приближений
		public double Range { get; set; }

		public double Vector { get; set; }

		public double Eps { get; set; }

		internal OptimizeParam(double CurrentValue)
		{
			Value = CurrentValue;
			this.CurrentValue = CurrentValue;
			Range = CurrentValue / 100;
			Eps = Range / 1000000;
		}

		internal OptimizeParam(double CurrentValue, double Range)
		{
			this.Value = CurrentValue;
			this.CurrentValue = CurrentValue;
			this.Range = Range;
			Eps = Range / 1000000;
		}

		public double GetNewValue()
		{
			Vector = Math.Pow(RandomEngine.NextRandom(), 3);
			return CurrentValue = Value + Vector * (Range + Eps);
		}

		/*public double GetNewValue()
		{
			Vector = RandomEngine.NextRandom();
			return CurrentValue = Value + Vector * Range;
		}*/

		public void InitValue()
		{
			Range *= 1.005;
			Value = CurrentValue;
		}

		public void MissValues()
		{
			Range /=1.00001;
		}
	}
}
