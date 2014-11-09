using System;
using System.Collections.Generic;

namespace Algorithm4thEdition.ChapterOne
{
	public class ChapterOne_1_3_10
	{
		private static Dictionary<char, int> priority = new Dictionary<char, int>();

		public static void Main()
		{
			// firstly, we need to define the priority of different operator
			priority.Add('+', 1);
			priority.Add('-', 1);
			priority.Add('*', 2);
			priority.Add('/', 2);

			InOrderExpToPostOrderExp("2*3/(2-1)+3*(4-1)");
			Console.WriteLine();
			InOrderExpToPostOrderExp("2*3");
			Console.WriteLine();
			InOrderExpToPostOrderExp("()");
			Console.WriteLine();
			InOrderExpToPostOrderExp("2*(3/(2-1))+3*(4-1)");
			Console.WriteLine();

			// error
			InOrderExpToPostOrderExp("(2*3");
			Console.WriteLine();
			InOrderExpToPostOrderExp("2*3)");
			Console.WriteLine();
		}

		// Try to convert an in order expresion to its post order expression
		public static void InOrderExpToPostOrderExp(string inOrderExpr)
		{
			Stack<char> s_operator = new Stack<char>();

			for(int i = 0; i < inOrderExpr.Length; i++)
			{
				char current = inOrderExpr[i];

				if(current == '(')
				{
					s_operator.Push(current);
				}
				else if(IsArithmeticOperator(current))
				{
					if(s_operator.Count > 0 && s_operator.Peek() != '('
						&& priority[s_operator.Peek()] >= priority[current])
					{
						Console.Write(s_operator.Pop());
					}
					s_operator.Push(current);
				}
				else if(Char.IsDigit(current))
				{
					Console.Write(current);
				}
				else if(current == ')')
				{				
					bool leftMatchFound = false;

					while(s_operator.Count > 0)
					{
						if(s_operator.Peek() != '(')
						{
							Console.Write(s_operator.Pop());
						}
						else
						{
							leftMatchFound = true;
							s_operator.Pop();

							// as expected, if we meet a ')', we must have a
							// corresponding '(', so if we find it, then we
							// can break the loop
							break;
						}
					}

					if(!leftMatchFound)
					{
						Console.WriteLine("Left brace doesn't match!");
					}
				}
				else
				{
					Console.WriteLine("Illegal character found!");
				}
			}

			// after the for loop, there maybe be operators left in s_operator,
			// we need to output them all
			while(s_operator.Count != 0)
			{
				// impossible to see the ')'
				if(s_operator.Peek() == '(')
				{
					Console.WriteLine("Right brace doesn't match!");
					break;	
				}

				Console.Write(s_operator.Pop());
			}			
		}

		// helper function, check if current char is a one of four fundmental operators 
		public static bool IsArithmeticOperator(char c)
		{
			return c == '+' || c == '-' || c == '*' || c == '/'; 
		}
	}
}