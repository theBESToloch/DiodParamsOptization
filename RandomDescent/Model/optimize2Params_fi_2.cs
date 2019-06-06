using RandomDescent.Domain;
using System;
using System.Collections.Generic;

namespace RandomDescent
{
	public class Optimize2Params_fi_2 : IOptimize, IVAX, IInaccuracy
	{

		#region Поля

		double z = 0;

		private double[] I, U;


		List<double> ISy;
		List<double> fy;

		List<double> dfy;
		List<double> dIsy;

		List<double> Sy;
		List<double> y;

		private double c = 0, Id = 0, S = 0;
		private double InitEr = 0, Er = 0;

		OptimizeParam Is;
		OptimizeParam f;
		OptimizeParams FPar;
		#endregion

		#region Свойства

		public double Z
		{
			get { return z; }
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

		public double InitErr()
		{
			return InitEr;
		}
		public double OptimizeErr()
		{
			return Er;
		}

		public double[] Error() { return Sy.ToArray(); }
		public double[] Y() { return y.ToArray(); }
		#endregion

		public Optimize2Params_fi_2(double[] I, double[] U, double Is, double f)
		{
			ISy = new List<double>();
			fy = new List<double>();

			dfy = new List<double>();
			dIsy = new List<double>();

			Sy = new List<double>();
			y = new List<double>();

			this.Is = new OptimizeParam(Is, Is / 100);
			this.f = new OptimizeParam(f, f / 100);

			this.FPar = new OptimizeParams(new double[] { 1, 1, 1 });

			// Загрузка данных
			this.I = I;
			this.U = U;

			c = CalculationError(this.Is.Value, this.f.Value, this.FPar.Value);
			InitEr = c;
			Sy.Add(c);
		}

		#region методы
		public void DoOptimize(int nStep)
		{
			double step = y.Count != 0 ? y[y.Count - 1] : 0;
			z = 0;

			// Основной цикл
			for (int i = 0; i < nStep; i++)
			{

				S = CalculationError(Is.GetNewValue(), f.GetNewValue(), FPar.GetNewValue());

				// условие
				if (S < c)
				{
					c = S;
					Is.InitValue();
					f.InitValue();
					FPar.InitValue();

					y.Add(step + i);
					Sy.Add(S);

					ISy.Add(Is.CurrentValue);
					fy.Add(f.CurrentValue);
					z++;
				}
				else
				{
					Is.MissValues();
					f.MissValues();
					FPar.MissValues();
				}
			}
			y.Add(step + nStep);
			Sy.Add(c);

			ISy.Add(Is.Value);
			fy.Add(f.Value);
			Er = c;
		}

		double CalculationError(double Is, double f, double[] FPar)
		{
			double S = 0;
			double parF = 0;
			for (int j = 0; j < I.Length; j++)
			{
				parF = calcFi(f, FPar, U[j]);
				Id = Is * (Math.Exp(U[j] / parF) - 1);
				S += Math.Abs((I[j] - Id) / I[j]);
			}
			return S;
		}

		private double calcFi(double f, double[] FPar, double U)
		{
			return f * ((1 + FPar[0] * U * U + FPar[1] * U * U * U)/(1+ FPar[2] * U * U));
		}

		#region инициализация ВАХ
		double[] II_;

		private void InitVAX()
		{
			II_ = new double[U.Length];
			double parF = 0;
			for (int i = 0; i < U.Length; i++)
			{
				parF = calcFi(f.Value, FPar.Value, U[i]);
				II_[i] = Is.Value * (Math.Exp(U[i] / parF) - 1);
			}
		}

		public double[] GetU()
		{
			return U;
		}
		public double[] GetI()
		{
			InitVAX();
			return II_;
		}
		#endregion

		#region рассчет погрешностей
		double SCO_ABS_cur, SCO_REL_cur;
		public double GetSCO_ABS_cur()
		{
			return SCO_ABS_cur;
		}
		public double GetSCO_REL_cur()
		{
			return SCO_REL_cur;
		}

		double SCO_ABS_vol, SCO_REL_vol;
		public double GetSCO_ABS_vol()
		{
			return SCO_ABS_vol;
		}
		public double GetSCO_REL_vol()
		{
			return SCO_REL_vol;
		}

		double[] I_err;
		public double[] InaccuracyOfCUrrent()
		{
			I_err = new double[I.Length];
			double SCO_absolut = 0;
			double SCO_relative = 0;
			double parF = 0;
			for (int i = 0; i < I.Length; i++)
			{
				parF = calcFi(f.Value, FPar.Value, U[i]);
				I_err[i] = I[i] - Is.Value * (Math.Exp(U[i] / parF) - 1);

				SCO_absolut += Math.Pow(I_err[i], 2);
				SCO_relative += Math.Pow(I_err[i] / I[i], 2);
				I_err[i] = (I_err[i] / I[i]) * 100;
			}
			SCO_ABS_cur = Math.Sqrt(SCO_absolut / (I_err.Length - 1));
			SCO_REL_cur = Math.Sqrt(SCO_relative / (I_err.Length - 1))*100;
			return I_err;
		}

		double[] U_err;
		public double[] InaccuracyOfVoltage()
		{
			U_err = new double[U.Length];
			double SCO_absolut = 0;
			double SCO_relative = 0;
			double parF = 0;
			for (int i = 0; i < U.Length; i++)
			{
				parF = calcFi(f.Value, FPar.Value, U[i]);
				U_err[i] = U[i] - Math.Log(I[i] / Is.Value + 1) * parF;

				SCO_absolut += Math.Pow(U_err[i], 2);
				SCO_relative += Math.Pow(U_err[i] / U[i], 2);
				U_err[i] = (U_err[i] / U[i]) * 100;
			}
			SCO_ABS_vol = Math.Sqrt(SCO_absolut / (U_err.Length - 1));
			SCO_REL_vol = Math.Sqrt(SCO_relative / (U_err.Length - 1))*100;
			return U_err;
		}
		#endregion

		#endregion
	}
}