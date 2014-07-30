
namespace BMS.Resource
{
	public class BmpResourceType : IResourceType
	{
		private string ext;
		private BmpResourceType(string ext)
		{
			this.ext = ext;
		}

		public string ToExt() { return ext; }

		public static BmpResourceType BMP = new BmpResourceType("bmp");
		public static BmpResourceType MPG = new BmpResourceType("mpg");
	}
}
