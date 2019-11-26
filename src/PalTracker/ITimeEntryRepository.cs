using System.Collections.Generic;

namespace PalTracker
{
    public interface ITimeEntryRepository
    {
        TimeEntry Create(TimeEntry timeEntry);
        TimeEntry Find(int tempNumber);
        bool Contains(int tempNumber);
        IEnumerable<TimeEntry> List();
        TimeEntry Update(int temNumber, TimeEntry timeEntry);
        void Delete(int id);
    }
}