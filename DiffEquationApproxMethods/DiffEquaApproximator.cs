using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffEquationApproxMethods
{
    public interface DiffEquaApproximator
    {
        double[,] ApproximateSteps(double x, double y, int iterates, double StepSize);
    }
}
