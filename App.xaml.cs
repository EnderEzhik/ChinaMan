using System.Windows;
using ChinaMan.Database;

namespace ChinaMan
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            InitDatabase();
            base.OnStartup(e);
        }

        internal static void InitDatabase()
        {
            using (ApplicationContext context = CreateDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }

        internal static ApplicationContext CreateDbContext()
        {
            return new ApplicationContext();
        }
    }

}
