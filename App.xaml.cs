using System.Windows;
using ChinaMan.Database;

namespace ChinaMan
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static void InitDatabase()
        {
            using (ApplicationContext context = CreateDbContext())
            {
                context.Database.EnsureCreated();
            }
        }

        public static ApplicationContext CreateDbContext()
        {
            return new ApplicationContext();
        }
    }

}
