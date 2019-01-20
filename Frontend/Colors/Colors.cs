using System.Windows.Media;

namespace Frontend.Colors
{
    public static class Colors
    {
        public static Brush Background => CreateColor("#FFF0F0FF");


        private static Brush CreateColor(string hexCode)
        {
            return (Brush) new BrushConverter().ConvertFromString(hexCode);
        }
    }
}
