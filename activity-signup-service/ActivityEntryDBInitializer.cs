using System.Collections.Generic;
using System.Data.Entity;

namespace activity_signup_service
{
    public class ActivityEntryDBInitializer : CreateDatabaseIfNotExists<ActivityEntryContext>
    {
        protected override void Seed(ActivityEntryContext context)
        {
            IList<Activity> activities = new List<Activity>();

            activities.Add(new Activity() { ID = 1, Description = "Running" });
            activities.Add(new Activity() { ID = 2, Description = "Walking" });
            activities.Add(new Activity() { ID = 3, Description = "Crawling" });

            context.Activities.AddRange(activities);

            base.Seed(context);
        }
    }
}