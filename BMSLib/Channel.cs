using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMS
{
	class ChannelCommand : ICommand
	{
		public int Measure;
		public int Channel;
		public List<int> Objects { get; private set; }

		public ChannelCommand(int measure, int channel, List<int> objects)
		{
			Measure = measure;
			Channel = channel;
			Objects = new List<int>(objects);
		}

		public void ApplyTo(BMSBuilder builder)
		{
			if (!builder.Objects.ContainsKey(Channel))
			{
				builder.Objects[Channel] = new Dictionary<int, List<List<int>>>();
			}
			if (!builder.Objects[Channel].ContainsKey(Measure))
			{
				builder.Objects[Channel][Measure] = new List<List<int>>();
			}
			builder.Objects[Channel][Measure].Add(new List<int>(Objects));
		}
	}
}
