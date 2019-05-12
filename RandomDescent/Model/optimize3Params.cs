using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomDescent
{
	public class Optimize3Params : Optimize
	{
		#region Поля

		private int nStep;

		double z = 0;
		int len = 0;

		private double[] I, U;


		List<double> ISy;
		List<double> fy;
		List<double> Ry;

		List<double> dfy;
		List<double> dIsy;
		List<double> dRy;

		List<double> Sy;
		List<double> y;

		double c = 0, Id = 0, S = 0;

		OptimizeParam Is;
		OptimizeParam f;
		OptimizeParam R;
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

		public List<double> RY
		{
			get { return Ry; }
		}

		public double[] DRY
		{
			get { return dRy.ToArray(); }
		}


		public object IS0 { get { return Is.Value; } }
		public object F0 { get { return f.Value; } }
		public object R0 { get { return R.Value; } }

		#endregion

		#region методы

		// Конструктор
		public Optimize3Params(double[] I, double[] U, int nStep, double Is, double f, double R)
		{

			ISy = new List<double>();
			fy = new List<double>();
			Ry = new List<double>();

			dfy = new List<double>();
			dIsy = new List<double>();
			dRy = new List<double>();

			Sy = new List<double>();
			y = new List<double>();

			this.Is = new OptimizeParam(Is, Is / 100);
			this.f = new OptimizeParam(f, f / 100);
			this.R = new OptimizeParam(R, R / 100);

			// Загрузка данных
			this.I = I;
			this.U = U;
			len = I.Length;

			this.nStep = nStep;


			c = CalculationError(Is, f, R);
			initEr = c;
		}

		// сам спуск - простейший
		public void doOptimize()
		{
			z = 0;

			// Основной цикл
			for (double i = 0; i < nStep - 1; i++)
			{
				normalizeParams();

				S = CalculationError(Is.GetNewValue(), f.GetNewValue(), R.GetNewValue());

				// условие
				if (S < c)
				{
					c = S;

					Is.InitValue();
					f.InitValue();
					R.InitValue();

					y.Add(i);
					Sy.Add(S);
					ISy.Add(Is.CurrentValue);
					fy.Add(f.CurrentValue);
					Ry.Add(R.CurrentValue);
					z++;
				}
				else
				{
					Is.MissValues();
					f.MissValues();
					R.MissValues();
				}
				dfy.Add(f.Range);
				dIsy.Add(Is.Range);
				dRy.Add(R.Range);
			}
			y.Add(nStep);
			Sy.Add(c);
			ISy.Add(Is.Value);
			fy.Add(f.Value);
			Ry.Add(R.Value);
			er = c;
		}

		double CalculationError(double Is, double f, double R)
		{
			double S = 0;
			for (int j = 0; j < I.Length; j++)
			{
				Id = Is * (Math.Exp(U[j] / f - R * I[j]) - 1);
				S += Math.Abs((I[j] - Id) / I[j]);
			}
			return S;
		}

		private void normalizeParams()
		{
			double LenghtVector = Math.Abs(f.Vector) + Math.Abs(Is.Vector) + Math.Abs(R.Vector);
			if (LenghtVector > 1)
			{
				f.CurrentValue += f.Value + f.Vector * f.Range / LenghtVector;
				Is.CurrentValue += Is.Value + Is.Vector * Is.Range / LenghtVector;
				R.CurrentValue += R.Value + R.Vector * R.Range / LenghtVector;
			}
		}

		private double initEr = 0, er = 0;

		public double initErr()
		{
			return initEr;
		}
		public double optimizeErr()
		{
			return er;
		}

		double[] UU_;
		private void initVAX()
		{
			UU_ = new double[U.Length];
			for (int i = 0; i < U.Length; i++)
			{
				UU_[i] = f.Value * Math.Log((I[i] / Is.Value) + 1) + R.Value * I[i];
			}
		}

		public double[] getMassU()
		{
			initVAX();
			return UU_;
		}
		public double[] getMassI()
		{
			return I;
		}

		double SCO_ABS_cur, SCO_REL_cur;
		public double getSCO_ABS_cur()
		{
			return SCO_ABS_cur;
		}
		public double getSCO_REL_cur()
		{
			return SCO_REL_cur;
		}
		double[] I_err;
		public double[] inaccuracyOfCUrrent()
		{
			I_err = new double[I.Length];
			double SCO_absolut = 0;
			double SCO_relative = 0;
			double VD = U[0];
			for (int i = 0; i < I.Length; i++)
			{
				VD = _VD(U[i], Is.Value, f.Value, 1000, R.Value, U[i] - R.Value * I[i]);

				I_err[i] = (I[i] - Is.Value * (Math.Exp(VD / f.Value) - 1));

				SCO_absolut += Math.Pow((I_err[i]), 2);
				SCO_relative += Math.Pow(I_err[i] / I[i], 2);
				I_err[i] = (I_err[i] / I[i]) * 100;
			}
			SCO_ABS_cur = Math.Sqrt(SCO_absolut / (I_err.Length - 1));
			SCO_REL_cur = Math.Sqrt(SCO_relative / (I_err.Length - 1));
			return I_err;
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
		double[] U_err;
		public double[] inaccuracyOfVoltage()
		{
			U_err = new double[U.Length];
			double SCO_absolut = 0;
			double SCO_relative = 0;

			for (int i = 0; i < U.Length; i++)
			{
				U_err[i] = U[i] - Math.Log(I[i] / Is.Value + 1) * f.Value - R.Value * I[i];

				SCO_absolut += Math.Pow(U_err[i], 2);
				SCO_relative += Math.Pow(U_err[i] / U[i], 2);
				U_err[i] = (U_err[i] / U[i]) * 100;
			}
			SCO_ABS_vol = Math.Sqrt(SCO_absolut / (U_err.Length - 1));
			SCO_REL_vol = Math.Sqrt(SCO_relative / (U_err.Length - 1));
			return U_err;
		}



		//падение напряжения на диоде
		private double _VD(double UU, double Is, double f, double IK, double R, double VD)
		{
			double FL = 9, FN = 8;
			double a, b1, b2, FD, F;
			while (Math.Abs(FL) > Math.Abs(FN) + 1e-16)
			{
				a = Is * (Math.Exp(VD / f) - 1);
				b1 = Is / f * Math.Exp(VD / f) * Math.Sqrt(IK / (IK + a));
				b2 = -IK * Is * Math.Exp(VD / f) * a / (2 * f * Math.Pow(IK + a, 2) * Math.Sqrt(IK / (IK + a)));
				FD = 1 / R + b1 + b2;
				F = (VD - UU) / R + a * Math.Sqrt(IK / (IK + a));
				VD = VD - F / FD;
				FL = FN;
				FN = F;
			}
			return VD;
		}

		#endregion
	}
}
