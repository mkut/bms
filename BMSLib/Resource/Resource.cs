using System;
using System.IO;
using System.Collections.Generic;

namespace BMS.Resource
{
	public class Resource<T>
		where T : IResourceType
	{
		public readonly T ResourceType;
		public readonly string Filename;

		public Resource(String filename)
		{
			foreach (var type in ResourceTypeEnum.TypeList(typeof(T)))
			{
				string newFilename = Path.ChangeExtension(filename, ((T)type).ToExt());
				System.Console.WriteLine(newFilename);
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

	public static class ResourceTypeEnum
	{
		public static IEnumerable<IResourceType> TypeList(Type type)
		{
			if (type == typeof(WavResourceType))
			{
				return WavResourceType.TypeList;
			}
			if (type == typeof(BmpResourceType))
			{
				return BmpResourceType.TypeList;
			}
			throw new ArgumentException();
		}
	}
}
