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

namespace Ejercicio4
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

        /** FIRST IMAGE **/
        private void image_ImageOpened(object sender, RoutedEventArgs e)
        {
            // Fijar la posición desde donde realizar las transformaciones
            Image image = (Image)sender;
            ct1.CenterX = image.ActualWidth / 2;
            ct1.CenterY = image.ActualHeight / 2;
        }

        private void image_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {

            FrameworkElement source = (FrameworkElement)e.OriginalSource;
            
            // Rotation
            ct1.Rotation += e.Delta.Rotation;
            // Scale
            ct1.ScaleX /= e.Delta.Scale;
            ct1.ScaleY /= e.Delta.Scale;
            // Translation
            ct1.TranslateX += e.Delta.Translation.X;
            ct1.TranslateY += e.Delta.Translation.Y;

            source.RenderTransform = ct1;
        }

        /** SECOND IMAGE **/
        private void image_ImageOpened2(object sender, RoutedEventArgs e)
        {
            // Fijar la posición desde donde realizar las transformaciones
            Image image = (Image)sender;
            ct2.CenterX = image.ActualWidth / 2;
            ct2.CenterY = image.ActualHeight / 2;
        }

        private void image_ManipulationDelta2(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            FrameworkElement source = (FrameworkElement)e.OriginalSource;
            
            // Rotation
            ct2.Rotation += e.Delta.Rotation;
            // Scale
            ct2.ScaleX /= e.Delta.Scale;
            ct2.ScaleY /= e.Delta.Scale;
            // Translation
            ct2.TranslateX += e.Delta.Translation.X;
            ct2.TranslateY += e.Delta.Translation.Y;

            source.RenderTransform = ct2;
        }
    }
}
