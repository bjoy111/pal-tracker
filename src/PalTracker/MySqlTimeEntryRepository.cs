using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace PalTracker
{
    public class MySqlTimeEntryRepository : ITimeEntryRepository
    {
        private readonly TimeEntryContext _context;

        public MySqlTimeEntryRepository(TimeEntryContext context)
        {
            _context = context;
        }


        public TimeEntry Create(TimeEntry timeEntry)
        {
            var recordToCreate = timeEntry.ToRecord();

            _context.TimeEntryRecords.Add(recordToCreate);
            _context.SaveChanges();

            return Find(recordToCreate.Id.Value);
        }

        public TimeEntry Find(long id)
        {
            return _context.TimeEntryRecords.Single(x => x.Id == id).ToEntity();
        }

        public bool Contains(long tempNumber)
        {
            return  _context.TimeEntryRecords.Any(x => x.Id == tempNumber);
        }

        public IEnumerable<TimeEntry> List()
        {
            return _context.TimeEntryRecords.Select(x => x.ToEntity());
        }

        public TimeEntry Update(long itemNumber, TimeEntry timeEntry)
        {
            timeEntry.Id = itemNumber;
            var recordToUpdate = timeEntry.ToRecord();
            _context.TimeEntryRecords.Update(recordToUpdate);
            _context.SaveChanges();
            return Find(recordToUpdate.Id.Value);
        }
        public void Delete(long id)
        {
            _context.TimeEntryRecords.Remove(_context.TimeEntryRecords.Single(x => x.Id == id));
            _context.SaveChanges();
        }
    }
}