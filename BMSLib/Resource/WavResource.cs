
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

		public static WavResourceType BMP = new WavResourceType("wav");
		public static WavResourceType MPG = new WavResourceType("ogg");
	}
}
