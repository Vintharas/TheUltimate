using System.Data.Entity;
using TheUltimate.Domain.Model;

namespace TheUltimate.Storage
{
    public class TheUltimateDropCreateDbAlways : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {

            context.Tasks.Add(new Task
                {
                    Number = 1,
                    Name = "Do the Laundry",
                    Description = "Do the Laundry. Remember to use softening!"
                });
            context.Tasks.Add(new Task
                {
                    Number = 2,
                    Name = "Go to the Gym",
                    Description = ""
                });
            context.Tasks.Add(new Task
                {
                    Number = 3,
                    Name = "Buy roses for anniversary",
                    Description = "..."
                });

        }
         
    }
}