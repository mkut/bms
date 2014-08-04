using System.Collections.Generic;

namespace BMS.Resource
{
	public class WavResourceType : IResourceType
	{
		private string ext;
		private WavResourceType(string ext)
		{
			this.ext = ext;
		}

		public string ToExt() { return ext; }

		public static WavResourceType WAV = new WavResourceType("wav");
		public static WavResourceType OGG = new WavResourceType("ogg");
		public static List<IResourceType> TypeList = new List<IResourceType> { WAV, OGG };
	}
}
