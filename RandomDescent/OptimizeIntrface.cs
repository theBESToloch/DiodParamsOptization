using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomDescent
{
	public interface Optimize
	{
		void doOptimize();

		double[] getMassI();

		double[] getMassU();


		double[] inaccuracyOfVoltage();
		double getSCO_REL_vol();
		double getSCO_ABS_vol();


		double[] inaccuracyOfCUrrent();
		double getSCO_ABS_cur();
		double getSCO_REL_cur();

		double initErr();
		double optimizeErr();

		double[] DFY();
		double[] DISY();
		double[] Error();

	}
}
