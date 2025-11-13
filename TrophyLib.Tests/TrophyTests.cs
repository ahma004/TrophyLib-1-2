using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrophyLib;
using Xunit;

namespace TrophyLib.Tests
{
    public class TrophyTests
    {
        [Fact]
        public void Ctor_ValidValues_ShouldCreate()
        {
            var t = new Trophy(1, "World Cup", 2020);
            Assert.Equal(1, t.Id);
            Assert.Equal("World Cup", t.Competition);
            Assert.Equal(2020, t.Year);
            Assert.Equal("#1: World Cup (2020)", t.ToString());
        }

        [Fact]
        public void Competition_Set_Null_ShouldThrow()
        {
            var t = new Trophy();
            var ex = Assert.Throws<ArgumentNullException>(() => t.Competition = null!);
            Assert.Contains("Competition", ex.ParamName);
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData("AB")] // 2 tegn
        public void Competition_Set_TooShort_ShouldThrow(string input)
        {
            var t = new Trophy();
            var ex = Assert.Throws<ArgumentException>(() => t.Competition = input);
            Assert.Contains("mindst 3", ex.Message);
        }

        [Theory]
        [InlineData(1969)]
        [InlineData(2026)]
        public void Year_Set_OutsideBounds_ShouldThrow(int year)
        {
            var t = new Trophy();
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => t.Year = year);
            Assert.Contains("mellem 1970 og 2025", ex.Message);
        }

        [Theory]
        [InlineData(1970)]
        [InlineData(2025)]
        [InlineData(1999)]
        public void Year_Set_BoundariesAndInside_ShouldPass(int year)
        {
            var t = new Trophy();
            t.Year = year;
            Assert.Equal(year, t.Year);
        }

        [Fact]
        public void Competition_TrimsWhitespace()
        {
            var t = new Trophy();
            t.Competition = "   Champions League   ";
            Assert.Equal("Champions League", t.Competition);
        }

        [Fact]
        public void Id_Set_AnyInt_ShouldPass()
        {
            var t = new Trophy();
            t.Id = -10; 
            Assert.Equal(-10, t.Id);
        }

        [Fact]
        public void ToString_FormatsCorrectly()
        {
            var t = new Trophy(42, "Open", 2018);
            Assert.Equal("#42: Open (2018)", t.ToString());
        }
    }
}
