using Decider.Csp.BaseTypes;
using Decider.Csp.Global;
using Decider.Csp.Integer;

VariableInteger[] p = new VariableInteger[19];
List<IConstraint> constraints = new List<IConstraint>();

for(int i = 0; i < 19; i++)
    p[i] = new VariableInteger("p_" + i, 1, 19); 
constraints.Add(new AllDifferentInteger(p));

VariableInteger s = new VariableInteger("s", 38, 38);

constraints.Add(new ConstraintInteger(p[0] + p[1] + p[2] == s));
constraints.Add(new ConstraintInteger(p[3] + p[4] + p[5] + p[6] == s));
constraints.Add(new ConstraintInteger(p[7] + p[8] + p[9] + p[10] + p[11] == s));
constraints.Add(new ConstraintInteger(p[12] + p[13] + p[14] + p[15] == s));
constraints.Add(new ConstraintInteger(p[16] + p[17] + p[18] == s));

constraints.Add(new ConstraintInteger(p[0] + p[3] + p[7] == s));
constraints.Add(new ConstraintInteger(p[1] + p[4] + p[8] + p[12] == s));
constraints.Add(new ConstraintInteger(p[2] + p[5] + p[9] + p[13] + p[16] == s));
constraints.Add(new ConstraintInteger(p[6] + p[10] + p[14] + p[17] == s));
constraints.Add(new ConstraintInteger(p[11] + p[15] + p[18] == s));

constraints.Add(new ConstraintInteger(p[2] + p[6] + p[11] == s));
constraints.Add(new ConstraintInteger(p[1] + p[5] + p[10] + p[15] == s));
constraints.Add(new ConstraintInteger(p[0] + p[4] + p[9] + p[14] + p[18] == s));
constraints.Add(new ConstraintInteger(p[3] + p[8] + p[13] + p[17] == s));
constraints.Add(new ConstraintInteger(p[7] + p[12] + p[16] == s));

IState<int> state = new StateInteger(p, constraints);
state.StartSearch(out StateOperationResult searchResult);

Console.WriteLine("      {0,2}    {1,2}    {2,2}", p[0], p[1], p[2]);        
Console.WriteLine("   {0,2}    {1,2}    {2,2}    {3,2}", p[3], p[4], p[5], p[6]);        
Console.WriteLine("{0,2}    {1,2}    {2,2}    {3,2}    {4,2}", p[7], p[8], p[9], p[10], p[11]);        
Console.WriteLine("   {0,2}    {1,2}    {2,2}    {3,2}", p[12], p[13], p[14], p[15]);        
Console.WriteLine("      {0,2}    {1,2}    {2,2}", p[16], p[17], p[18]);        

Console.WriteLine("Runtime: {0}", state.Runtime);
Console.WriteLine("Backtracks: {0}", state.Backtracks);