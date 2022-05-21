using System;
using System.Runtime.InteropServices.ComTypes;
using Xunit;

namespace PersianTools.Test
{
    public class UnitTest1
    {
        private DateTime testDate = new DateTime(2022, 5, 21);

        [Fact]
        public void StringTest()
        {
            Assert.Equal("1401/3/1", Calendar.ToHijri(testDate).ToString());
        }
    }
}