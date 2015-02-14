# UnixtimeHelpers


A very small library for converting unixtime
.

Converting DateTime to unixtime (double/long respresent) and vice versa.

### Example DateTime to Unixtime

```

Global time

long unixtime = UnixtimeHelper.ConvertToLong ( new DateTime ( 2014 , 8 , 13 , 6 , 40 , 6 ) , TimeType.Global );
// unixtime = 1407912006

Local time

long unixtime = UnixtimeHelper.ConvertToLong ( new DateTime ( 2014 , 8 , 13 , 6 , 40 , 6 ) , TimeType.Local );
// unixtime = 1407922806 for +03:00 timezone



```

### Example Unixtime to DateTime

```

Global time

DateTime result = UnixtimeHelper.ConvertToDateTime ( 1407912006 , TimeType.Global );
// result = DateTime ( 2014 , 8 , 13 , 6 , 40 , 6 )

Local time

DateTime result = UnixtimeHelper.ConvertToDateTime ( 1407912006 , TimeType.Local );
// result = DateTime ( 2014 , 8 , 13 , 9 , 40 , 6 ) for +03:00 timezone


```