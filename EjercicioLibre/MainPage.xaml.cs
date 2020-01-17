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

namespace EjercicioLibre
{

    public sealed partial class MainPage : Page
    {
        int local = 0;
        int visitante = 0;
        List<CompositeTransform> listCTransform = new List<CompositeTransform>();
        List<Image> listImages = new List<Image>();
        List<Boolean> isBall = new List<Boolean>();

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
            // Buscamos la posición de la imagen en la lista de imágenes, para poder saber cuál es su CompositeTransform
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

            // Comprobamos que sea una pelota antes de contabilizar los goles
            if (isBall[pos] == true) {
                if (e.IsInertial)
                {
                    // Para detectar el gol encajado en la portería del equipo visitante
                    if (ct.TranslateY >= -70 && ct.TranslateY < 50 && ct.TranslateX > 770 && ct.TranslateX < 1000)
                    {
                        e.Complete();
                        local = local + 1;
                        marcador1.Text = local.ToString();
                    }

                    // Para detectar el gol encajado en la portería del equipo local
                    if (ct.TranslateY >= -70 && ct.TranslateY < 50 && ct.TranslateX < -770 && ct.TranslateX >= -1000)
                    {
                        e.Complete();
                        visitante = visitante + 1;
                        marcador2.Text = visitante.ToString();
                    }
                }
            }

            image.RenderTransform = ct;
        }

        private void grid_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            CompositeTransform ct1 = new CompositeTransform();
            
            // Dimensión de la pantalla
            double width = grid.ActualWidth;
            double height = grid.ActualHeight;
            
            // Posición donde se hace el click derecho
            double positionX = e.GetPosition(grid).X;
            double positionY = e.GetPosition(grid).Y;
            ct1.TranslateX = positionX - width / 2;
            ct1.TranslateY = positionY - height / 2;

            // Creamos la nueva pelota
            Image img = new Image();
            img.Source = new BitmapImage(new Uri("ms-appx:///Assets/ball.png"));
            img.Width = 200;
            img.Height = 200;
            img.ManipulationMode = ManipulationModes.All;
            img.RenderTransform = ct1;
            img.ManipulationDelta += image_ManipulationDelta;
            img.ImageOpened += Image_ImageOpened;

            //Añadimos la imagen y su CompositeTransform
            listImages.Add(img);
            listCTransform.Add(ct1);
            isBall.Add(true);

            grid.Children.Add(img);
        }

        private void grid_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            CompositeTransform ct1 = new CompositeTransform();

            // Dimensión de la pantalla
            double width = grid.ActualWidth;
            double height = grid.ActualHeight;

            // Posición donde se hace el click derecho
            double positionX = e.GetPosition(grid).X;
            double positionY = e.GetPosition(grid).Y;
            ct1.TranslateX = positionX - width / 2;
            ct1.TranslateY = positionY - height / 2;

            // Creamos la nueva pelota
            Image img = new Image();
            img.Source = new BitmapImage(new Uri("ms-appx:///Assets/player.png"));
            img.Width = 200;
            img.Height = 200;
            img.ManipulationMode = ManipulationModes.All;
            img.RenderTransform = ct1;
            img.ManipulationDelta += image_ManipulationDelta;
            img.ImageOpened += Image_ImageOpened;

            //Añadimos la imagen, su CompositeTransform y la 
            listImages.Add(img);
            listCTransform.Add(ct1);
            isBall.Add(false);

            grid.Children.Add(img);
        }
    }
}
