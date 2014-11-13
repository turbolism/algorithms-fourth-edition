using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm4thEdition.ChapterOne
{
	public class MoveToFront
	{
		public static void Main()
		{
			Console.WriteLine(MoveToFrontTransformation("aaaaaa"));
			Console.WriteLine(MoveToFrontTransformation("abcabcabc"));
			Console.WriteLine(MoveToFrontTransformation(""));
			Console.WriteLine(MoveToFrontTransformation("banana"));
		}

		// Move-To-Front Transformation
		/*
			1. Get next character from input
			2. Check if the character exist
				a. if it is there, then remove it and insert the new one.
				b. else just insert the character
			3. loop 1~2 until no more character.
		*/
		public static string MoveToFrontTransformation(string src)
		{
			if(src.Length == 0)
				return String.Empty;

			LinkedList<char> filter = new LinkedList<char>();

			for(int i = 0; i < src.Length; i++)
			{
				LinkedListNode<char> target = filter.Find(src[i]);

				if(target != null)
				{
					filter.Remove(target);
				}

				filter.AddFirst(src[i]);
			}

			// iterate the list and construct a return string
			StringBuilder sb = new StringBuilder();
			foreach(var item in filter)
			{
				sb.Insert(0, item);
			}

			return sb.ToString();
		}
	}
}