using System.Collections.Generic;
using System.Linq;
using System;

namespace PalTracker
{
    public class InMemoryTimeEntryRepository : ITimeEntryRepository
    {
        private readonly IDictionary<long, TimeEntry> timeEntries = new Dictionary<long, TimeEntry>();

        public TimeEntry Create(TimeEntry timeEntry)
        {
            var id = timeEntries.Count + 1;
            timeEntry.Id = id;
            timeEntries.Add(id, timeEntry);
            return timeEntry;
        }

        public TimeEntry Find(long itemNumber)
        {
            return timeEntries[itemNumber];
        }

        public bool Contains(long itemNumber)
        {
            return  timeEntries.ContainsKey(itemNumber);
        }

        public IEnumerable<TimeEntry> List()
        {
            return timeEntries.Values.ToList();
        }

        public TimeEntry Update(long itemNumber, TimeEntry timeEntry)
        {
            timeEntry.Id = itemNumber;
            timeEntries[itemNumber] = timeEntry;
            return  timeEntries[itemNumber];
        }

        public void Delete(long id)
        {
            timeEntries.Remove(id);
        }
    }
}