using System;
using System.Collections.Generic;

namespace Scooch.Models
{
    public partial class UserEntity
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string EventTime { get; set; }
    }
}
