using System;


namespace epicisrael
{
    internal class dbItem
    {
        public string Date { get; set; }
        public string Time { get; set; }


        public dbItem(string date, string time)
        {
            this.Date = date;
            this.Time = time;

        }
        public dbItem()
        {
            DateTime currentDate = DateTime.Now.Date;
            DateTimeOffset dtOffset = DateTimeOffset.Now; // This gets the current system time and local time zone
            // Convert the DateTimeOffset to a specific time zone
            TimeZoneInfo targetTimeZone = TimeZoneInfo.FindSystemTimeZoneById("GMT+3"); // Replace with your target time zone
            DateTimeOffset currentTime = TimeZoneInfo.ConvertTime(dtOffset, targetTimeZone);

            // Print the date and time separately
            Date = currentDate.ToShortDateString();
            // Get the current time
            Time = currentTime.ToString(@"HH\:mm\:ss");

        }

        public dbItem(dbItem item)
        {
            Date = item.Date;
            Time = item.Time;
        }
    }
}
