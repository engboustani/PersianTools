using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PersianTools
{
    public static class Calendar
    {
        public enum Days
        {
            [Description("شنبه")]
            Shanbe = 0,
            [Description("یکشنبه")]
            Yekshanbe = 1,
            [Description("دوشنبه")]
            Doshanbe = 2,
            [Description("سه‌شنبه")]
            Seshanbe = 3,
            [Description("چهارشنبه")]
            Chaharshanbe = 4,
            [Description("پنج‌شنبه")]
            Panjshanbe = 5,
            [Description("جمعه")]
            Jomeh = 6,
        }

        public enum Months
        {
            [Description("فروردین")]
            Farvardin = 0,
            [Description("اردیبهشت")]
            Ordibehesht = 1,
            [Description("خرداد")]
            Khordad = 2,
            [Description("تير")]
            Tir = 3,
            [Description("مرداد")]
            Mordad = 4,
            [Description("شهریور")]
            Shahrivar = 5,
            [Description("مهر")]
            Mehr = 6,
            [Description("آبان")]
            Aban = 7,
            [Description("آذر")]
            Azar = 8,
            [Description("دی")]
            Dey = 9,
            [Description("بهمن")]
            Bahman = 10,
            [Description("اسفند")]
            Esfand = 11,
        }

        private static float GREGORIAN_EPOCH = 1721426f;
        private static float PERSIAN_EPOCH = 1948321f;
        private static float ISLAMIC_EPOCH = 1948440f;

        /// <summary>
        /// Method <c>ToHijri</c> convert gregorian date to hijri
        /// </summary>
        /// <param name="dateTime">the gregorian date.</param>
        /// <returns>
        /// A <c>HijriDateTime</c>
        /// </returns>
        public static HijriDateTime ToHijri(this DateTime dateTime)
        {
            var persian = jd_to_persian(gregorian_to_jd(dateTime.Year, dateTime.Month, dateTime.Day));
            return new HijriDateTime(persian.Item1, persian.Item2, persian.Item3);
        }

        private static Tuple<int, int, int> jd_to_persian(float jd)
        {
            jd = (float)(Math.Floor((double)jd) + 0.5);
            float num1 = jd - Calendar.persian_to_jd(475, 1, 1);
            float num2 = (float)Math.Floor((double)num1 / 1029983.0);
            float num3 = num1 % 1029983f;
            float num4;
            if ((double)num3 == 1029982.0) num4 = 2820f;
            else
            {
                float num5 = (float)Math.Floor((double)num3 / 366.0);
                float num6 = num3 % 366f;
                num4 = (float)(Math.Floor((2134.0 * (double)num5 + 2816.0 * (double)num6 + 2815.0) / 1028522.0) + (double)num5 + 1.0);
            }
            int year = (int)((double)num4 + 2820.0 * (double)num2 + 474.0);
            if (year <= 0)
                --year;
            float num7 = (float)((double)jd - (double)Calendar.persian_to_jd(year, 1, 1) + 1.0);
            int month = (double)num7 <= 186.0 ? (int)Math.Ceiling((double)num7 / 31.0) : (int)Math.Ceiling(((double)num7 - 6.0) / 30.0);
            int num8 = (int)((double)jd - (double)Calendar.persian_to_jd(year, month, 1)) + 1;
            return Tuple.Create(year, month, num8);
        }

        private static float gregorian_to_jd(int year, int month, int day) => (float)((double)Calendar.GREGORIAN_EPOCH - 1.0 + (double)(365 * (year - 1)) + Math.Floor((double)((year - 1) / 4)) + -Math.Floor((double)((year - 1) / 100)) + Math.Floor((double)((year - 1) / 400)) + Math.Floor((double)((367 * month - 362) / 12 + (month <= 2 ? 0 : (Calendar.leap_gregorian(year) ? -1 : -2))) + (double)day));

        private static bool leap_gregorian(int year)
        {
            if (year % 4 != 0)
                return false;
            return year % 100 != 0 || year % 400 == 0;
        }

        private static float persian_to_jd(int year, int month, int day)
        {
            float num1 = (float)(year - (year >= 0 ? 474 : 473));
            float num2 = (float)(474.0 + (double)num1 % 2820.0);
            return (float)((double)(day + (month <= 7 ? (month - 1) * 31 : (month - 1) * 30 + 6)) + Math.Floor(((double)num2 * 682.0 - 110.0) / 2816.0) + ((double)num2 - 1.0) * 365.0 + Math.Floor((double)num1 / 2820.0) * 1029983.0 + ((double)Calendar.PERSIAN_EPOCH - 1.0));
        }
    }
}
