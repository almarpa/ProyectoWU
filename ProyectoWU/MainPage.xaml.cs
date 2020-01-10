using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace ProyectoWU
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void image_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            double x = e.GetCurrentPoint(image).Position.X;
            double y = e.GetCurrentPoint(image).Position.Y;
            listView.Items.Add((String)("PointerPressed X: " + x + "Y: " + y));
        }

        private void image_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            double x = e.GetCurrentPoint(image).Position.X;
            double y = e.GetCurrentPoint(image).Position.Y;
            listView.Items.Add((String)("PointerMoved X: " + x + "Y: " + y));
        }

        private void image_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            double x = e.GetCurrentPoint(image).Position.X;
            double y = e.GetCurrentPoint(image).Position.Y;
            listView.Items.Add((String)("PointerExited X: " + x + "Y: " + y));
        }

        private void image_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            double x = e.GetCurrentPoint(image).Position.X;
            double y = e.GetCurrentPoint(image).Position.Y;
            listView.Items.Add((String)("PointerReleased X: " + x + "Y: " + y));
        }

        private void image_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            double x = e.GetCurrentPoint(image).Position.X;
            double y = e.GetCurrentPoint(image).Position.Y;
            listView.Items.Add((String)("PointerEntered X: " + x + "Y: " + y));
        }

        private void image_PointerWheelChanged(object sender, PointerRoutedEventArgs e)
        {
            double x = e.GetCurrentPoint(image).Position.X;
            double y = e.GetCurrentPoint(image).Position.Y;
            listView.Items.Add((String)("PointerWheelChanged X: " + x + "Y: " + y));
        }

        private void image_PointerCanceled(object sender, PointerRoutedEventArgs e)
        {
            double x = e.GetCurrentPoint(image).Position.X;
            double y = e.GetCurrentPoint(image).Position.Y;
            listView.Items.Add((String)("PointerCanceled X: " + x + "Y: " + y));
        }

        private void image_PointerCaptureLost(object sender, PointerRoutedEventArgs e)
        {
            double x = e.GetCurrentPoint(image).Position.X;
            double y = e.GetCurrentPoint(image).Position.Y;
            listView.Items.Add((String)("PointerCaptureLost X: " + x + "Y: " + y));
        }
    }
}
