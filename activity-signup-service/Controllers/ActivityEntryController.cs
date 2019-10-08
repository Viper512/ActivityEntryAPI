using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace activity_signup_service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActivityEntryController : ControllerBase
    {
        private readonly ILogger<ActivityEntryController> _logger;

        public ActivityEntryController(ILogger<ActivityEntryController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{ActivityID}")]
        public IEnumerable<ActivityEntry> Get(int ActivityID)
        {
            using (ActivityEntryContext db = new ActivityEntryContext())
            {
                return db.ActivityEntries.Where(ActivityEntry => ActivityEntry.ActivityID == ActivityID)
                                         .ToList();
            }
        }

        [HttpPost]
        public IActionResult Post(ActivityEntry newActivityEntry)
        {
            if (ModelState.IsValid)
            {
                using (ActivityEntryContext db = new ActivityEntryContext())
                {
                    db.ActivityEntries.Add(newActivityEntry);
                    db.SaveChanges();

                    return Ok(true);
                }
            }
            else
            {
                return BadRequest("First Name, Last Name, Email, Activity and Comments are Required");
            }

        }
    }
}