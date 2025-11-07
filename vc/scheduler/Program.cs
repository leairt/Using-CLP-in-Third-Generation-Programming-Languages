using Decider.Csp.BaseTypes;
using Decider.Csp.Global;
using Decider.Csp.Integer;

/*
Project project = new Project();
project.SetStartDate(2022, 10, 5);
project.AddTask(1, "Task 1", 4);
project.AddTask(2, "Task 2", 2);
project.AddTask(3, "Task 3", 3);
project.AddTask(4, "Task 4", 5);
project.AddTask(5, "Task 5", 3);
project.AddTask(6, "Task 6", 2);
project.OptimizeTasks();
project.WriteReport();

List<VariableInteger> variables = new List<VariableInteger>();
List<ConstraintInteger> constraints = new List<ConstraintInteger>();

VariableInteger a = new VariableInteger("a", 0, 20);
VariableInteger b = new VariableInteger("b", 0, 20);
VariableInteger c = new VariableInteger("c", 0, 20);
VariableInteger d = new VariableInteger("d", 0, 20);
VariableInteger e = new VariableInteger("e", 0, 20);
VariableInteger f = new VariableInteger("f", 0, 20);
VariableInteger opt = new VariableInteger("opt", 0, 1200);

variables.Add(a);
variables.Add(b);
variables.Add(c);
variables.Add(d);
variables.Add(e);
variables.Add(f);
variables.Add(opt);

// zavisnost
constraints.Add(new ConstraintInteger(a + 4 <= b)); // a je ispred b
constraints.Add(new ConstraintInteger(a + 4 <= c)); // a je ispred c
constraints.Add(new ConstraintInteger((a + 4 == b) | (a + 4 == c))); // a je ispred b i c
constraints.Add(new ConstraintInteger(a + 4 <= d)); // a je ispred d
constraints.Add(new ConstraintInteger(b + 2 <= d)); // b je ispred d
constraints.Add(new ConstraintInteger((a + 4 == d) | (b + 2 == d))); 
constraints.Add(new ConstraintInteger(a + 4 <= e)); // a je ispred e
constraints.Add(new ConstraintInteger(c + 3 <= e)); // c je ispred e
constraints.Add(new ConstraintInteger((a + 4 == e) | (c + 3 == e))); 
constraints.Add(new ConstraintInteger(d + 5 <= f)); // d je ispred f
constraints.Add(new ConstraintInteger(e + 3 <= f)); // e je ispred f
constraints.Add(new ConstraintInteger((d + 5 == f) | (e + 3 == f))); 

// zbir
constraints.Add(new ConstraintInteger(opt == a + b + c + d + e + f));

var state = new StateInteger(variables, constraints);

// if (state.Search(optimise, 10) == StateOperationResult.Unsatisfiable)
//	throw new ApplicationException("Cannot find a solution to constraint problem.");

var searchResult = state.SearchAllSolutions();

int r = 10000;
foreach (var solution in state.Solutions)
{
    if(solution["opt"].InstantiatedValue < r) {
        r = solution["opt"].InstantiatedValue;
        Console.WriteLine("A: {0}-{1}", solution["a"].InstantiatedValue, solution["a"].InstantiatedValue + 4);        
        Console.WriteLine("B: {0}-{1}", solution["b"].InstantiatedValue, solution["b"].InstantiatedValue + 2);        
        Console.WriteLine("C: {0}-{1}", solution["c"].InstantiatedValue, solution["c"].InstantiatedValue + 3);        
        Console.WriteLine("D: {0}-{1}", solution["d"].InstantiatedValue, solution["d"].InstantiatedValue + 5);        
        Console.WriteLine("E: {0}-{1}", solution["e"].InstantiatedValue, solution["e"].InstantiatedValue + 3);        
        Console.WriteLine("F: {0}-{1}", solution["f"].InstantiatedValue, solution["f"].InstantiatedValue + 2);        
        Console.WriteLine();
    }
}

Console.WriteLine("Runtime: {0}", state.Runtime);
Console.WriteLine("Backtracks: {0}", state.Backtracks);
*/

Console.WriteLine("Done.");