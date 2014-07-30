using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BMS;

namespace BMS.Test
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				BMS bms = Reader.ReadFile("bms/-+_H.bme");
				//BMS bms = BMSReader.Read("#WAV01 hoge\n#WAV02 hogehoge\n");
				System.Console.WriteLine(bms.Wav.Keys.Contains(1) ? bms.Wav[1] : null);
				System.Console.WriteLine(bms.Wav.Keys.Contains(2) ? bms.Wav[2] : null);
			}
			catch (ParseException)
			{
				System.Console.WriteLine("parse failed");
			}
		}
	}
}
