using RandomDescent.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomDescent
{
	public class OptimizeParams_Fi1 : IOptimize, IVAX, IInaccuracy
	{

		#region Поля

		private double z = 0;
		private int len = 0;

		private double[] I, U;

		List<double> ISy;
		List<double> fy;
		List<double> Ry;
		List<double> IKFy;

		/*List<double> dfy;
		List<double> dIsy;
		List<double> dRy;
		List<double> dIKFy;*/

		List<double> Sy;
		List<double> y;

		double c = 0, VD = 0, S = 0;

		OptimizeParam Is;
		OptimizeParam f;
		OptimizeParam R;
		OptimizeParam IKF;
		OptimizeParams FPar;
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

		public double[] ISY() { return ISy.ToArray(); }
		public double[] FY() { return fy.ToArray(); }
		public double IS0 { get { return Is.Value; } }
		public double F0 { get { return f.Value; } }
		public double R0 { get { return R.Value; } }
		public double IKF0 { get { return IKF.Value; } }
		public double[] FPAR0 { get { return FPar.Value; } }
		public double[] Error() { return Sy.ToArray(); }
		public double[] Y() { return y.ToArray(); }
		#endregion

		public OptimizeParams_Fi1(double[] I, double[] U, double Is, double f, double R, double IKF, double[] FPar)
		{

			ISy = new List<double>();
			fy = new List<double>();
			Ry = new List<double>();
			IKFy = new List<double>();

			Sy = new List<double>();
			y = new List<double>();

			this.Is = new OptimizeParam(Is, Is / 100);
			this.f = new OptimizeParam(f, f / 100);
			this.R = new OptimizeParam(R, R / 100);
			this.IKF = new OptimizeParam(IKF, IKF / 100);

			this.FPar = new OptimizeParams(new double[] { 1, 1, 1 });

			// Загрузка данных
			this.I = I;
			this.U = U;
			len = I.Length;

			c = CalculationError(this.Is.Value, this.f.Value, this.R.Value, this.IKF.Value, this.FPar.Value);

			InitEr = c;
		}

		#region методы
		public void DoOptimize(int nStep)
		{
			double step = y.Count != 0 ? y[y.Count - 1] : 0;
			z = 0;

			// Основной цикл
			for (double i = 0; i < nStep - 1; i++)
			{
				NormalizeParams();

				S = CalculationError(Is.GetNewValue(), f.GetNewValue(), R.GetNewValue(), IKF.GetNewValue(), FPar.GetNewValue());

				// условие
				if (S < c)
				{
					c = S;


					Is.InitValue();
					f.InitValue();
					R.InitValue();
					IKF.InitValue();
					FPar.InitValue();


					y.Add(step + i);
					Sy.Add(S);
					ISy.Add(Is.CurrentValue);
					fy.Add(f.CurrentValue);
					Ry.Add(R.CurrentValue);
					IKFy.Add(IKF.CurrentValue);
					z++;
				}
				else
				{
					Is.MissValues();
					f.MissValues();
					R.MissValues();
					IKF.MissValues();
					FPar.MissValues();
				}
			}
			y.Add(step + nStep);
			Sy.Add(c);
			ISy.Add(Is.Value);
			fy.Add(f.Value);
			Ry.Add(R.Value);
			IKFy.Add(IKF.Value);
			Er = c;
		}

		double CalculationError(double Is, double f, double R, double IKF, double[] FPar)
		{
			double S = 0;
			double parF = 0;
			for (int j = 0; j < I.Length; j++)
			{
				parF = CalcFi(f, FPar, U[j]);
				VD = Math.Log((Math.Pow(I[j], 2) + Math.Sqrt(Math.Pow(I[j], 4) + 4 * Math.Pow(I[j], 2) * Math.Pow(IKF, 2))) / (2 * IKF * Is) + 1) * parF;
				S += Math.Pow((U[j] - VD - R * I[j]) / U[j], 2);
			}
			return S;
		}

		private double CalcFi(double f, double[] FPar, double U)
		{
			return f * (1 + FPar[0] * U * U + FPar[1] * U * U * U) / (1 + FPar[2] * U * U);
		}

		private void NormalizeParams()
		{
			double LenghtVector = Math.Abs(f.Vector) + Math.Abs(Is.Vector) + Math.Abs(R.Vector) + Math.Abs(IKF.Vector);

			if (LenghtVector > 1)
			{
				f.CurrentValue += f.Value + f.Vector * f.Range / LenghtVector;
				Is.CurrentValue += Is.Value + Is.Vector * Is.Range / LenghtVector;
				R.CurrentValue += R.Value + R.Vector * R.Range / LenghtVector;
				IKF.CurrentValue += IKF.Value + IKF.Vector * IKF.Range / LenghtVector;
			}
		}

		private double InitEr = 0, Er = 0;

		public double InitErr()
		{
			return InitEr;
		}
		public double OptimizeErr()
		{
			return Er;
		}
		#endregion

		#region инициализация ВАХ
		double[] UU_;
		private void InitVAX()
		{
			UU_ = new double[U.Length];
			double parF = 0;
			for (int j = 0; j < U.Length; j++)
			{
				parF = CalcFi(f.Value, FPar.Value, U[j]);
				UU_[j] = Math.Log((Math.Pow(I[j], 2) + Math.Sqrt(Math.Pow(I[j], 4) + 4 * Math.Pow(I[j], 2) * Math.Pow(IKF.Value, 2))) / (2 * IKF.Value * Is.Value) + 1) * parF + R.Value * I[j];
			}
		}
		public double[] GetI()
		{
			return I;
		}
		public double[] GetU()
		{
			InitVAX();
			return UU_;
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
			double VD = U[0];
			double parF = 0;
			for (int i = 0; i < I.Length; i++)
			{
				parF = CalcFi(f.Value, FPar.Value, U[i]);
				VD = _VD(U[i], Is.Value, parF, IKF.Value, R.Value, VD);
				I_err[i] = I[i] - Is.Value * (Math.Exp(VD / parF) - 1) * Math.Sqrt(IKF.Value / (IKF.Value + Is.Value * (Math.Exp((VD) / parF) - 1)));

				SCO_absolut += Math.Pow((I_err[i]), 2);
				SCO_relative += Math.Pow(I_err[i] / I[i], 2);
				I_err[i] = (I_err[i] / I[i]) * 100;
			}
			SCO_ABS_cur = Math.Sqrt(SCO_absolut / (I_err.Length - 1));
			SCO_REL_cur = Math.Sqrt(SCO_relative / (I_err.Length - 1)) * 100;
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
				parF = CalcFi(f.Value, FPar.Value, U[i]);
				U_err[i] = U[i] - Math.Log((Math.Pow(I[i], 2) + Math.Sqrt(Math.Pow(I[i], 4) + 4 * Math.Pow(I[i], 2) * Math.Pow(IKF.Value, 2))) / (2 * IKF.Value * Is.Value) + 1) * parF - R.Value * I[i];

				SCO_absolut += Math.Pow(U_err[i], 2);
				SCO_relative += Math.Pow(U_err[i] / U[i], 2);
				U_err[i] = (U_err[i] / U[i]) * 100;
			}
			SCO_ABS_vol = Math.Sqrt(SCO_absolut / (U_err.Length - 1));
			SCO_REL_vol = Math.Sqrt(SCO_relative / (U_err.Length - 1)) * 100;
			return U_err;
		}

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
