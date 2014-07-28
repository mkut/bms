﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using CSParsec;

namespace BMS
{
	public static class BMSReader
	{
		public static BMS ReadFile(string path)
		{
			using (StreamReader r = new StreamReader(new FileStream(path, FileMode.Open, FileAccess.Read)))
			{
				string str = r.ReadToEnd();
				return Read(str);
			}
		}
		public static BMS Read(string str)
		{
			try
			{
				BMS ret = bmsParser.Parse(str);
				return ret;
			}
			catch (ParseException)
			{
				throw new BMSParseException();
			}
		}

		private static readonly Parser<BMS> bmsParser =
			from headers in Line().Many()
			from eof in Combinator.Eof()
			select headers.Aggregate(new BMSBuilder(), (builder, command) => { command.ApplyTo(builder); return builder; }).Build();

		private static Parser<IBMSCommand> Line()
		{
			return Header()
				.Or(Channel())
				.Or(CommentLine())
				.Or(UnknownCommand());
		}

		private static Parser<IBMSCommand> CommentLine()
		{
			Parser<IBMSCommand> commentLine =
				from x in Char.NoneOf("#")
				from y in Text
				from z in Char.GenericNewline()
				select BMSCommand.Empty;
			return Char.GenericNewline().Select(any => BMSCommand.Empty).Or(commentLine);
		}

		private static Parser<IBMSCommand> Header()
		{
			return HeaderInt().Select(x => x as IBMSCommand)
				.Or(HeaderString().Select(x => x as IBMSCommand))
				.Or(HeaderStringDictionary().Select(x => x as IBMSCommand));
		}

		private static Parser<IBMSCommand> UnknownCommand()
		{
			System.Func<string, IBMSCommand> f = a =>
				{
					System.Console.WriteLine(a);
					return BMSCommand.Empty;
				};
			return
				from x in CommandHead
				from y in Text
				from z in Char.GenericNewline()
				select f(y);
		}

		private static Parser<HeaderInt> HeaderInt()
		{
			return
				from x in CommandHead
				from command in HeaderCommand<BMSCommandKey.Int>()
				from y in Separator
				from value in Char.Number()
				from z in Char.GenericNewline()
				select new HeaderInt(command, value);
		}
		private static Parser<HeaderString> HeaderString()
		{
			return
				from x in CommandHead
				from command in HeaderCommand<BMSCommandKey.String>()
				from y in Separator
				from value in Text
				from z in Char.GenericNewline()
				select new HeaderString(command, value);
		}
		private static Parser<HeaderStringDictionary> HeaderStringDictionary()
		{
			return
				from x in CommandHead
				from command in HeaderCommand<BMSCommandKey.StringDictionary>()
				from key in FixedNumberBase36(2)
				from y in Separator
				from value in Text
				from z in Char.GenericNewline()
				select new HeaderStringDictionary(command, new KeyValuePair<int, string>(key, value));
		}
		private static Parser<IBMSCommand> Channel()
		{
			return
				from x in CommandHead
				from measure in FixedNumber(3)
				from channel in FixedNumber(2)
				from y in Char.Character(':')
				from objects in FixedNumberBase36(2).Many1()
				from z in Char.GenericNewline()
				select new ChannelCommand(measure, channel, new List<int>(objects)) as IBMSCommand;
		}

		private static Parser<T> HeaderCommand<T>()
		{
			return
				Combinator.Choice(
					from key in System.Enum.GetValues(typeof(T)).OfType<T>()
					select Char.StringIgnoreCase(key.ToString()).Select(any => key)
					);
		}

		private static Parser<Unit> CommandHead
		{
			get
			{
				return Char.Character('#').Select(any => Unit.U);
			}
		}
		private static Parser<Unit> Separator
		{
			get
			{
				return Char.Character(' ').Or(Char.Tab()).Many1().Select(any => Unit.U);
			}
		}
		private static Parser<string> Text
		{
			get
			{
				return Char.NoneOf("\r\n").Many().Text();
			}
		}
		private static Parser<int> FixedNumber(int length)
		{
			return Char.Digit().Count(length).Text().Select(s => ParseBaseN(10, s));
		}
		private static Parser<int> FixedNumberBase36(int length)
		{
			return Char.AlphaNum().Count(length).Text().Select(s => ParseBaseN(36, s));
		}

		private static int ParseBaseN(int n, string str)
		{
			int ret = 0;
			foreach (char c in str)
			{
				if (System.Char.IsDigit(c))
				{
					ret = ret * n + c - '0';
				}
				else if (System.Char.IsLetter(c))
				{
					ret = ret * n + System.Char.ToUpper(c) - 'A' + 10;
				}
				else
				{
					throw new System.ArgumentException();
				}
			}
			return ret;
		}
	}
}
