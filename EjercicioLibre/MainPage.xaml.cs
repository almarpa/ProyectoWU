using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace EjercicioLibre
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int local = 0;
        int visitante = 0;
        List<CompositeTransform> listCTransform = new List<CompositeTransform>();
        List<Image> listImages = new List<Image>();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Image_ImageOpened(object sender, RoutedEventArgs e)
        {
            // Fijar la posición desde donde realizar las transformaciones
            Image image = (Image)sender;

            int pos = listImages.IndexOf(listImages.Find(x => x == image));
            CompositeTransform ct = listCTransform[pos];

            ct.CenterX = image.ActualWidth / 2;
            ct.CenterY = image.ActualHeight / 2;
        }

        private void image_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            Image image = sender as Image;
            int pos = listImages.IndexOf(listImages.Find(x => x == image));
            CompositeTransform ct = listCTransform[pos];

            // Rotation
            ct.Rotation += e.Delta.Rotation;
            // Scale
            ct.ScaleX /= e.Delta.Scale;
            ct.ScaleY /= e.Delta.Scale;
            // Translation
            ct.TranslateX += e.Delta.Translation.X;
            ct.TranslateY += e.Delta.Translation.Y;

            image.RenderTransform = ct;

            if (e.IsInertial)
            {
                double x = e.Delta.Translation.X;
                double y = e.Delta.Translation.Y;
                /*
                if(e.Delta.Translation.Y <= 703-246.1 && e.Delta.Translation.Y >  && e.Delta.Translation.X > grid.ActualWidth)
                {
                    local = local + 1;
                    marcador1.Text = local.ToString();
                }
                */
            }

            image.RenderTransform = ct;
        }

        private void grid_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            CompositeTransform ct1 = new CompositeTransform();
            double width = grid.ActualWidth;
            double height = grid.ActualHeight;
            double positionX = e.GetPosition(grid).X;
            double positionY = e.GetPosition(grid).Y;
            ct1.TranslateX = positionX - width / 2 + 115;
            ct1.TranslateY = positionY - height / 2;
            
            
            Image img = new Image();
            img.Source = new BitmapImage(new Uri("ms-appx:///Assets/ball.png"));
            img.Width = 200;
            img.Height = 200;
            img.ManipulationMode = ManipulationModes.All;
            img.RenderTransform = ct1;

            img.ManipulationDelta += image_ManipulationDelta;
            img.ImageOpened += Image_ImageOpened;

            listCTransform.Add(ct1);
            listImages.Add(img);

            grid.Children.Add(img);
            
            
        }
    }
}
