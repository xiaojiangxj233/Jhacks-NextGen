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
                DevConsole.Instance.Show(); 
                
            }
            LoadForm.Instance.Show();
            Login login = new Login();
            Application.Run(login);
            MainForm mainForm = new MainForm();
            Application.Run(new MainForm());
            


        }
    }
}