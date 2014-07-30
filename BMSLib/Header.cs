using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMS
{
	class HeaderInt : Header<CommandKey.Int, int>, ICommand
	{
		public HeaderInt(CommandKey.Int command, int value)
			: base(command, value) { }

		public void ApplyTo(BMSBuilder builder)
		{
			switch (Command)
			{
				case CommandKey.Int.Player:
					builder.Player = Value;
					break;
				case CommandKey.Int.BPM:
					builder.BPM = Value;
					break;
				case CommandKey.Int.PlayLevel:
					builder.PlayLevel = Value;
					break;
				case CommandKey.Int.Rank:
					builder.Rank = Value;
					break;
				case CommandKey.Int.VolWav:
					builder.VolWav = Value;
					break;
				case CommandKey.Int.Total:
					builder.Total = Value;
					break;
				case CommandKey.Int.Random:
					builder.Random = Value;
					break;
			}
		}
	}
	class HeaderString : Header<CommandKey.String, string>, ICommand
	{
		public HeaderString(CommandKey.String command, string value)
			: base(command, value) { }

		public void ApplyTo(BMSBuilder builder)
		{
			switch (Command)
			{
				case CommandKey.String.Genre:
					builder.Genre = Value;
					break;
				case CommandKey.String.Title:
					builder.Title = Value;
					break;
				case CommandKey.String.Artist:
					builder.Artist = Value;
					break;
				case CommandKey.String.MidiFile:
					builder.MidiFile = Value;
					break;
			}
		}
	}
	class HeaderStringDictionary : Header<CommandKey.StringDictionary, KeyValuePair<int, string>>, ICommand
	{
		public HeaderStringDictionary(CommandKey.StringDictionary command, KeyValuePair<int, string> value)
			: base(command, value) { }

		public void ApplyTo(BMSBuilder builder)
		{
			switch (Command)
			{
				case CommandKey.StringDictionary.Wav:
					builder.Wav[Value.Key] = Value.Value;
					break;
				case CommandKey.StringDictionary.Bmp:
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
