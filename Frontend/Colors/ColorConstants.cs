using System.Windows.Media;

namespace Frontend.Colors
{
    public static class ColorConstants
    {
        public static Brush Background => CreateColor("#FFF0F0FF");
        public static Brush ButtonColor => CreateColor("#FFEDEDF6");
        public static Brush MouseOverGray => CreateColor("#FFD0D0DF");
        public static Brush DarkBackground => CreateColor("#FF1D2633");
        public static Brush WarningRed => Brushes.Red;
        public static Brush Black => Brushes.Black;
        public static Brush White => Brushes.WhiteSmoke;
        public static Brush Green1 => Brushes.ForestGreen;
        public static Brush Green2 => Brushes.Green;


        private static Brush CreateColor(string hexCode)
        {
            return (Brush)new BrushConverter().ConvertFromString(hexCode);
        }
    }
}
