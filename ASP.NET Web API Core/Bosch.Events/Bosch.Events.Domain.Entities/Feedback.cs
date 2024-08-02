﻿namespace Bosch.Events.Domain.Entities
{
    public class Feedback
    {
        public int EventId { get; set; }
        public int EmployeeId { get; set; }
        public virtual Event Event { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
