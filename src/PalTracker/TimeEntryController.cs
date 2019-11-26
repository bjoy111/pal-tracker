using Microsoft.AspNetCore.Mvc;

namespace PalTracker
{
    [Route("/time-entries")]
    public class TimeEntryController : ControllerBase
    {
        private readonly ITimeEntryRepository _repository;

        public TimeEntryController(ITimeEntryRepository repository)
        {
            _repository = repository;
        } 

        [HttpPost]
        public IActionResult Create([FromBody] TimeEntry timeEntry)
        {
            // if(_repository.Create(timeEntry)){

            // }
            // return Ok(_repository.Create(timeEntry));
            var createdTimeEntry = _repository.Create(timeEntry);

            return CreatedAtRoute("GetTimeEntry", new {id = createdTimeEntry.Id}, createdTimeEntry);
        }

        [HttpGet("{id}", Name = "GetTimeEntry")]
        public IActionResult Read(int id)
        {
            return _repository.Contains(id) ? (IActionResult) Ok(_repository.Find(id)) : NotFound();
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_repository.List());
        }
        
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TimeEntry timeEntry)
        {
            //return _repository.Update(id, timeEntry) ? (IActionResult) Ok(_repository.Contains(id)) : NotFound();
            return _repository.Contains(id) ? (IActionResult) Ok(_repository.Update(id, timeEntry)) : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //return _repository.Contains(id) ? (IActionResult) Ok(_repository.Delete(id)) : NotFound();

            if (!_repository.Contains(id))
            {
                return NotFound();
            }

            _repository.Delete(id);

            return NoContent();
        }
    }
}