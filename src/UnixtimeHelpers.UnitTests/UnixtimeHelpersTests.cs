using System;
using EmptyFlow.UnixtimeHelpers;
using EmptyFlow.UnixtimeHelpers.Classifiers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnixtimeHelpers.UnitTests {

	/// <summary>
	/// Unixtime helpers.
	/// </summary>
	[TestClass]
	public class UnixtimeHelpersTests {

		[TestMethod]
		public void ConvertToLong_Global_CheckResult () {
			var result = UnixtimeHelper.ConvertToLong ( new DateTime ( 2014 , 8 , 13 , 6 , 40 , 6 ) , TimeType.Global );

			Assert.AreEqual ( result , 1407912006 );
		}

		[TestMethod]
		public void ConvertToLong_Local_CheckResult () {
			var result = UnixtimeHelper.ConvertToLong ( new DateTime ( 2014 , 8 , 13 , 6 , 40 , 6 ) , TimeType.Local );

			Assert.AreEqual ( result , 1407922806 );
		}

		[TestMethod]
		public void ConvertToDouble_Global_CheckResult () {
			var result = UnixtimeHelper.ConvertToDouble ( new DateTime ( 2014 , 8 , 13 , 6 , 40 , 6 ) , TimeType.Global );

			Assert.AreEqual ( result , 1407912006.0 );
		}

		[TestMethod]
		public void ConvertToDouble_Local_CheckResult () {
			var result = UnixtimeHelper.ConvertToDouble ( new DateTime ( 2014 , 8 , 13 , 6 , 40 , 6 ) , TimeType.Local );

			Assert.AreEqual ( result , 1407922806.0 );
		}

		[TestMethod]
		public void ConvertToDateTime_Long_Global_CheckResult () {
			var testValue = new DateTime ( 2014 , 8 , 13 , 6 , 40 , 6 );
			var result = UnixtimeHelper.ConvertToDateTime ( 1407912006 , TimeType.Global );

			Assert.AreEqual ( result.ToString () , testValue.ToString () );
		}

		[TestMethod]
		public void ConvertToDateTime_Long_Local_CheckResult () {
			var testValue = new DateTime ( 2014 , 8 , 13 , 9 , 40 , 6 );
			var result = UnixtimeHelper.ConvertToDateTime ( 1407912006 , TimeType.Local );

			Assert.AreEqual ( result.ToString () , testValue.ToString () );
		}

		[TestMethod]
		public void ConvertToDateTime_Double_Global_CheckResult () {
			var testValue = new DateTime ( 2014 , 8 , 13 , 6 , 40 , 6 );
			var result = UnixtimeHelper.ConvertToDateTime ( 1407912006.0 , TimeType.Global );

			Assert.AreEqual ( result.ToString () , testValue.ToString () );
		}

		[TestMethod]
		public void ConvertToDateTime_Double_Local_CheckResult () {
			var testValue = new DateTime ( 2014 , 8 , 13 , 9 , 40 , 6 );
			var result = UnixtimeHelper.ConvertToDateTime ( 1407912006.0 , TimeType.Local );

			Assert.AreEqual ( result.ToString () , testValue.ToString () );
		}

	}
}
