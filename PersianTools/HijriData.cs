using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace PersianTools
{
    public readonly struct HijriDateTime
    {
        public HijriDateTime(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }

        public int Day { get; }
        public int Month { get; }
        public int Year { get; }

        public string ToString() => $"{Year}/{Month}/{Day}";
    }
}
