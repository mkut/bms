using System;
using System.IO;

namespace BMS.Resource
{
	public class Resource<T>
		where T : IResourceType
	{
		public readonly T ResourceType;
		public readonly string Filename;

		public Resource(String filename)
		{
			foreach (var type in Enum.GetValues(typeof(T)))
			{
				string newFilename = ChangeExt(filename, (T)type);
				if (File.Exists(newFilename))
				{
					ResourceType = (T)type;
					Filename = newFilename;
					return;
				}
			}
			throw new FileNotFoundException();
		}

		public static string ChangeExt(string filename, T type)
		{
			int pos = filename.LastIndexOf(".");
			if (pos == -1)
			{
				return filename + "." + type.ToExt();
			}
			return filename.Substring(0, pos) + "." + type.ToExt();
		}
	}

	public interface IResourceType
	{
		string ToExt();
	}
}
