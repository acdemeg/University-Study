using System;

namespace lab1
{
    class Tasker : IDecideAble<Task>
    {
        public double[] Calculation (Task kofficients)
        {
            if (kofficients.A == 0)
            {
                throw new DivideByZeroException("Коэффициент \"а\" не моежет быть равен 0");
            }
            double[] result = new double[2];
            double d = Math.Pow(kofficients.B, 2) - 4 * kofficients.A * kofficients.C;
            if (d > 0 || d == 0)
            {

                result[0] = (-kofficients.B + Math.Sqrt(d)) / (2 * kofficients.A);  //x1
                result[1] = (-kofficients.B - Math.Sqrt(d)) / (2 * kofficients.A);  //x2
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
