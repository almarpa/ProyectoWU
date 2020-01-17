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

namespace Ejercicio3
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

        private void image_ImageOpened(object sender, RoutedEventArgs e)
        {
            Image image = (Image)sender;

            //Capturamos la posicíón central de la imagen escalar y rotar manteniendo la posición
            ImageScaleTransform.CenterX = image.ActualWidth / 2;
            ImageScaleTransform.CenterY = image.ActualHeight / 2;
            ImageRotateTransform.CenterX = image.ActualWidth / 2;
            ImageRotateTransform.CenterY = image.ActualHeight / 2;
        }

        private void image_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            // SCALE
            ImageScaleTransform.ScaleX *= e.Delta.Scale;
            ImageScaleTransform.ScaleY *= e.Delta.Scale;

            // ROTATION
            ImageRotateTransform.Angle += e.Delta.Rotation;
        }
    }
}
