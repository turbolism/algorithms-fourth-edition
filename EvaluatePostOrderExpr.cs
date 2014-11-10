using System;
using System.IO;
using System.Collections.Generic;

namespace Algorithm4thEdition.ChapterOne
{
	public class ChapterOne_1_3_11
	{
		public static void Main()
		{
			Console.WriteLine(EvaluatePostOrderExpr("23*21-/341-*+"));
		}

		// Just support fundamental four operators with integer operands (one digit),
		// it is not hard to extend its functionality.
		public static double EvaluatePostOrderExpr(string postOrderStr)
		{
			Stack<double> s_operand = new Stack<double>();

			/*
				1. read in next char.
				2. if current char is a digital number, then push it into s_operand stack.
				3. if current char is a operator, then we pop two operands out of stack.
				4. calculate result based on the operator.
				5. push the result in to the stack.
				6. loop 1 - 5. 

				finally, there will be only one result in the s_operand;
			*/

			for( int i = 0; i < postOrderStr.Length; i++ )
			{
				char current = postOrderStr[i];

				if(Char.IsDigit(current))
				{
					//Console.WriteLine(current - '0');
					s_operand.Push(current - '0');
					continue;
				}

				// if it is not digit, then with our assumption, it must be an binary operator.
				// so, we just need to pop two operands.
				try
				{
					double first = s_operand.Pop();
					double second = s_operand.Pop();
				
					switch(current)
					{
						case '+':
							s_operand.Push(Add(first, second));
							break;
						case '-':
							s_operand.Push(Minus(second, first));
							break;
						case '*':
							s_operand.Push(Multiply(first, second));
							break;
						case '/':
							s_operand.Push(Divide(second, first));
							break;
					}
				}
				catch(InvalidOperationException ex)
				{
					Console.WriteLine(ex);
				}
			}

			return s_operand.Pop();
		}

		private static double Add(double first, double second)
		{
			return first +  second;
		}

		private static double Minus(double first, double second)
		{
			return first - second;
		}

		private static double Multiply(double first, double second)
		{
			return first * second;
		}

		private static double Divide(double first, double second)
		{
			return first / second;
		}
	}
}