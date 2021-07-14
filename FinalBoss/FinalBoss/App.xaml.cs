using Xamarin.Forms;

using FinalBoss.Services;
using FinalBoss.Api.Client;

namespace FinalBoss
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<IFinalBossClient, FinalBossClient>();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        { }

        protected override void OnSleep()
        { }

        protected override void OnResume()
        { }
    }
}