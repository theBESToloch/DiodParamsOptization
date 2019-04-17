using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomDescent
{
	public class Optimize4Params : Optimize
	{

		#region Поля

		private int nStep;
		private double z = 0;
		int len = 0;

		private double[] I, U;

		private double Is0;
		private double f0;
		private double R0;
		private double IK0;

		List<double> ISy;
		List<double> fy;
		List<double> Ry;
		List<double> IKy;

		List<double> dfy;
		List<double> dIsy;
		List<double> dRy;
		List<double> dIKy;

		List<double> Sy;
		List<double> y;

		private double
			df0 = 0, df = 0, f = 0,
			dIs0 = 0, dIs = 0, Is = 0,
			dR0 = 0, dR = 0, R = 0,
			dIK0 = 0, dIK = 0, IK = 0;

		double
			c = 0,
			VD = 0, S = 0;

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

		public double[] DISY
		{
			get { return dIsy.ToArray(); }
		}

		public double IS0
		{
			get { return Is0; }
			set { Is0 = value; }
		}

		public List<double> FY
		{
			get { return fy; }
		}

		public double[] DFY
		{
			get { return dfy.ToArray(); }
		}

		public double F0
		{
			get { return f0; }
			set { f0 = value; }
		}

		public double R00
		{
			get { return R0; }
			set { R0 = value; }
		}

		public double IKF0
		{
			get { return IK0; }
			set { IK0 = value; }
		}
		#endregion


		public Optimize4Params(double[] I, double[] U, int nStep, double Is, double f, double R, double IKF)
		{
			ISy = new List<double>();
			fy = new List<double>();
			Ry = new List<double>();
			IKy = new List<double>();

			dfy = new List<double>();
			dIsy = new List<double>();
			dRy = new List<double>();
			dIKy = new List<double>();


			Sy = new List<double>();
			y = new List<double>();


			// Загрузка данных
			this.I = I;
			this.U = U;
			len = I.Length;

			this.nStep = nStep;
			this.Is0 = Is;
			this.f0 = f;
			this.R0 = R;
			this.IK0 = IKF;

			this.Is = Is;
			this.f = f;
			this.R = R;
			this.IK = IKF;


			df = f0 / 100;
			dIs = Is0 / 100;
			dR = R0 / 100;
			dIK = IKF / 100;

			df0 = df;
			dIs0 = dIs;
			dR0 = dR;
			dIK0 = dIK;

			c = 0;
			for (int i = 0; i < len; i++)
			{
				VD = Math.Log((Math.Pow(I[i], 2) + Math.Sqrt(Math.Pow(I[i], 4) + 4 * Math.Pow(I[i], 2) * Math.Pow(IK0, 2))) / (2 * IK0 * Is0) + 1) * f0;
				c += Math.Pow((U[i] - VD - R0*I[i]) / U[i], 2);
			}
			initEr = c;
		}

		public void doOptimize()
		{
			Random rnd = new Random();
			z = 0;

			Sy.Clear();
			y.Clear();

			// Основной цикл
			for (double i = 0; i < nStep - 1; i++)
			{
				f = Math.Abs(f0 + Math.Pow((rnd.Next(200) * 0.01 - 1),3) * df);
				Is = Math.Abs(Is0 + Math.Pow((rnd.Next(200) * 0.01 - 1), 3) * dIs);
				R = Math.Abs(R0 + Math.Pow((rnd.Next(200) * 0.01 - 1), 3) * dR);
				IK = Math.Abs(IK0 + Math.Pow((rnd.Next(200) * 0.01 - 1), 3) * dIK);
				S = 0;

				for (int j = 0; j < len; j++)
				{
					VD = Math.Log((Math.Pow(I[j], 2) + Math.Sqrt(Math.Pow(I[j], 4) + 4 * Math.Pow(I[j], 2) * Math.Pow(IK, 2))) / (2 * IK * Is) + 1) * f;
					S += Math.Pow((U[j] - VD - R * I[j]) / U[j], 2);
				}
				// условие
				if (S < c)
				{
					c = S;

					Is0 = Is;
					f0 = f;
					R0 = R;
					IK0 = IK;

					y.Add(i);
					Sy.Add(S);
					ISy.Add(Is0);
					fy.Add(f);
					Ry.Add(R);
					IKy.Add(IK);

					z++;
				}
			}
			y.Add(nStep);
			Sy.Add(c);
			ISy.Add(Is);
			fy.Add(f0);
			Ry.Add(R0);
			IKy.Add(IK0);
			er = c;
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
		private void getVAX()
		{
			UU_ = new double[U.Length];
			for (int j = 0; j < U.Length; j++)
			{
				UU_[j] = Math.Log((Math.Pow(I[j], 2) + Math.Sqrt(Math.Pow(I[j], 4) + 4 * Math.Pow(I[j], 2) * Math.Pow(IK0, 2))) / (2 * IK0 * Is0) + 1) * f0 + R0*I[j];
			}
		}

		public double[] getMassI()
		{
			return I;
		}

		public double[] getMassU()
		{
			getVAX();
			return UU_;
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
			double VD = U[0];

			for (int i = 0; i < I.Length; i++)
			{
				//VD = _VD(U[i], Is0, f0, IK0, R0, VD);
				I_err[i] = I[i] - Is0 * (Math.Exp((U[i] - I[i]*R) / f0) - 1) * Math.Sqrt(IK0 / (IK0 + Is0 * (Math.Exp((U[i] - I[i] * R) / f0) - 1)));

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
				U_err[i] = U[i] - Math.Log((Math.Pow(I[i], 2) + Math.Sqrt(Math.Pow(I[i], 4) + 4 * Math.Pow(I[i], 2) * Math.Pow(IK0, 2))) / (2 * IK0 * Is0) + 1) * f0 - R0 * I[i];

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
	}
}
