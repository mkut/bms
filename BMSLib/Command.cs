using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSParsec;

namespace BMS
{
	public static class Command
	{
		public static ICommand Empty = new EmptyCommand();
	}

	internal class EmptyCommand : ICommand
	{
		internal EmptyCommand() { }
		public void ApplyTo(BMS.Builder builder) { }
	}

	public static class CommandKey
	{
		public enum Int
		{
			Player,
			BPM,
			PlayLevel,
			Rank,
			VolWav,
			Total,
			Random,
		}
		public enum String
		{
			Genre,
			Title,
			Artist,
			MidiFile,
		}
		public enum StringDictionary
		{
			Wav,
			Bmp,
		}
	}
}
