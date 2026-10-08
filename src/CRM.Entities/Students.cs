using System;
using System.Collections.Generic;
using System.Text;


namespace CRM.Entities
{
    public class Students
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
    }
    public class StudentAttendance
    {
        public int StudentId { get; set; }

        public string StudentName { get; set; }

        public string Department { get; set; }

        public DateTime AttendanceDate { get; set; }

        public bool IsPresent { get; set; }

        public string Remarks { get; set; }
    }
}
