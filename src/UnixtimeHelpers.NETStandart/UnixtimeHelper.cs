using System;

namespace EmptyFlow.UnixtimeHelpers {

	/// <summary>
	/// Date helpers.
	/// </summary>
	public static class UnixtimeHelper {

		private static DateTime _startDate = new DateTime ( 1970 , 1 , 1 , 0 , 0 , 0 , 0 , DateTimeKind.Utc );

		/// <summary>
		/// Get start date.
		/// </summary>
		/// <returns></returns>
		private static DateTime GetStartDate () => _startDate;

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
		public static DateTime ConvertToDateTime ( long unixtime , TimeType timeType ) => ConvertToNativeDateTime ( unixtime , timeType );

		/// <summary>
		/// Convert to date time.
		/// </summary>
		/// <param name="unixtime">Unixtime.</param>
		/// <param name="timeType">Time type.</param>
		/// <returns>Unixtime in <see cref="DateTime"/>respresent.</returns>
		public static DateTime ConvertToDateTime ( double unixtime , TimeType timeType ) => ConvertToNativeDateTime ( unixtime , timeType );

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
					return Math.Floor ( ( dateTime.ToUniversalTime () - GetStartDate () ).TotalSeconds );
				default: throw new NotSupportedException ( "Time type not supported." );
			}
		}

		/// <summary>
		/// Convert to long unixtime respresent.
		/// </summary>
		/// <param name="dateTime">Date time.</param>
		/// <param name="timeType">Time type.</param>
		/// <returns>Unixtime.</returns>
		public static long ConvertToLong ( DateTime dateTime , TimeType timeType ) => (long) ConvertToUnixtime ( dateTime , timeType );

		/// <summary>
		/// Convert to double unixtime respresent.
		/// </summary>
		/// <param name="dateTime">Date time.</param>
		/// <param name="timeType">Time type.</param>
		/// <returns>Unixtime.</returns>
		public static double ConvertToDouble ( DateTime dateTime , TimeType timeType ) => ConvertToUnixtime ( dateTime , timeType );

		public static long ToUnixtime ( this DateTime dateTime , TimeType timeType = TimeType.Global ) => (long) ConvertToUnixtime ( dateTime , timeType );

		public static double ToUnixtimeAsDouble ( this DateTime dateTime , TimeType timeType = TimeType.Global ) => ConvertToUnixtime ( dateTime , timeType );

		public static DateTime FromUnixtime ( this long unixtime , TimeType timeType = TimeType.Global ) => ConvertToNativeDateTime ( unixtime , timeType );

		public static DateTime FromUnixtime ( this double unixtime , TimeType timeType = TimeType.Global ) => ConvertToNativeDateTime ( unixtime , timeType );

	}

}
