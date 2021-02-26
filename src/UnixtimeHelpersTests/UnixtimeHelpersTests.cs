using EmptyFlow.UnixtimeHelpers;
using System;
using Xunit;

namespace UnixtimeHelpersTests {
	public class UnixtimeHelpersTests {

		[Fact]
		public void ConvertToLong_Global_CheckResult () {
			var result = UnixtimeHelper.ConvertToLong ( new DateTime ( 2014 , 8 , 13 , 6 , 40 , 6 ) , TimeType.Global );

			Assert.Equal ( 1407912006 , result );
		}

		[Fact]
		public void ConvertToLong_Local_CheckResult () {
			var date = new DateTime ( 2020 , 8 , 13 , 6 , 40 , 6 );

			var result = UnixtimeHelper.ConvertToDateTime ( UnixtimeHelper.ConvertToLong ( date , TimeType.Local ) , TimeType.Local );

			Assert.Equal ( date , result );
		}

		[Fact]
		public void ConvertToDouble_Global_CheckResult () {
			var result = UnixtimeHelper.ConvertToDouble ( new DateTime ( 2014 , 8 , 13 , 6 , 40 , 6 ) , TimeType.Global );

			Assert.Equal ( 1407912006.0 , result );
		}

		[Fact]
		public void ConvertToDouble_Local_CheckResult () {
			var date = new DateTime ( 2014 , 8 , 13 , 6 , 40 , 6 );
			var result = UnixtimeHelper.ConvertToDateTime ( UnixtimeHelper.ConvertToDouble ( date , TimeType.Local ) , TimeType.Local );

			Assert.Equal ( date , result );
		}

		[Fact]
		public void ConvertToDateTime_Long_Global_CheckResult () {
			var testValue = new DateTime ( 2014 , 8 , 13 , 6 , 40 , 6 );
			var result = UnixtimeHelper.ConvertToDateTime ( 1407912006 , TimeType.Global );

			Assert.Equal ( result.ToString () , testValue.ToString () );
		}

		[Fact]
		public void ConvertToDateTime_Double_Global_CheckResult () {
			var testValue = new DateTime ( 2014 , 8 , 13 , 6 , 40 , 6 );
			var result = UnixtimeHelper.ConvertToDateTime ( 1407912006.0 , TimeType.Global );

			Assert.Equal ( result.ToString () , testValue.ToString () );
		}

	}

}
