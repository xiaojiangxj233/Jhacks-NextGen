namespace Jhacks_NextGen
{
    internal static class Program
    {
        
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            bool aaa = DevelopmentEnvironmentDetector.IsDevelopmentEnvironment();
            if (aaa)
            {
                DevConsole.Instance.Show(); // Show DevConsole window
                
            }
            LoadForm.Instance.Show();
            Application.Run(new MainForm());
            


        }
    }
}