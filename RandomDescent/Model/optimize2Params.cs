using System;
using System.Collections.Generic;

namespace RandomDescent
{
	public class Optimize2Params : Optimize
	{

		#region Поля

		private int nStep; // кол-во шагов

		double z = 0;
		int len = 0;

		private double[] I, U;


		List<double> ISy;
		List<double> fy;

		List<double> dfy;
		List<double> dIsy;

		List<double> Sy;
		List<double> y;

		private double c = 0, Id = 0, S = 0;
		private double initEr = 0, er = 0;

		OptimizeParam Is;
		OptimizeParam f;
		#endregion

		#region Свойства

		public double Z
		{
			get { return z; }
		}

		public List<double> SY
		{
			get { return Sy; }
		}

		public List<double> Y
		{
			get { return y; }
		}

		public List<double> ISY
		{
			get { return ISy; }
		}

		public double[] DISY()
		{
			return dIsy.ToArray();
		}

		public List<double> FY
		{
			get { return fy; }
		}

		public double[] DFY()
		{
			return dfy.ToArray();
		}

		public double IS0 { get { return Is.Value; } }
		public double F0 { get { return f.Value; } }

		public double initErr()
		{
			return initEr;
		}
		public double optimizeErr()
		{
			return er;
		}

		public double[] Error() { return Sy.ToArray(); }

		#endregion

		public Optimize2Params(double[] I, double[] U, int nStep, double Is, double f)
		{
			ISy = new List<double>();
			fy = new List<double>();

			dfy = new List<double>();
			dIsy = new List<double>();

			Sy = new List<double>();
			y = new List<double>();

			this.Is = new OptimizeParam(Is, Is / 100);
			this.f = new OptimizeParam(f, f / 100);

			// Загрузка данных
			this.I = I;
			this.U = U;
			len = I.Length;

			this.nStep = nStep;

			c = CalculationError(Is, f);
			initEr = c;
		}
		
		#region методы
		public void doOptimize()
		{
			z = 0;

			// Основной цикл
			for (double i = 0; i < nStep - 1; i++)
			{

				NormalizeParams();

				S = CalculationError(Is.GetNewValue(), f.GetNewValue());

				// условие
				if (S < c)
				{
					c = S;
					Is.InitValue();
					f.InitValue();

					y.Add(i);
					Sy.Add(S);
					ISy.Add(Is.CurrentValue);
					fy.Add(f.CurrentValue);
					z++;
				}
				else
				{
					Is.MissValues();
					f.MissValues();
				}
				dfy.Add(f.Range);
				dIsy.Add(Is.Range);
			}
			y.Add(nStep);
			Sy.Add(c);
			ISy.Add(Is.Value);
			fy.Add(f.Value);
			er = c;
		}

		double CalculationError(double Is, double f)
		{
			double S = 0;
			for (int j = 0; j < I.Length; j++)
			{
				Id = Is * (Math.Exp(U[j] / f) - 1);
				S += Math.Abs((I[j] - Id) / I[j]);
			}
			return S;
		}

		private void NormalizeParams()
		{
			double LenghtVector = Math.Abs(f.Vector) + Math.Abs(Is.Vector);
			if (LenghtVector > 1)
			{
				f.CurrentValue += f.Value + f.Vector * f.Range / LenghtVector;
				Is.CurrentValue += Is.Value + Is.Vector * Is.Range / LenghtVector;
			}
		}

		#region инициализация ВАХ
		double[] II_;

		private void initVAX()
		{
			II_ = new double[U.Length];

			for (int i = 0; i < U.Length; i++)
			{
				II_[i] = Is.Value * (Math.Exp(U[i] / f.Value) - 1);
			}
		}

		public double[] getMassU()
		{
			return U;
		}
		public double[] getMassI()
		{
			initVAX();
			return II_;
		}
		#endregion
		#region рассчет погрешностей
		double SCO_ABS_cur, SCO_REL_cur;
		public double getSCO_ABS_cur()
		{
			return SCO_ABS_cur;
		}
		public double getSCO_REL_cur()
		{
			return SCO_REL_cur;
		}



		double SCO_ABS_vol, SCO_REL_vol;
		public double getSCO_ABS_vol()
		{
			return SCO_ABS_vol;
		}
		public double getSCO_REL_vol()
		{
			return SCO_REL_vol;
		}

		double[] I_err;
		public double[] inaccuracyOfCUrrent()
		{
			I_err = new double[I.Length];
			double SCO_absolut = 0;
			double SCO_relative = 0;

			for (int i = 0; i < I.Length; i++)
			{
				I_err[i] = I[i] - Is.Value * (Math.Exp(U[i] / f.Value) - 1);

				SCO_absolut += Math.Pow((I_err[i]), 2);
				SCO_relative += Math.Pow(I_err[i] / I[i], 2);
				I_err[i] = (I_err[i] / I[i]) * 100;
			}
			SCO_ABS_cur = Math.Sqrt(SCO_absolut / (I_err.Length - 1));
			SCO_REL_cur = Math.Sqrt(SCO_relative / (I_err.Length - 1));
			return I_err;
		}

		double[] U_err;
		public double[] inaccuracyOfVoltage()
		{
			U_err = new double[U.Length];
			double SCO_absolut = 0;
			double SCO_relative = 0;

			for (int i = 0; i < U.Length; i++)
			{
				U_err[i] = U[i] - Math.Log(I[i] / Is.Value + 1) * f.Value;

				SCO_absolut += Math.Pow(U_err[i], 2);
				SCO_relative += Math.Pow(U_err[i] / U[i], 2);
				U_err[i] = (U_err[i] / U[i]) * 100;
			}
			SCO_ABS_vol = Math.Sqrt(SCO_absolut / (U_err.Length - 1));
			SCO_REL_vol = Math.Sqrt(SCO_relative / (U_err.Length - 1));
			return U_err;
		}
		#endregion

		#endregion
	}
}