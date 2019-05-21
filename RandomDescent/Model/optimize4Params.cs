using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomDescent
{
	public class Optimize4Params : IOptimize, IVAX, IInaccuracy
	{

		#region Поля

		private double z = 0;
		private int len = 0;

		private double[] I, U;

		List<double> ISy;
		List<double> fy;
		List<double> Ry;
		List<double> IKFy;

		List<double> dfy;
		List<double> dIsy;
		List<double> dRy;
		List<double> dIKFy;

		List<double> Sy;
		List<double> y;

		double c = 0, VD = 0, S = 0;

		OptimizeParam Is;
		OptimizeParam f;
		OptimizeParam R;
		OptimizeParam IKF;
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


		public object IS0 { get { return Is.Value; } }
		public object F0 { get { return f.Value; } }
		public object R0 { get { return R.Value; } }
		public object IKF0 { get { return IKF.Value; } }

		public double[] DFY()
		{
			return dfy.ToArray();
		}

		public double[] DISY()
		{
			return dIsy.ToArray();
		}

		public double[] Error() { return Sy.ToArray(); }
		public double[] Y() { return y.ToArray(); }
		public double[] ErrYor() { return y.ToArray(); }
		#endregion

		public Optimize4Params(double[] I, double[] U, double Is, double f, double R, double IKF)
		{

			ISy = new List<double>();
			fy = new List<double>();
			Ry = new List<double>();
			IKFy = new List<double>();

			dfy = new List<double>();
			dIsy = new List<double>();
			dRy = new List<double>();
			dIKFy = new List<double>();

			Sy = new List<double>();
			y = new List<double>();

			this.Is = new OptimizeParam(Is, Is / 100);
			this.f = new OptimizeParam(f, f / 100);
			this.R = new OptimizeParam(R, R / 100);
			this.IKF = new OptimizeParam(IKF, IKF / 100);

			// Загрузка данных
			this.I = I;
			this.U = U;
			len = I.Length;

			c = CalculationError(Is, f, R, IKF);
			initEr = c;
		}
		
		#region методы
		public void DoOptimize(int nStep)
		{
			z = 0;

			// Основной цикл
			for (double i = 0; i < nStep - 1; i++)
			{
				normalizeParams();
				S = CalculationError(Is.GetNewValue(), f.GetNewValue(), R.GetNewValue(), IKF.GetNewValue());

				// условие
				if (S < c)
				{
					c = S;

					Is.InitValue();
					f.InitValue();
					R.InitValue();
					IKF.InitValue();

					y.Add(i);
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
				}
				dfy.Add(f.Range);
				dIsy.Add(Is.Range);
				dRy.Add(R.Range);
				dIKFy.Add(IKF.Range);
			}
			y.Add(nStep);
			Sy.Add(c);
			ISy.Add(Is.Value);
			fy.Add(f.Value);
			Ry.Add(R.Value);
			IKFy.Add(IKF.Value);
			er = c;
		}

		public void DoOptimizeUniform(int n)
		{
			throw new NotImplementedException();
		}

		public void DoOptimizeUniformAndNormalize(int n)
		{
			throw new NotImplementedException();
		}

		public void DoOptimizeAndNormalize(int n)
		{
			throw new NotImplementedException();
		}

		double CalculationError(double Is, double f, double R, double IKF)
		{
			double S = 0;
			for (int j = 0; j < I.Length; j++)
			{
				VD = Math.Log((Math.Pow(I[j], 2) + Math.Sqrt(Math.Pow(I[j], 4) + 4 * Math.Pow(I[j], 2) * Math.Pow(IKF, 2))) / (2 * IKF * Is) + 1) * f;
				S += Math.Pow((U[j] - VD - R * I[j]) / U[j], 2);
			}
			return S;
		}

		private void normalizeParams()
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

		private double initEr = 0, er = 0;

		public double initErr()
		{
			return initEr;
		}
		public double OptimizeErr()
		{
			return er;
		}

		#region инициализация ВАХ
		double[] UU_;
		private void InitVAX()
		{
			UU_ = new double[U.Length];
			for (int j = 0; j < U.Length; j++)
			{
				UU_[j] = Math.Log((Math.Pow(I[j], 2) + Math.Sqrt(Math.Pow(I[j], 4) + 4 * Math.Pow(I[j], 2) * Math.Pow(IKF.Value, 2))) / (2 * IKF.Value * Is.Value) + 1) * f.Value + R.Value * I[j];
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

			for (int i = 0; i < I.Length; i++)
			{
				VD = _VD(U[i], Is.Value, f.Value, IKF.Value, R.Value, VD);
				I_err[i] = I[i] - Is.Value * (Math.Exp((VD) / f.Value) - 1) * Math.Sqrt(IKF.Value / (IKF.Value + Is.Value * (Math.Exp((VD) / f.Value) - 1)));

				SCO_absolut += Math.Pow((I_err[i]), 2);
				SCO_relative += Math.Pow(I_err[i] / I[i], 2);
				I_err[i] = (I_err[i] / I[i]) * 100;
			}
			SCO_ABS_cur = Math.Sqrt(SCO_absolut / (I_err.Length - 1));
			SCO_REL_cur = Math.Sqrt(SCO_relative / (I_err.Length - 1));
			return I_err;
		}
	
		double[] U_err;
		public double[] InaccuracyOfVoltage()
		{
			U_err = new double[U.Length];
			double SCO_absolut = 0;
			double SCO_relative = 0;

			for (int i = 0; i < U.Length; i++)
			{
				U_err[i] = U[i] - Math.Log((Math.Pow(I[i], 2) + Math.Sqrt(Math.Pow(I[i], 4) + 4 * Math.Pow(I[i], 2) * Math.Pow(IKF.Value, 2))) / (2 * IKF.Value * Is.Value) + 1) * f.Value - R.Value * I[i];

				SCO_absolut += Math.Pow(U_err[i], 2);
				SCO_relative += Math.Pow(U_err[i] / U[i], 2);
				U_err[i] = (U_err[i] / U[i]) * 100;
			}
			SCO_ABS_vol = Math.Sqrt(SCO_absolut / (U_err.Length - 1));
			SCO_REL_vol = Math.Sqrt(SCO_relative / (U_err.Length - 1));
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
		#endregion
	}
}
