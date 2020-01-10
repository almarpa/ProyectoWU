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

namespace Ejercicio2
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

        // BASIC GESTURES 
        private void image_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            image.Opacity = image.Opacity - 0.1;
        }

        private void image_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            image.Opacity = 1.0;
        }

        private void image_Holding(object sender, HoldingRoutedEventArgs e)
        {
            //listView.ItemsSource = null;
            listView.Items.Clear();
        }
         
        // POINTER EVENTS 
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
