using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffEquationApproxMethods
{
    public class RungeKuttaMethod : DiffEquaApproximator
    {
        //Constructor
        public RungeKuttaMethod() { }

        public double[,] ApproximateSteps(double Xnaught, double Ynaught, int iterates, double stepSize)
        {
            double[,] results = new double[iterates, 2];
            results[0, 0] = Xnaught;
            results[0, 1] = Ynaught;

            for (int i = 0; i < iterates - 1; i++)
            {
                double x;
                double y;

                x = results[i, 0] + stepSize;
                results[i + 1, 0] = x;
                
                y = (results[i, 1] + (stepSize) * (T4(results[i,0],results[i,1],stepSize)));
                results[i + 1, 1] = y;
            }
            return results;
        }

        public double T4(double Xn, double Yn, double stepSize)
        {
            double t4 = 0;

            double k1 = Xn - Yn + 1;
            double k2 = (Xn+(stepSize/2)) - (Yn + (k1*(stepSize / 2))) + 1;
            double k3 = (Xn + (stepSize / 2)) - (Yn + (k2 * (stepSize / 2))) + 1;
            double k4 = (Xn + (stepSize)) - (Yn + (k3 * (stepSize))) + 1;

            t4 = (1.0/6.0) * ((k1) + (2*k2) + (2*k3) + (k4));

            return t4;
        }
    }
}
