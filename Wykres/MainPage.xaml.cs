using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Wykres
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void liczba_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            
            funkcja.Text += b.Content.ToString();

        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {


            funkcja.Text = "";


        }

        private void CE_Click(object sender, RoutedEventArgs e)
        {
            if (funkcja.Text.Length > 0)
            {
                funkcja.Text = funkcja.Text.Substring(0, funkcja.Text.Length - 1);
            }
        }
        
        private void plotuj_Click(object sender, RoutedEventArgs e)
        {
            var formula = Maths.MathParse.Parse("cos(x)+x");

            funkcja.Text= formula.Evaluate(Math.PI).ToString();
            Rectangle blueRectangle = new Rectangle();

            blueRectangle.Width = 200;

            blueRectangle.Height = 200;

            blueRectangle.Stroke = new SolidColorBrush(Colors.Black);

            blueRectangle.StrokeThickness = 10;

            blueRectangle.Fill = new SolidColorBrush(Colors.Blue);

            // Set Canvas position

            Canvas.SetLeft(blueRectangle, 60);

            Canvas.SetTop(blueRectangle, 60);

            // Add Rectangle to Canvas

            plot.Children.Add(blueRectangle);
        }


    }
}
