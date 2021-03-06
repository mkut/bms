﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using CSParsec;
using BMS.Resource;

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
		public readonly Dictionary<int, Resource<WavResourceType>> Wav;
		public readonly Dictionary<int, Resource<BmpResourceType>> Bmp;
		public readonly int Total;
		public readonly int Random;
		// if
		// endif
		// extchr
		public readonly Dictionary<int, Dictionary<int, List<List<int>>>> Objects;

		internal BMS(
			int player,
			string genre,
			string title,
			string artist,
			int bpm,
			string midiFile,
			int playLevel,
			int rank,
			int volWav,
			Dictionary<int, Resource<WavResourceType>> wav,
			Dictionary<int, Resource<BmpResourceType>> bmp,
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
			Wav = new Dictionary<int, Resource<WavResourceType>>(wav);
			Bmp = new Dictionary<int, Resource<BmpResourceType>>(bmp);
			Total = total;
			Random = random;
			Objects = new Dictionary<int, Dictionary<int, List<List<int>>>>(objects);
		}

		public class Builder
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
			public Dictionary<int, Resource<WavResourceType>> Wav { get; private set; }
			public Dictionary<int, Resource<BmpResourceType>> Bmp { get; private set; }
			public int Total;
			public int Random;
			public Dictionary<int, Dictionary<int, List<List<int>>>> Objects { get; private set; }

			public Builder()
			{
				Wav = new Dictionary<int, Resource<WavResourceType>>();
				Bmp = new Dictionary<int, Resource<BmpResourceType>>();
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
	}

	public interface ICommand
	{
		void ApplyTo(BMS.Builder builder);
	}
}
