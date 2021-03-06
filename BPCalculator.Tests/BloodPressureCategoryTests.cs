using System;
using Xunit;
using BPCalculator;

namespace BPCalculator.UnitTest.BloodPressure
{
    public class BloodPressureCategoryTests
    {
        public BPCalculator.BloodPressure BP;

        [Theory]
        [InlineData(119,79)]
        [InlineData(111,75)]
        [InlineData(91,61)]
        [InlineData(115,68)]
        [InlineData(100,70)]
        [InlineData(110,65)]
        [InlineData(100,60)]
        public void Test_for_normal_values(int s, int d)
        {
            BP = new BPCalculator.BloodPressure() { Systolic = s, Diastolic = d };
            Assert.Equal(BPCalculator.BPCategory.Normal, BP.Category);
        }

        [Theory]
        [InlineData(100, 91)]
        [InlineData(111, 59)]
        [InlineData(100, 81)]
        [InlineData(120, 91)]
        [InlineData(121, 59)]
        [InlineData(121, 60)]
        [InlineData(120, 81)]
        [InlineData(79, 91)]
        [InlineData(79, 59)]
        [InlineData(79, 60)]
        [InlineData(79, 81)]
        public void Test_for_Non_Normal_values(int s, int d)
        {
            BP = new BPCalculator.BloodPressure() { Systolic = s, Diastolic = d };
            Assert.NotEqual(BPCalculator.BPCategory.Normal, BP.Category);
        }

        [Theory]
        [InlineData(89, 59)]
        [InlineData(91, 58)]
        [InlineData(80, 50)]
        [InlineData(83, 43)]
        [InlineData(70, 40)]
        [InlineData(90, 58)]
        [InlineData(89, 61)]
        [InlineData(89, 60)]
        public void Test_for_low_values(int s, int d)
        {
            BP = new BPCalculator.BloodPressure() { Systolic = s, Diastolic = d };
            Assert.Equal(BPCalculator.BPCategory.Low, BP.Category);
        }

        [Theory]
        [InlineData(90, 60)]
        [InlineData(92, 62)]
        public void Test_for_Non_low_values(int s, int d)
        {
            BP = new BPCalculator.BloodPressure() { Systolic = s, Diastolic = d };
            Assert.NotEqual(BPCalculator.BPCategory.Low, BP.Category);
        }


        [Theory]
        [InlineData(124, 79)]
        public void Test_for_elevated_values(int s, int d)
        {
            BP = new BPCalculator.BloodPressure() { Systolic = s, Diastolic = d };
            Assert.Equal(BPCalculator.BPCategory.Elevated, BP.Category);
        }

        [Theory]
        [InlineData(124, 81)]
        [InlineData(124, 59)]
        [InlineData(131, 79)]
        [InlineData(131, 81)]
        [InlineData(131, 59)]
        [InlineData(119, 79)]
        [InlineData(119, 81)]
        [InlineData(119, 59)]
        public void Test_for_Non_elevated_values(int s, int d)
        {
            BP = new BPCalculator.BloodPressure() { Systolic = s, Diastolic = d };
            Assert.NotEqual(BPCalculator.BPCategory.Elevated, BP.Category);
        }

        [Theory]
        [InlineData(181, 79)]
        [InlineData(181, 80)]
        [InlineData(181, 85)]
        [InlineData(181, 95)]
        [InlineData(130, 121)]
        [InlineData(141, 121)]
        [InlineData(181, 121)]
        public void Test_for_crisis_values(int s, int d)
        {
            BP = new BPCalculator.BloodPressure() { Systolic = s, Diastolic = d };
            Assert.Equal(BPCalculator.BPCategory.Crisis, BP.Category);
        }

        [Theory]
        [InlineData(130, 79)]
        [InlineData(130, 80)]
        [InlineData(139, 85)]
        [InlineData(139, 89)]
        [InlineData(121,80)]
        [InlineData(90,81)]
        public void Test_for_high1_values(int s, int d)
        {
            BP = new BPCalculator.BloodPressure() { Systolic = s, Diastolic = d };
            Assert.Equal(BPCalculator.BPCategory.High1, BP.Category);
        }

        [Theory]
        [InlineData(131, 89)]
        [InlineData(121, 121)]
        public void Test_for_Non_high2_values(int s, int d)
        {
            BP = new BPCalculator.BloodPressure() { Systolic = s, Diastolic = d };
            Assert.InRange(d, BPCalculator.BloodPressure.DiastolicMin, BPCalculator.BloodPressure.DiastolicMax);
            Assert.NotEqual(BPCalculator.BPCategory.High2, BP.Category);
        }

        [Theory]
        [InlineData(140, 79)]
        [InlineData(150, 79)]
        [InlineData(180, 79)]
        [InlineData(140, 90)]
        [InlineData(140, 98)]
        [InlineData(135, 119)]
        [InlineData(121, 90)]
        public void Test_for_high2_values(int s, int d)
        {
            BP = new BPCalculator.BloodPressure() { Systolic = s, Diastolic = d };
            Assert.InRange(d, BPCalculator.BloodPressure.DiastolicMin, BPCalculator.BloodPressure.DiastolicMax);
            Assert.Equal(BPCalculator.BPCategory.High2, BP.Category);
        }


    }
}
