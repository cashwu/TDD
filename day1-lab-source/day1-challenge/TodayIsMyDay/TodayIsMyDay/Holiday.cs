using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TodayIsMyDay
{
    public class Holiday
    {
		private DateTime _today;
	    public Holiday(DateTime today)
	    {
		    _today = today;
	    }

        public string IsTodayXmas()
        {
			if (_today.Month == 12 && _today.Day == 25)
            {
                return "Merry Xmas!!";
            }
            else
            {
                return "Today is not Xmas";
            }
        }
    }
}
