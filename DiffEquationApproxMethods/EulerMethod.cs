using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffEquationApproxMethods
{
    public class EulerMethod : DiffEquaApproximator
    {
        //Constructor
        public EulerMethod() { }

        public double[,] ApproximateSteps(double Xnaught, double Ynaught, int iterates, double StepSize)
        {
            double[,] results = new double[iterates,2];
            results[0, 0] = Xnaught;
            results[0, 1] = Ynaught;

            //Calculation goes here
            for (int i = 0; i < iterates-1; i++)
            {
                double x;
                double y;

                x = results[i, 0] + StepSize;
                results[i + 1, 0] = x;

                y = (results[i, 1] + (StepSize)*(results[i, 0] - results[i, 1] + 1));
                results[i + 1, 1] = y;

            }

            return results;
        }
    }
}
