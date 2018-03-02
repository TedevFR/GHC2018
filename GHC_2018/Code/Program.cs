using System;

namespace GHC_2018.Code
{
    class Program
    {
        const string inputFilePathA = "Inputs/a_example.in";
        const string inputFilePathB = "Inputs/b_should_be_easy.in";
        const string inputFilePathC = "Inputs/c_no_hurry.in";
        const string inputFilePathD = "Inputs/d_metropolis.in";
        const string inputFilePathE = "Inputs/e_high_bonus.in";

        const string outputFilePathA = "Outputs/a_example.out";
        const string outputFilePathB = "Outputs/b_should_be_easy.out";
        const string outputFilePathC = "Outputs/c_no_hurry.out";
        const string outputFilePathD = "Outputs/d_metropolis.out";
        const string outputFilePathE = "Outputs/e_high_bonus.out";

        static void Main(string[] args)
        {
            Solve(inputFilePathA, outputFilePathA);
            Solve(inputFilePathB, outputFilePathB);
            Solve(inputFilePathC, outputFilePathC);
            Solve(inputFilePathD, outputFilePathD);
            Solve(inputFilePathE, outputFilePathE);

            Console.WriteLine("CON CON CON CON CONCHITA !");
            Console.ReadKey();
        }

        private static void Solve(string inputFilePathExample, string outputFilePathExample)
        {
            Solver solver = new Solver(inputFilePathExample, outputFilePathExample);
            solver.Solve();
        }
    }
}