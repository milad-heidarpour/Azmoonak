using System.Globalization;

namespace Azmoonak.Core.Classes;

public class DateClass
{
    public async Task<string> GetPersianDate()
    {
        var dateTime = DateTime.Now;
        var persian = new PersianCalendar();
        var date = persian.GetYear(dateTime).ToString("0000") + "/" + persian.GetMonth(dateTime).ToString("00") + "/" + persian.GetDayOfMonth(dateTime).ToString("00");


        //return date+" "+time;
        return String.Format("{0}",date);
    }
}
