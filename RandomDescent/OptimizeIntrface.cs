using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomDescent
{
	public interface IOptimize
	{
		void DoOptimize(int n);
		void DoOptimizeUniform(int n);
		void DoOptimizeUniformAndNormalize(int n);
		void DoOptimizeAndNormalize(int n);

		double OptimizeErr();

		double[] Error();
		double[] Y();


	}
}
