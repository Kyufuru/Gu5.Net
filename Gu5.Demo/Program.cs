using Gu5.UI;

namespace Gu5.Demo
{
    internal static class Program
    {
        public static App App { get; set; } = new()
        {
            Login = new FmLogin(),
            Main = new FmMain(),
        };

        [STAThread]
        static void Main()
        {
            App.UseUI().Run();
        }
    }
}