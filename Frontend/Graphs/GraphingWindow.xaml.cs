using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Frontend.Graphs
{
    /// <summary>
    /// Interaction logic for GraphingWindow.xaml
    /// </summary>
    public partial class GraphingWindow : UserControl
    {
        //public GraphingWindow()
        //{
        //    InitializeComponent();
        //    //GraphCanvas.Background = Brushes.LightGray;
        //    //GraphCanvas.Dispatcher.Invoke(delegate { }, DispatcherPriority.Render);
        //    DrawSomething();
        //    this.MinHeight = 768;
        //}

        //private void DrawSomething()
        //{
        //    var origo = new Point(100, 500);
        //    var list = new [] {1, 2, 1, 3};
        //    var p2 = DiagramTranformation.CreateTransformedPoint(origo, 50, 200);
        //    var baseDiagram = new DiagramBase(origo, 400, 700);
        //    var label = new Label {Content = "test"};
        //    const int arrowConst = 10;

        //    GraphCanvas.IsManipulationEnabled = true;
        //    AddRange(GraphCanvas, baseDiagram);

        //    var line2 = new Line()
        //    {
        //        Stroke = Brushes.Blue,
        //        StrokeThickness = 2,
        //        X1 = origo.X,
        //        Y1 = origo.Y,
        //        X2 = p2.X,
        //        Y2 = p2.Y
        //    };
        //    GraphCanvas.Children.Add(line2);
        //}

        //private static void AddRange(Panel c, IUiElement element)
        //{
        //    foreach (var uiElement in element.Elements)
        //    {
        //        c.Children.Add(uiElement);
        //    }
        //}
    }
}
