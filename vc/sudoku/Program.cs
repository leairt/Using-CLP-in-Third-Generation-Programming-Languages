using Decider.Csp.BaseTypes;
using Decider.Csp.Global;
using Decider.Csp.Integer;

int[] a = new int[] {
    8, 0, 0, 0, 0, 0, 0, 0, 0,
    0, 0, 3, 6, 0, 0, 0, 0, 0,
    0, 7, 0, 0, 9, 0, 2, 0, 0,
    0, 5, 0, 0, 0, 7, 0, 0, 0,
    0, 0, 0, 0, 4, 5, 7, 0, 0,
    0, 0, 0, 1, 0, 0, 0, 3, 0,
    0, 0, 1, 0, 0, 0, 0, 6, 8,
    0, 0, 8, 5, 0, 0, 0, 1, 0,
    0, 9, 0, 0, 0, 0, 4, 0, 0,
};

VariableInteger[] p = new VariableInteger[81];
List<IConstraint> constraints = new List<IConstraint>();

for(int i = 0; i < 9; i++)
    for(int j = 0; j < 9; j++) {
        int k = i*9 + j;
        if(a[k] == 0) 
            p[k] = new VariableInteger("p" + k, 1, 9); // prazna polja
        else 
            p[k] = new VariableInteger("p" + k, a[k], a[k]); // popunjena polja
    }

for(int i = 0; i < 9; i++) {
    VariableInteger[] row = new VariableInteger[9];
    for(int j = 0; j < 9; j++) 
        row[j] = p[i*9 + j];
    constraints.Add(new AllDifferentInteger(row));
}

for(int j = 0; j < 9; j++) {
    VariableInteger[] col = new VariableInteger[9];
    for(int i = 0; i < 9; i++) 
        col[i] = p[i*9 + j];
    constraints.Add(new AllDifferentInteger(col));
}

for(int i = 0; i < 9; i+=3) 
    for(int j = 0; j < 9; j+=3) {
        int k = i*9 + j;
        VariableInteger[] box = new[] {  
            p[k + 0], p[k + 1], p[k + 2],  
            p[k + 9], p[k + 10], p[k + 11],  
            p[k + 18], p[k + 19], p[k + 20] 
        };
        constraints.Add(new AllDifferentInteger(box));
    }

IState<int> state = new StateInteger(p, constraints);
state.StartSearch(out StateOperationResult searchResult);

for(int i = 0; i < 9; i++) {
    for(int j = 0; j < 9; j++)
        Console.Write("{0} ", p[i*9 + j]);        
    Console.WriteLine();
}
Console.WriteLine("Runtime: {0}", state.Runtime);
Console.WriteLine("Backtracks: {0}", state.Backtracks);