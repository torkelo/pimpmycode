namespace GameLibrary
{
    using System;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Browser;
    using Framework;

    public partial class App : Application
    {
        public App()
        {
            Startup += Application_Startup;
            UnhandledException += Application_UnhandledException;

            InitializeComponent();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            RootVisual = Bootstrapper.CreateShell();

            if(IsRunningOutOfBrowser && HasElevatedPermissions)
            {
                MainWindow.Width = 600;
                
                MainWindow.Closing += (s, args) => {
                    args.Cancel = !IoC.GetInstance<IShell>().CanClose();
                };
            }
        }

        private static void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if(Debugger.IsAttached)
                return;

            e.Handled = true;
            Deployment.Current.Dispatcher.BeginInvoke(() => ReportErrorToDOM(e));
        }

        private static void ReportErrorToDOM(ApplicationUnhandledExceptionEventArgs e)
        {
            try
            {
                var errorMsg = e.ExceptionObject.Message + e.ExceptionObject.StackTrace;
                errorMsg = errorMsg.Replace('"', '\'').Replace("\r\n", @"\n");

                HtmlPage.Window.Eval("throw new Error(\"Unhandled Error in Silverlight 2 Application " + errorMsg + "\");");
            }
            catch(Exception) {}
        }
    }
}