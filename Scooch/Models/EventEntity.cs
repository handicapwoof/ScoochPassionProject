using System;
using System.Collections.Generic;

namespace Scooch.Models
{
    public partial class EventEntity
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string EventLocation { get; set; }
        public string EventTime { get; set; }
    }
}
