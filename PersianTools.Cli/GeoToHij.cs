using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using Persia;
using System.Globalization;

namespace PersianTools.Cli
{
    [MemoryDiagnoser]
    public class GeoToHij
    {
        private readonly DateTime _dateTime;

        public GeoToHij()
        {
            _dateTime = DateTime.Now;
        }

        [Benchmark]
        public Persia.SolarDate PeriaMethod() => Persia.Calendar.ConvertToPersian(_dateTime);

        [Benchmark]
        public HijriDateTime HosseinMethod() => PersianTools.Calendar.ToHijri(_dateTime);

        [Benchmark]
        public int MicrosoftMethod()
        {
            return new PersianCalendar().GetYear(_dateTime);
        }
    }
}
