using System;
using EmptyFlow.UnixtimeHelpers.Classifiers;

namespace EmptyFlow.UnixtimeHelpers {

	/// <summary>
	/// Date helpers.
	/// </summary>
	public static class UnixtimeHelper {

		/// <summary>
		/// Get start date.
		/// </summary>
		/// <returns></returns>
		private static DateTime GetStartDate () {
			return new DateTime ( 1970 , 1 , 1 , 0 , 0 , 0 , 0 , System.DateTimeKind.Utc );
		}

		/// <summary>
		/// Convert to <see cref="DateTime"/>.
		/// </summary>
		/// <param name="unixtime">Unixtime.</param>
		/// <returns>Unixtime in <see cref="DateTime"/> respresent.</returns>
		private static DateTime ConvertToNativeDateTime ( double unixtime , TimeType timeType ) {
			switch ( timeType ) {
				case TimeType.Global:
					return GetStartDate ().AddSeconds ( unixtime );
				case TimeType.Local:
					return GetStartDate ().AddSeconds ( unixtime ).ToLocalTime ();
				default: throw new NotSupportedException ( "Time type not supported." );
			}
		}

		/// <summary>
		/// Convert to date time.
		/// </summary>
		/// <param name="unixTime">Unix time.</param>
		/// <returns></returns>
		public static DateTime ConvertToDateTime ( long unixtime , TimeType timeType ) {
			return ConvertToNativeDateTime ( (double) unixtime , timeType );
		}

		/// <summary>
		/// Convert to date time.
		/// </summary>
		/// <param name="unixtime">Unixtime.</param>
		/// <param name="timeType">Time type.</param>
		/// <returns>Unixtime in <see cref="DateTime"/>respresent.</returns>
		public static DateTime ConvertToDateTime ( double unixtime , TimeType timeType ) {
			return ConvertToNativeDateTime ( unixtime , timeType );
		}

		/// <summary>
		/// Convert to unixtime.
		/// </summary>
		/// <param name="dateTime">Date time.</param>
		/// <param name="timeType">Time type.</param>
		/// <returns>Unixtime in double.</returns>
		private static double ConvertToUnixtime ( DateTime dateTime , TimeType timeType ) {
			switch ( timeType ) {
				case TimeType.Global:
					return Math.Floor ( ( dateTime - GetStartDate () ).TotalSeconds );
				case TimeType.Local:
					return ( dateTime.ToLocalTime () - GetStartDate () ).TotalSeconds;
				default: throw new NotSupportedException ( "Time type not supported." );
			}
		}

		/// <summary>
		/// Convert to long unixtime respresent.
		/// </summary>
		/// <param name="dateTime">Date time.</param>
		/// <param name="timeType">Time type.</param>
		/// <returns>Unixtime.</returns>
		public static long ConvertToLong ( DateTime dateTime , TimeType timeType ) {
			return (long) ConvertToUnixtime ( dateTime , timeType );
		}

		/// <summary>
		/// Convert to double unixtime respresent.
		/// </summary>
		/// <param name="dateTime">Date time.</param>
		/// <param name="timeType">Time type.</param>
		/// <returns>Unixtime.</returns>
		public static double ConvertToDouble ( DateTime dateTime , TimeType timeType ) {
			return ConvertToUnixtime ( dateTime , timeType );
		}

	}

}
