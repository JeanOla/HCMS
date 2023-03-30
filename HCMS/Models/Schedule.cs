namespace HCMS.Models
{
    public class Schedule
    {
        public int Id { get; set; } 
        public int doctorId { get; set; }
        //build relationship wit hdoctor
        public string dayOfWeek { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
    }
}
