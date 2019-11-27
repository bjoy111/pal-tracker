using System.Collections.Generic;

namespace PalTracker
{
    public interface ITimeEntryRepository
    {
        TimeEntry Create(TimeEntry timeEntry);
        TimeEntry Find(long tempNumber);
        bool Contains(long tempNumber);
        IEnumerable<TimeEntry> List();
        TimeEntry Update(long temNumber, TimeEntry timeEntry);
        void Delete(long id);
    }
}