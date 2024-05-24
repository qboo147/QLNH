using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ShiftDTO
    {
        private string id;
        private DateTime workingDate;
        private string startTime;
        private string endTime;
        public ShiftDTO(string id, DateTime workingDate, string startTime, string endTime)
        {
            this.id = id;
            this.workingDate = workingDate;
            this.startTime = startTime;
            this.endTime = endTime;
        }
        private string ConvertTo24HourFormat(string time)
        {
            // Giả sử time là định dạng "h:mm tt" (ví dụ: "8:00 AM")
            DateTime dt = DateTime.ParseExact(time, "h:mm tt", CultureInfo.InvariantCulture);
            // Chuyển đổi thành định dạng 24 giờ "HH:mm:ss"
            return dt.ToString("HH:mm:ss");
        }
        public string Id { get { return id; } set { id = value; } }
        public DateTime WorkingDate { get { return workingDate; } set { workingDate = value; } }
        public string StartTime { get { return startTime; } set { startTime = ConvertTo24HourFormat(value); } }
        public string EndTime { get { return endTime; } set { endTime = ConvertTo24HourFormat(value); } }
    }
}
