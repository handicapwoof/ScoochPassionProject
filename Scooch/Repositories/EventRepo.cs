using Microsoft.EntityFrameworkCore;
using Scooch.Interfaces;
using Scooch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scooch.Repositories
{
    public class EventRepo : IEventRepo
    {
        private ScoochDBContext db;

        public EventRepo(ScoochDBContext db)
        {
            this.db = db;
        }

        public List<EventEntity> EventList() {
            return db.EventEntity.ToList();
        }

        public EventEntity Get(int id)
        {
            return db.EventEntity.Where(e => e.EventId == id).FirstOrDefault();
        }

        public bool Update(int id, string name, string location)
        {
            EventEntity eventEntity = db.EventEntity
                .Where(e => e.EventId == id)
                .FirstOrDefault();
            // Remember you can't update the primary key without 
            // causing trouble.  Just update the first and last names
            // for now.
            eventEntity.EventName = name;
            eventEntity.EventLocation = location;
            
            db.SaveChanges();
            return true;
        }

    }
}
