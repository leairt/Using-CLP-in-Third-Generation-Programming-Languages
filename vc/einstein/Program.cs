using Decider.Csp.BaseTypes;
using Decider.Csp.Global;
using Decider.Csp.Integer;
using Model;

Dictionary<Pet, VariableInteger> pet = new Dictionary<Pet, VariableInteger>();
Dictionary<Drink, VariableInteger> drink = new Dictionary<Drink, VariableInteger>();
Dictionary<Color, VariableInteger> color = new Dictionary<Color, VariableInteger>();
Dictionary<Nation, VariableInteger> nation = new Dictionary<Nation, VariableInteger>();
Dictionary<Cigarette, VariableInteger> cigarette = new Dictionary<Cigarette, VariableInteger>();

VariableInteger[] vars = new VariableInteger[25];

int k = 0;
foreach (Pet value in Enum.GetValues(typeof(Pet))) {
   pet[value] = new VariableInteger("" + value, 1, 5);
   vars[k++] = pet[value];
}
foreach (Drink value in Enum.GetValues(typeof(Drink))) {
   drink[value] = new VariableInteger("" + value, 1, 5);
   vars[k++] = drink[value];
}
foreach (Color value in Enum.GetValues(typeof(Color))) {
   color[value] = new VariableInteger("" + value, 1, 5);
   vars[k++] = color[value];
}
foreach (Nation value in Enum.GetValues(typeof(Nation))) {
   nation[value] = new VariableInteger("" + value, 1, 5);
   vars[k++] = nation[value];
}
foreach (Cigarette value in Enum.GetValues(typeof(Cigarette))) {
   cigarette[value] = new VariableInteger("" + value, 1, 5);
   vars[k++] = cigarette[value];
}

List<IConstraint> constraints = new List<IConstraint>();

constraints.Add(new AllDifferentInteger(pet.Values));
constraints.Add(new AllDifferentInteger(drink.Values));
constraints.Add(new AllDifferentInteger(color.Values));
constraints.Add(new AllDifferentInteger(nation.Values));
constraints.Add(new AllDifferentInteger(cigarette.Values));

// the Brit lives in the red house
constraints.Add(new ConstraintInteger(nation[Nation.ENGLISHMAN] == color[Color.RED]));
// the Swede keeps dogs as pets
constraints.Add(new ConstraintInteger(nation[Nation.SWEDE] == pet[Pet.DOGS]));
// the Dane drinks tea
constraints.Add(new ConstraintInteger(nation[Nation.DANE] == drink[Drink.TEA]));
// the green house is on the left of the white house
constraints.Add(new ConstraintInteger(color[Color.GREEN] + 1 == color[Color.WHITE]));
// the green house's owner drinks coffee
constraints.Add(new ConstraintInteger(color[Color.GREEN] == drink[Drink.COFFEE]));
// the person who smokes Pall Mall rears birds
constraints.Add(new ConstraintInteger(cigarette[Cigarette.PALLMALL] == pet[Pet.BIRDS]));
// the owner of the yellow house smokes Dunhill
constraints.Add(new ConstraintInteger(color[Color.YELLOW] == cigarette[Cigarette.DUNHILL]));
// the man living in the center house drinks milk
constraints.Add(new ConstraintInteger(drink[Drink.MILK] == 3));
// the Norwegian lives in the first house
constraints.Add(new ConstraintInteger(nation[Nation.NORWEGIAN] == 1));
// the man who smokes blends lives next to the one who keeps cats
constraints.Add(new ConstraintInteger((cigarette[Cigarette.BLEND] + 1 == pet[Pet.CATS]) | (cigarette[Cigarette.BLEND] - 1 == pet[Pet.CATS])));
// the man who keeps horses lives next to the man who smokes Dunhill
constraints.Add(new ConstraintInteger((cigarette[Cigarette.DUNHILL] + 1 == pet[Pet.HORSES]) | (cigarette[Cigarette.DUNHILL] - 1 == pet[Pet.HORSES])));
// the owner who smokes BlueMaster drinks beer
constraints.Add(new ConstraintInteger(cigarette[Cigarette.BLUEMASTER] == drink[Drink.BEER]));
// the German smokes Prince
constraints.Add(new ConstraintInteger(nation[Nation.GERMAN] == cigarette[Cigarette.PRINCE]));
// the Norwegian lives next to the blue house
constraints.Add(new ConstraintInteger((nation[Nation.NORWEGIAN] + 1 == color[Color.BLUE]) | (nation[Nation.NORWEGIAN] - 1 == color[Color.BLUE])));
// the man who smokes blend has a neighbor who drinks water
constraints.Add(new ConstraintInteger((cigarette[Cigarette.BLEND] + 1 == drink[Drink.WATER]) | (cigarette[Cigarette.BLEND] - 1 == drink[Drink.WATER])));

IState<int> state = new StateInteger(vars, constraints);
state.StartSearch(out StateOperationResult searchResult);

for(int i = 1; i <= 5; i++) {
   Console.Write("House {0}: ", i); 
   foreach(Nation item in nation.Keys)
      if(nation[item].Value == i)
         Console.Write("{0}, ", item); 
   foreach(Pet item in pet.Keys) 
      if(pet[item].Value == i)
         Console.Write("{0}, ", item); 
   foreach(Drink item in drink.Keys) 
      if(drink[item].Value == i)
         Console.Write("{0}, ", item); 
   foreach(Cigarette item in cigarette.Keys) 
      if(cigarette[item].Value == i)
         Console.Write("{0}, ", item); 
   foreach(Color item in color.Keys) 
      if(color[item].Value == i)
         Console.Write("{0} ", item); 
   Console.WriteLine();
}

Console.WriteLine("Runtime: {0}", state.Runtime);
Console.WriteLine("Backtracks: {0}", state.Backtracks);