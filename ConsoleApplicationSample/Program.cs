using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;

namespace ConsoleApplicationSample {
	class Program {

		static string iKey = "PASTE YOUR IKEY";
		static TelemetryClient ctx = new TelemetryClient();


		static void Main(string[] args) {
            Microsoft.ApplicationInsights.Extensibility.TelemetryConfiguration.Active.InstrumentationKey = iKey;
			while(AskQuestion() ) {
			}
			Thread.Sleep(70000);
		}

		private static bool AskQuestion() {
			Console.WriteLine("Should I use APM? \r\n>>");

			DateTimeOffset date = DateTimeOffset.Now;
			Stopwatch sw = new Stopwatch();

			sw.Start();
			string answer  = Console.ReadLine();
			bool correctAnswer = answer == "Yes!";
			ctx.TrackRequest(answer, date, new TimeSpan(sw.ElapsedTicks), "200", correctAnswer);

			return !correctAnswer;
		}
	}
}
