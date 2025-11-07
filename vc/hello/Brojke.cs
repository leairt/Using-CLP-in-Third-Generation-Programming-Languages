class Brojke {
    public static String generate() {
        Random rnd = new Random();

        int[] numbers = new int[6];
        numbers[0] = rnd.Next(1,9);
        numbers[1] = rnd.Next(1,9);
        numbers[2] = rnd.Next(1,9);
        numbers[3] = rnd.Next(1,9);
        var list1 = new List<int> { 10, 15, 20, 25};
        var list2 = new List<int> { 25, 50, 75, 100};
        numbers[4] = list1[rnd.Next(list1.Count)];
        numbers[5] = list2[rnd.Next(list2.Count)];

        int number = rnd.Next(100,999);

        Console.WriteLine("\nNumbers: {0}, {1}, {2}, {3}, {4}, {5}", numbers[0], numbers[1], numbers[2], numbers[3], numbers[4], numbers[5]);
        Console.WriteLine("Goal: {0}\n", number);

        return solve(numbers, number);
    }

	public static String solve(int[] numbers, int number) {
        String min_expr = "";
		int result = 0;
		
		var permutations = File.ReadLines("data/permutations.txt");
		for(int i = 1; i <= 6; i++) {
			var exprList = File.ReadLines("data/exprTrees" + i + ".txt");
			var operList = File.ReadLines("data/operList" + (i-1) + ".txt");			
			
			foreach(String p in permutations) 
				foreach(String expr in exprList)
					foreach(String oper in operList) {                        
            			// izbaci operaciju deljenja (da je brže)
                        // if(oper.Contains("/"))
                        //    continue;

						var postfix = toPostfix(p, expr, oper, numbers);
						try {
							int value = evaluate(postfix);						
							if(Math.Abs(number - value) < Math.Abs(number - result)) {
								result = value;
								min_expr = toInfix(postfix); 

								// ispišemo najbolje rezultate do sada
								// Console.WriteLine(min_expr + "=" + result);
								
								if(result == number) // našli smo jedno rešenje, to ne moramo dalje da tražimo
									return min_expr + "=" + result;
							}
						}
						catch(Exception) {
                            // Ignoriši
                        };
					}
		}
		return min_expr + "=" + result;
    }

    // ova funkcija ispisuje i nepotrebne zagrade - ispod je napravljena malo komplikovanija ali bolja
    /*
	private static String toInfix(List<String> postfix) {
		var stack = new Stack<String>();
		
		foreach(String exp in postfix) {
			if (isOperand(exp)) {
				String op1 = stack.Pop();
				String op2 = stack.Pop();
				String s = "(" + op1 + exp + op2 + ")";
				stack.Push(s);
			}
			else 
				stack.Push(exp);
		}
		return stack.Peek();
	}
    */

	private static int evaluate(List<String> postfix) {
		var stack = new Stack<String>();
		foreach(String s in postfix) {
			if(isOperand(s)) {
				int a = Int32.Parse(stack.Pop());
				int b = Int32.Parse(stack.Pop());
				stack.Push("" + calculate(s, a, b));
			}
			else 
				stack.Push(s);
		}
		return Int32.Parse(stack.Pop());
	}  

	private static int calculate(String s, int a, int b) {
		switch(s) {
		case "+":
			return a + b;
		case "-":
			return a - b;
		case "*":
			return a * b;
		case "/":
			if(a % b == 0)
				return a / b;
            break;            
		}
        throw new Exception();
	}

	static bool isOperand(String s) {
		switch(s) {
		case "+":
		case "-":
		case "*":
		case "/":
			return true;
		}
		return false;
	}

	private static List<String> toPostfix(String perm, String expr, String oper, int[] numbers) {		
		var postfix = new List<String>();

		int oper_index = 0;
		int value_index = 0;
		
		foreach(char ch in expr) {
			switch(ch) {
			case '#': // value
				int value = numbers[perm[value_index++] - '0'];
				postfix.Add("" + value);
				break;
			case 'X': // operand
				postfix.Add("" + oper[oper_index++]);
				break;
			}
		}
		return postfix;
	}

    // ovo ispod je samo, da se izraz napiše sa što manje zagrada
    // https://www.codeproject.com/Articles/405361/Converting-Postfix-Expressions-to-Infix

    public class Intermediate
    {
        public string expr;     // subexpression string
        public string oper;     // the operator used to create this expression

        public Intermediate(string expr, string oper) {
            this.expr = expr;
            this.oper = oper;
        }
    }

    private static String toInfix(List<String> postfix)
    {
        // Create stack for holding intermediate infix expressions
        var stack = new Stack<Intermediate>();

        foreach(string token in postfix) {
            if (token == "+" || token == "-") {
                // Get the left and right operands from the stack.
                // Note that since + and - are lowest precedence operators,
                // we do not have to add any parentheses to the operands.
                var rightIntermediate = stack.Pop();
                var leftIntermediate = stack.Pop();

                // construct the new intermediate expression by combining the left and right 
                // expressions using the operator (token).
                var newExpr = rightIntermediate.expr + token + leftIntermediate.expr;

                // Push the new intermediate expression on the stack
                stack.Push(new Intermediate(newExpr, token));
            }
            else if (token == "*" || token == "/") {
                string leftExpr, rightExpr;
                
                // Get the intermediate expressions from the stack.  
                // If an intermediate expression was constructed using a lower precedent
                // operator (+ or -), we must place parentheses around it to ensure 
                // the proper order of evaluation.
                
                var rightIntermediate = stack.Pop();
                if (rightIntermediate.oper == "+" || rightIntermediate.oper == "-")
                    rightExpr = "(" + rightIntermediate.expr + ")";
                else
                    rightExpr = rightIntermediate.expr;

                var leftIntermediate = stack.Pop();
                if (leftIntermediate.oper == "+" || leftIntermediate.oper == "-")
                    leftExpr = "(" + leftIntermediate.expr + ")";
                else
                    leftExpr = leftIntermediate.expr;

                // construct the new intermediate expression by combining the left and right 
                // using the operator (token).
                var newExpr = rightExpr + token + leftExpr;

                // Push the new intermediate expression on the stack
                stack.Push(new Intermediate(newExpr, token));
            }
            else  {
                // Must be a number. Push it on the stack.
                stack.Push(new Intermediate(token, ""));
            }
        }

        // The loop above leaves the final expression on the top of the stack.
        return stack.Peek().expr;
    }
}   