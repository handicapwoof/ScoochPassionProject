using Scooch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scooch.Interfaces
{
    public interface IEventRepo
    {
        List<EventEntity> EventList();

    }
}
