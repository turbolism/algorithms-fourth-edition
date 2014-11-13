using System;
using System.IO;

namespace Algorithm4thEdition.ChapterOne
{
	public class Program
	{
		public static void Main()
		{
			PrintDirectoryTree(new DirectoryInfo("/Users/Amalur/GitHub/"), 0);
		}

		// print the directory structure of specific path
		// if the directory doesn't exist, then create one, and print it
		public static void PrintDirectoryTree(DirectoryInfo path, int indentLevel /* indent space */)
		{
			if(!Directory.Exists(path.FullName))
			{
				DirectoryInfo newDir = Directory.CreateDirectory(path.FullName);
				PrintDirectoryTree(newDir, 0);
			}

			foreach(var entry in path.GetFileSystemInfos())
			{
				if((entry.Attributes & FileAttributes.Directory) != FileAttributes.Directory)
				{
					PrintFileSystemItem(entry, indentLevel);
				}
				else
				{
					PrintFileSystemItem(entry, indentLevel);

					// DO NOT pass ++indentLevel as param, this will change value in current level
					PrintDirectoryTree((DirectoryInfo)entry, indentLevel + 1);
				}
			}
		}

		private static void PrintFileSystemItem(FileSystemInfo fsi, int indentLevel)
		{

			for(int i = 0; i < indentLevel; i++)
			{
				Console.Write(" ");
			}

			Console.WriteLine(fsi.Name);
		}
	}
}