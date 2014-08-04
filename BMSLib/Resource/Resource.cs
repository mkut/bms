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
				string newFilename = Path.ChangeExtension(filename, ((T)type).ToExt());
				if (File.Exists(newFilename))
				{
					ResourceType = (T)type;
					Filename = newFilename;
					return;
				}
			}
			throw new FileNotFoundException();
		}
	}

	public interface IResourceType
	{
		string ToExt();
	}
}
