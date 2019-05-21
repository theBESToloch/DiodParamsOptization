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

		internal OptimizeParam(double CurrentValue)
		{
			Value = CurrentValue;
			this.CurrentValue = CurrentValue;
			Range = CurrentValue / 100;
		}

		internal OptimizeParam(double CurrentValue, double Range)
		{
			this.Value = CurrentValue;
			this.CurrentValue = CurrentValue;
			this.Range = Range;
		}

		public double GetNewValue()
		{
			Vector = Math.Pow(RandomEngine.NextRandom(), 3);
			return CurrentValue = Value + Vector * Range;
		}


		public double GetNewValueUniform()
		{
			Vector = RandomEngine.NextRandom();
			return CurrentValue = Value + Vector * Range;
		}

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
