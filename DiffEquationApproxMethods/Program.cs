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
            EulerMethod eulerMethod = new EulerMethod();

            double[,] EulerResults = eulerMethod.ApproximateSteps(0, 2, 5, 0.05);
            for(int i=0; i<EulerResults.Length; i++)
            {
                Console.WriteLine("x: " + EulerResults[i, 0] + "y: " + EulerResults[i,1]);
            }
            

            Console.WriteLine("Press any key to escape: ");
            Console.ReadLine();
        }
    }
}
