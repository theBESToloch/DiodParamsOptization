using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomDescent
{
	internal class RandomEngine
	{
		static Random random = new Random();


		/// <summary>
		/// возвращает случайное число в диапозоне [-1;1]
		/// </summary>
		/// <returns>возвращает случайное число в диапозоне [-1;1]</returns>
		internal static double NextRandom()
		{
			return random.NextDouble() * 2 - 1;
		}

	}
}
