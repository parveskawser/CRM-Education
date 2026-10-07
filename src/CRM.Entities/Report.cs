using System;
using System.Collections.Generic;

namespace CRM.Entities
{
    public class ReportDefinition
    {
        public int Id { get; set; }
        public string Name { get; set; }             
        public string Code { get; set; }              
        public string? Summary { get; set; }
        public string? Description { get; set; }

      
    }
}