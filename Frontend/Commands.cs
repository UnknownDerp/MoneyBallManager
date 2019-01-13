using System.Windows.Input;

namespace Frontend
{
    public static class Commands
    {
        public static readonly RoutedUICommand Maximize = new RoutedUICommand("Maximize", "Maximize", typeof(MainWindow));
        public static readonly RoutedUICommand Minimize = new RoutedUICommand("Minimize", "Minimize", typeof(MainWindow));
    }
}
