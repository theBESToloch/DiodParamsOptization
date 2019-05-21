using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomDescent
{
	public interface IInaccuracy
	{

		double[] InaccuracyOfVoltage();
		double GetSCO_REL_vol();
		double GetSCO_ABS_vol();


		double[] InaccuracyOfCUrrent();
		double GetSCO_ABS_cur();
		double GetSCO_REL_cur();

	}
}
