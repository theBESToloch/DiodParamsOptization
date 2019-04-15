using System;
using System.Collections.Generic;
using Troschuetz.Random;

namespace RandomDescent
{
    public class optimize2Params : Optimize
    {

        #region Поля

        private int nStep; // кол-во шагов

        double z = 0;
        int len = 0;

        private double[] I, U;

        private double Is0;
        private double f0;

        List<double> ISy;
        List<double> fy;

        List<double> dfy;
        List<double> dIsy;

        List<double> Sy;
        List<double> y;

		double
			df0 = 0, df = 0, f = 0,
			dIs0 = 0, dIs = 0, Is = 0;

        double
            c = 0,
            Id = 0, S = 0;

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

        #endregion

        #region методы

        // Конструктор
        public optimize2Params(double[] I, double[] U, int nStep, double Is, double f)
        {
            ISy = new List<double>();
            fy = new List<double>();

            dfy = new List<double>();
            dIsy = new List<double>();

            Sy = new List<double>();
            y = new List<double>();


            // Загрузка данных
			this.I = I;
			this.U = U;
            len = I.Length;

            this.nStep = nStep;
			this.Is0 = Is;
			this.f0 = f;

			this.f = f;
			this.Is0 = Is;

            df = f0 / 100;
            dIs = Is0 / 100;

            df0 = df;
            dIs0 = dIs;

			c = 0;
			Is0 = newIS();
            for (int i = 0; i < len; i++)
            {
				Id = Is0 * (Math.Exp(U[i]/ f0) -1);
				c += Math.Abs((I[i] - Id) /I[i]);
			}
		}

        // сам спуск - простейший
        public void doOptimize()
        {
            Random rnd = new Random();
            z = 0;

            Sy.Clear();
            y.Clear();

            // Основной цикл
            for (double i = 0; i < nStep-1; i++)
            {
                f = Math.Abs(f0 + (rnd.Next(200) * 0.1 - 1) * df);
				//Is = Math.Abs(Is0 + (rnd.Next(200) * 0.1 - 1) * dIs);
				Is = newIS();

				S = 0;
                for (int j = 0; j < len; j++)
                {
					Id = Is * (Math.Exp(U[j] / f) - 1);
					S += Math.Abs((I[j] - Id) / I[j]);
                }
                // условие
                if (S < c)
                {
                    c = S;

                    Is0 = Is;
                    f0 = f;

                    y.Add(i);
                    Sy.Add(S);
                    ISy.Add(Is);
                    fy.Add(f);
                    z++;
                }
            }
            y.Add(nStep);
            Sy.Add(c);
            ISy.Add(Is0);
            fy.Add(f0);
        }

		private double newIS()
		{
			double a = 0, b = 0;

			for (int j = 0; j < len; j++)
			{
				a += I[j]* (Math.Exp(U[j] / f) - 1);
				b += Math.Pow((Math.Exp(U[j] / f) - 1), 2);
			}
			return a/b;
		}

		double[] II_;

		private void initVAX()
		{
			double uMin = U[0], uMax = U[U.Length - 1], dU;

			II_ = new double[U.Length];

			dU = (uMax - uMin) / (U.Length - 1);

			for (int i = 0; i < U.Length; i++)
			{
				II_[i] = Is * (Math.Exp(U[i] / f) - 1);
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

			for (int i = 0; i < I.Length; i++)
			{
				I_err[i] = I[i] - Is * (Math.Exp(U[i] / f) - 1);

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
				U_err[i] = U[i] - Math.Log(I[i] / Is + 1) * f;

				SCO_absolut += Math.Pow(U_err[i], 2);
				SCO_relative += Math.Pow(U_err[i] / U[i], 2);
				U_err[i] = (U_err[i] / U[i]) * 100;
			}
			SCO_ABS_vol = Math.Sqrt(SCO_absolut / (U_err.Length - 1));
			SCO_REL_vol = Math.Sqrt(SCO_relative / (U_err.Length - 1));
			return U_err;
		}


		#endregion
	}
}