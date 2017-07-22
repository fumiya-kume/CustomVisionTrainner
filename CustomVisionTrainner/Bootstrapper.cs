using Microsoft.Practices.Unity;
using Prism.Unity;
using CustomVisionTrainner.Views;
using System.Windows;
using CustomVisionTrainner.Service;
using CustomVisionTrainner.DataStore;
using CustomVisionTrainner.Usecase;

namespace CustomVisionTrainner
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            // Service
            Container.RegisterType<IPopupService, PopupService>();

            // DataStore
            Container.RegisterType<IMemberInfoDataStore, MemberInfoDataStoreFromInternet>();

            // Repostry
            Container.RegisterType<IMemberInfoRepositry, MemberInfoRespositry>();

            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {


            Application.Current.MainWindow.Show();
        }
    }
}
