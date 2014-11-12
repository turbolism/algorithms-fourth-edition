using System;

namespace Algorithm4thEdition.Utils.Collections
{
	public class Stack<T>
	{
		private class Node
		{
			public T data;
			public Node next;
		}

		// the top element of the stack, for linked list
		// it is the first elemnt
		private Node _top;
		private int _count;

		public bool IsEmpty()
		{
			return this._top == null;
		}

		// get the size of current stack
		public int Size()
		{
			return this._count;
		}

		public void Push(T element)
		{
			Node preTop = this._top;
		 	this._top = new Node();
		 	this._top.data = element;
		 	this._top.next = preTop;
		 	this._count++;
		}

		public T Pop()
		{
			if(this.IsEmpty())
			{
				throw new InvalidOperationException("Empty Stack!");
			}

			T data = this._top.data;
			this._top = this._top.next;
			this._count--;

			return data;
		}
	}

	public class Program
	{
		public static void Main()
		{
			Stack<int> test = new Stack<int>();
			test.Push(1);
			test.Push(2);

			Console.WriteLine(test.Size());

			test.Pop();
			Console.WriteLine(test.Size());
		}
	}
}