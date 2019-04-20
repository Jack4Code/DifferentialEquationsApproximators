using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffEquationApproxMethods
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*
            d.e.: dy/dx = x - y + 1 where y(0) = 2

            The d.e. is hardcoded. The code can be modified at some point to take in differential equations as a parameter.
            This would make the program more dynamic. For now the scope of the project consists of implementing three approximation methods
            on an example d.e. I.V.P.: Euler, Heun, Runge Kutta.
            */

            double Xnaught = 0;
            double Ynaught = 2;
            double[] stepSizes = { 0.25, 0.1, 0.05 };
            double interval = 1.0;
            int iterates = Convert.ToInt32(interval / stepSizes[0]);
            double ExactSolution = 2 * Math.Exp(-1) + 1;

            for (int i = 0; i < stepSizes.Length; i++)
            {
                DiffEquaApproximator eulerMethod = new EulerMethod();
                DiffEquaApproximator huensMethod = new HeunsMethod();
                DiffEquaApproximator RungeKutta = new RungeKuttaMethod();

                iterates = Convert.ToInt32(interval / stepSizes[i]);

                double[,] EulerResults = eulerMethod.ApproximateSteps(Xnaught, Ynaught, iterates + 1, stepSizes[i]);
                double[,] HeunResults = huensMethod.ApproximateSteps(Xnaught, Ynaught, iterates + 1, stepSizes[i]);
                double[,] RungeKuttaResults = RungeKutta.ApproximateSteps(Xnaught, Ynaught, iterates + 1, stepSizes[i]);

                Console.WriteLine("-------------------------------------------------------------------");
                Console.WriteLine("StepSize: " + stepSizes[i].ToString());
                Console.WriteLine("Number of iterates: " + iterates.ToString());
                Console.WriteLine("-------------------------------------------------------------------");

                for (int j = 0; j < iterates + 1; j++)
                {
                    Console.WriteLine("Iteration " + j.ToString() + " for step size " + stepSizes[i].ToString());
                    Console.WriteLine("Euler: ");
                    Console.WriteLine("x" + j + ": " + EulerResults[j, 0] + "; y" + j + ": " + EulerResults[j, 1]);
                    Console.WriteLine("Heun: ");
                    Console.WriteLine("x" + j + ": " + HeunResults[j, 0] + "; y" + j + ": " + HeunResults[j, 1]);
                    Console.WriteLine("RungeKutta: ");
                    Console.WriteLine("x" + j + ": " + RungeKuttaResults[j, 0] + "; y" + j + ": " + RungeKuttaResults[j, 1] + "\r\n");
                }

                Console.WriteLine("-------------------------------------------------------------------");
                Console.WriteLine("The exact value at x=1 is " + ExactSolution.ToString());
                Console.WriteLine("The percent deviation for Euler at this point is " + (Math.Abs(EulerResults[iterates, 1] - ExactSolution) / ExactSolution) * 100 + "%");
                Console.WriteLine("The percent deviation for Heun at this point is " + (Math.Abs(HeunResults[iterates, 1] - ExactSolution) / ExactSolution) * 100 + "%");
                Console.WriteLine("The percent deviation for Runge Kutta at this point is " + (Math.Abs(RungeKuttaResults[iterates, 1] - ExactSolution) / ExactSolution) * 100 + "%");
                Console.WriteLine("-------------------------------------------------------------------");
            }




            Console.WriteLine("Press any key to escape: ");
            Console.ReadLine();
        }
    }
}
