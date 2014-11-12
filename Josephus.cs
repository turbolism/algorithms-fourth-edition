using System;
using System.Collections.Generic;

namespace Algorithm4thEdition.ChapterOne
{
	public class Josephus
	{
		private LinkedList<int> _all;

		// this referece always point to the start point for next round
		private LinkedListNode<int> _current;

		private int _gap;

		public Josephus(int length, int gap)
		{
			this._all = new LinkedList<int>();
			this._gap = gap;
			this.InitGame(length);
			this._current = this._all.First;

			// log
			foreach(var item in this._all)
			{
				Console.Write(item + " ");
			}
			Console.WriteLine();
			Console.WriteLine("Gap:" + this._gap);
			Console.WriteLine("First:" + this._all.First.Value);
			Console.WriteLine("Last:" + this._all.Last.Value);
		}

		public int GetNext()
		{
			if(this._current == null)
			{
				throw new InvalidOperationException("No More Round!");
			}

			LinkedListNode<int> nextStart = null;
			int returnValue = -1;

			// if only one node, then it is the last one
			if(this._all.First == this._all.Last)
			{
				returnValue = this._current.Value;
				this._all.Remove(this._current);
				this._current = nextStart;

				return returnValue;
			}
			else
			{
				// Two Steps:
				// 1. find the node to be removed
				// 2. Remove node and update Josephus state for next round

				for(int i = 0;i < this._gap - 1;i++)
				{
					this._current = this.MoveToNextPostion(this._current);
				}

				returnValue = this._current.Value;

				// remember that we are using linked list, not a cycle one
				// so we always need to check if we are out of range, at that time
				// we need to update the reference to a right state
				nextStart = this.MoveToNextPostion(this._current);

				this._all.Remove(this._current);

				// update state for next round
				this._current = nextStart;

				return returnValue;
			}
		}

		// help function that is used to move a specific pointer to the next
		// position in linked list, if next is null, we reset to the beginning
		private LinkedListNode<int> MoveToNextPostion(LinkedListNode<int> current)
		{
			if(current.Next != null)
			{
				return current.Next;
			}
			else
			{
				return this._all.First;
			}
		}

		private void InitGame(int length)
		{
			// generate a linked list
			for(int i = 0;i < length;i++)
			{
				this._all.AddLast(i);
			}
		}
	}

	public class Program
	{
		public static void Main()
		{
			Josephus josephus = new Josephus(7, 2);

			for(int i = 0; i < 7; i++)
			{
				Console.Write(josephus.GetNext() + " ");
			}

			Console.WriteLine();
		}
	}
}