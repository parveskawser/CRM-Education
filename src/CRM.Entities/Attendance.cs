using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Entities
{
    internal class Attendance
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public DateTime AttendanceDate { get; set; }

        public bool IsPresent { get; set; }

        public string? Remarks { get; set; }
    }

    public class StudentAttendance
    {
        public  Students Student { get; set; }
        public  List<Attendance> AttendanceList { get; set; }
    }
}
