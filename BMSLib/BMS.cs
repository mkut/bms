using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using CSParsec;

namespace BMS
{
	public class BMS
	{
		public readonly int Player;
		public readonly string Genre;
		public readonly string Title;
		public readonly string Artist;
		public readonly int BPM;
		public readonly string MidiFile;
		public readonly int PlayLevel;
		public readonly int Rank;
		public readonly int VolWav;
		public readonly Dictionary<int, string> Wav;
		public readonly Dictionary<int, string> Bmp;
		public readonly int Total;
		public readonly int Random;
		// if
		// endif
		// extchr
		public readonly Dictionary<int, Dictionary<int, List<List<int>>>> Objects;

		internal BMS(int player,
			string genre,
			string title,
			string artist,
			int bpm,
			string midiFile,
			int playLevel,
			int rank,
			int volWav,
			Dictionary<int, string> wav,
			Dictionary<int, string> bmp,
			int total,
			int random,
			Dictionary<int, Dictionary<int, List<List<int>>>> objects)
		{
			Player = player;
			Genre = genre;
			Title = title;
			Artist = artist;
			BPM = bpm;
			MidiFile = midiFile;
			PlayLevel = playLevel;
			Rank = rank;
			VolWav = volWav;
			Wav = new Dictionary<int, string>(wav);
			Bmp = new Dictionary<int, string>(bmp);
			Total = total;
			Random = random;
			Objects = new Dictionary<int, Dictionary<int, List<List<int>>>>(objects);
		}
	}

	public class BMSBuilder
	{
		public int Player;
		public string Genre;
		public string Title;
		public string Artist;
		public int BPM;
		public string MidiFile;
		public int PlayLevel;
		public int Rank;
		public int VolWav;
		public Dictionary<int, string> Wav { get; private set; }
		public Dictionary<int, string> Bmp { get; private set; }
		public int Total;
		public int Random;
		public Dictionary<int, Dictionary<int, List<List<int>>>> Objects { get; private set; }

		public BMSBuilder()
		{
			Wav = new Dictionary<int, string>();
			Bmp = new Dictionary<int, string>();
			Objects = new Dictionary<int, Dictionary<int, List<List<int>>>>();
		}

		public BMS Build()
		{
			return new BMS(
				Player,
				Genre,
				Title,
				Artist,
				BPM,
				MidiFile,
				PlayLevel,
				Rank,
				VolWav,
				Wav,
				Bmp,
				Total,
				Random,
				Objects);
		}
	}

	public interface ICommand
	{
		void ApplyTo(BMSBuilder builder);
	}

	public static class Command
	{
		public static ICommand Empty = new EmptyCommand();
	}

	internal class EmptyCommand : ICommand
	{
		internal EmptyCommand() { }
		public void ApplyTo(BMSBuilder builder) { }
	}
}
