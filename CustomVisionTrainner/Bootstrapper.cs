﻿using Microsoft.Practices.Unity;
using Prism.Unity;
using CustomVisionTrainner.Views;
using System.Windows;

namespace CustomVisionTrainner
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }
    }
}