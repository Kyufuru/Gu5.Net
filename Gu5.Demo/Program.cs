using Gu5.Net.Winforms.UI;

namespace Gu5.Net.Winforms.Example
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