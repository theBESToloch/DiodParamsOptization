using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomDescent
{
	public class OptimizeParams_Fi2 : Optimize
	{

		#region Поля

		private int nStep;
		private double z = 0;
		private int len = 0;

		private double[] I, U;

		private double Is0;
		private double f0;
		private double R0;
		private double IK0;
		private double[] FPar0;

		List<double> Sy;
		List<double> y;

		private double
		 df = 0, f = 0,
		 dIs = 0, Is = 0,
		 dR = 0, R = 0,
		 dIK = 0, IK = 0;

		private double[]
			dFPar, FPar;


		double
			c = 0,
			VD = 0, S = 0;

		double parF;

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

		public double IS0
		{
			get { return Is0; }
			set { Is0 = value; }
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

		public double[] FPAR0
		{
			get { return FPar0; }
			set { FPAR0 = value; }
		}

		#endregion

		public OptimizeParams_Fi2(double[] I, double[] U, int nStep, double Is, double f, double R, double IKF, double[] FPar)
		{
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
			this.FPar0 = new double[3];
			for (int i = 0; i < 3; i++) this.FPar0[i] = FPar[i];

			this.Is = Is;
			this.f = f;
			this.R = R;
			this.IK = IKF;
			this.FPar = new double[3];
			for (int i = 0; i < 3; i++) this.FPar[i] = FPar[i];

			df = f0 / 100;
			dIs = Is0 / 100;
			dR = R0 / 100;
			dIK = IKF / 100;

			dFPar = new double[3];
			for (int i = 0; i < 3; i++) dFPar[i] = FPar[i] / 100;

			c = 0;
			for (int i = 0; i < len; i++)
			{
				parF = calcFi(Is0, FPar0, I[i]);
				VD = Math.Log((Math.Pow(I[i], 2) + Math.Sqrt(Math.Pow(I[i], 4) + 4 * Math.Pow(I[i], 2) * Math.Pow(IK0, 2))) / (2 * IK0 * parF) + 1) * f0;
				c += Math.Pow((U[i] - VD - R0 * I[i]) / U[i], 2);
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
				f = Math.Abs(f0 + Math.Pow((rnd.Next(200) * 0.01 - 1), 3) * df);
				Is = Math.Abs(Is0 + Math.Pow((rnd.Next(200) * 0.01 - 1), 3) * dIs);
				R = Math.Abs(R0 + Math.Pow((rnd.Next(200) * 0.01 - 1), 3) * dR);
				IK = Math.Abs(IK0 + Math.Pow((rnd.Next(200) * 0.01 - 1), 3) * dIK);
				normalizeParams(f - f0, df,Is - Is0, dIs, R - R0, dR,IK - IK0, dIK);

				FPar[0] = FPar0[0] + Math.Pow((rnd.Next(200) * 0.01 - 1), 3) * dFPar[0];
				FPar[1] = FPar0[1] + Math.Pow((rnd.Next(200) * 0.01 - 1), 3) * dFPar[1];
				FPar[2] = FPar0[2] + Math.Pow((rnd.Next(200) * 0.01 - 1), 3) * dFPar[2];
				S = 0;

				for (int j = 0; j < len; j++)
				{
					parF = calcFi(Is, FPar, I[j]);
					VD = Math.Log((Math.Pow(I[j], 2) + Math.Sqrt(Math.Pow(I[j], 4) + 4 * Math.Pow(I[j], 2) * Math.Pow(IK, 2))) / (2 * IK * parF) + 1) * f;
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
		
					for(int k = 0; k < 3; k++) FPar0[k] = FPar[k];

					y.Add(i);
					Sy.Add(S);
					z++;
				}
			}
			y.Add(nStep);
			Sy.Add(c);
			er = c;
		}

		private double calcFi(double f, double[] FPar, double I)
		{
			return f * (1 + FPar[0] * I + FPar[1] * Math.Pow(I, 2)) / (FPar[2] * I);
			//return f - 0.5 * FPar[0] * ((1 - Math.Exp(-(FPar[1] * (I - FPar[2])))) / (1 + Math.Exp(-(FPar[1] * (I - FPar[2])))));
		}
		
		private void normalizeParams(double _f, double df, double _Is, double dIs, double _R, double dR, double _IK, double dIK)
		{
			double LenghtVector = Math.Abs(_f / df) + Math.Abs(_Is / dIs) + Math.Abs(_R / dR) + Math.Abs(_IK / dIK);
			if (LenghtVector > 1)
			{
				f = f0 + _f / LenghtVector;
				Is = Is0 + _Is / LenghtVector;
				R = R0 + _R / LenghtVector;
				IK = IK0 + _IK / LenghtVector;
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
		private void getVAX()
		{
			UU_ = new double[U.Length];
			for (int j = 0; j < U.Length; j++)
			{
				parF = calcFi(f0, FPar0, I[j]);
				UU_[j] = Math.Log((Math.Pow(I[j], 2) + Math.Sqrt(Math.Pow(I[j], 4) + 4 * Math.Pow(I[j], 2) * Math.Pow(IK0, 2))) / (2 * IK0 * Is0) + 1) * parF + R0 * I[j];
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
				parF = calcFi(f0, FPar0, I[i]);
				VD = _VD(U[i], Is0, parF, IK0, R0, VD);
				I_err[i] = I[i] - Is0 * (Math.Exp((VD) / parF) - 1) * Math.Sqrt(IK0 / (IK0 + Is0 * (Math.Exp((VD) / parF) - 1)));

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
				parF = calcFi(f0, FPar0, I[i]);
				U_err[i] = U[i] - Math.Log((Math.Pow(I[i], 2) + Math.Sqrt(Math.Pow(I[i], 4) + 4 * Math.Pow(I[i], 2) * Math.Pow(IK0, 2))) / (2 * IK0 * Is0) + 1) * parF - R0 * I[i];

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

		public double[] DFY()
		{
			throw new NotImplementedException();
		}

		public double[] DISY()
		{
			throw new NotImplementedException();
		}
	}
}
