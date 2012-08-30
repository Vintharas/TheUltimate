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
                    Description = "Bleh..."
                });
            context.Tasks.Add(new Task
                {
                    Number = 2,
                    Name = "Remember to buy batteries",
                    Description = ""
                });
            context.Tasks.Add(new Task
                {
                    Number = 3,
                    Name = "Call the Dentist",
                    Description = "..."
                });
            context.Tasks.Add(new Task
                {
                    Number = 4,
                    Name = "Go to Mars",
                    Description = "..."
                });

        }
         
    }
}