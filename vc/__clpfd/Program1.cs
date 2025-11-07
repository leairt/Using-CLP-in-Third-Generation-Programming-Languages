using Decider.Csp.BaseTypes;
using Decider.Csp.Global;
using Decider.Csp.Integer;
using System;
using System.Collections.Generic;

namespace CLPFD
{
    class Program1
    {
        static void Main(string[] args)
        {
            var s = new VariableInteger("s", 1, 9);
            var e = new VariableInteger("e", 0, 9);
            var n = new VariableInteger("n", 0, 9);
            var d = new VariableInteger("d", 0, 9);
            var m = new VariableInteger("m", 1, 9);
            var o = new VariableInteger("o", 0, 9);
            var r = new VariableInteger("r", 0, 9);
            var y = new VariableInteger("y", 0, 9);

            var variables = new[] { s, e, n, d, m, o, r, y };

            var constraints = new List<IConstraint>
            {
                new AllDifferentInteger(variables),
                new ConstraintInteger(  s*1000 + e*100 + n*10 + d 
                                    +   m*1000 + o*100 + r*10 + e == 
                                        m*10000 + o*1000 + n*100 + e*10 + y)
            };

            IState<int> state = new StateInteger(variables, constraints);
            state.StartSearch(out StateOperationResult searchResult);

            Console.WriteLine("    {0} {1} {2} {3} ", s, e, n, d);
            Console.WriteLine("  + {0} {1} {2} {3} ", m, o, r, e);
            Console.WriteLine("  ---------");
            Console.WriteLine("  {0} {1} {2} {3} {4} ", m, o, n, e, y);

            Console.WriteLine("\nRuntime:\t{0}\nBacktracks:\t{1}\n", state.Runtime, state.Backtracks);
        }
    }
}
