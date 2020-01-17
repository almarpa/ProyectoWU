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
            double x = e.GetPosition(image).X;
            double y = e.GetPosition(image).Y;
            listView.Items.Add((String)("Tapped X: " + x + "Y: " + y));
            image.Opacity = image.Opacity - 0.1;
        }

        private void image_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            double x = e.GetPosition(image).X;
            double y = e.GetPosition(image).Y;
            listView.Items.Add((String)("DoubleTapped X: " + x + "Y: " + y));
            image.Opacity = 1.0;
        }

        private void image_Holding(object sender, HoldingRoutedEventArgs e)
        {
            double x = e.GetPosition(image).X;
            double y = e.GetPosition(image).Y;
            listView.Items.Add((String)("Holding X: " + x + "Y: " + y));
            listView.ItemsSource = null;
            listView.Items.Clear();
        }

        private void image_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            double x = e.GetPosition(image).X;
            double y = e.GetPosition(image).Y;
            listView.Items.Add((String)("RightTapped X: " + x + "Y: " + y));
        }
    }
}
