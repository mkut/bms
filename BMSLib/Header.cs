using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMS
{
	class HeaderInt : Header<BMSCommandKey.Int, int>, IBMSCommand
	{
		public HeaderInt(BMSCommandKey.Int command, int value)
			: base(command, value) { }

		public void ApplyTo(BMSBuilder builder)
		{
			switch (Command)
			{
				case BMSCommandKey.Int.Player:
					builder.Player = Value;
					break;
				case BMSCommandKey.Int.BPM:
					builder.BPM = Value;
					break;
				case BMSCommandKey.Int.PlayLevel:
					builder.PlayLevel = Value;
					break;
				case BMSCommandKey.Int.Rank:
					builder.Rank = Value;
					break;
				case BMSCommandKey.Int.VolWav:
					builder.VolWav = Value;
					break;
				case BMSCommandKey.Int.Total:
					builder.Total = Value;
					break;
				case BMSCommandKey.Int.Random:
					builder.Random = Value;
					break;
			}
		}
	}
	class HeaderString : Header<BMSCommandKey.String, string>, IBMSCommand
	{
		public HeaderString(BMSCommandKey.String command, string value)
			: base(command, value) { }

		public void ApplyTo(BMSBuilder builder)
		{
			switch (Command)
			{
				case BMSCommandKey.String.Genre:
					builder.Genre = Value;
					break;
				case BMSCommandKey.String.Title:
					builder.Title = Value;
					break;
				case BMSCommandKey.String.Artist:
					builder.Artist = Value;
					break;
				case BMSCommandKey.String.MidiFile:
					builder.MidiFile = Value;
					break;
			}
		}
	}
	class HeaderStringDictionary : Header<BMSCommandKey.StringDictionary, KeyValuePair<int, string>>, IBMSCommand
	{
		public HeaderStringDictionary(BMSCommandKey.StringDictionary command, KeyValuePair<int, string> value)
			: base(command, value) { }

		public void ApplyTo(BMSBuilder builder)
		{
			switch (Command)
			{
				case BMSCommandKey.StringDictionary.Wav:
					builder.Wav[Value.Key] = Value.Value;
					break;
				case BMSCommandKey.StringDictionary.Bmp:
					builder.Bmp[Value.Key] = Value.Value;
					break;
			}
		}
	}

	class Header<TK, T>
	{
		public readonly TK Command;
		public readonly T Value;

		public Header(TK command, T value)
		{
			Command = command;
			Value = value;
		}

	}
}
