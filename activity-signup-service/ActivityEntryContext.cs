using System.Data.Entity;

namespace activity_signup_service
{
    public class ActivityEntryContext : DbContext
    {
        public ActivityEntryContext() : base("name=ActivityEntryDatabase")
        {
            
            Database.SetInitializer<ActivityEntryContext>(new CreateDatabaseIfNotExists<ActivityEntryContext>());
            
            if (!Database.Exists())
            {
                Database.SetInitializer<ActivityEntryContext>(new ActivityEntryDBInitializer());
            }
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityEntry> ActivityEntries { get; set; }

    }
}