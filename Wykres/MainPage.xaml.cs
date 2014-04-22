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
        private void podzialkaox(int podzialka)
        {
            for (int i = 0; i < (int)(plot.ActualWidth / 2); i = i + podzialka)
            {
                Line linex = new Line();
                Line linexminus = new Line();
                linex.X1 = plot.ActualWidth / 2 - i;
                linex.X2 = plot.ActualWidth / 2 - i;
                linexminus.X1 = plot.ActualWidth / 2 + i;
                linexminus.X2 = plot.ActualWidth / 2 + i;
                linex.Y1 = (int)(plot.ActualHeight / 2) - 5;
                linex.Y2 = (int)(plot.ActualHeight / 2) + 5;
                linexminus.Y1 = (int)(plot.ActualHeight / 2) - 5;
                linexminus.Y2 = (int)(plot.ActualHeight / 2) + 5;
                linex.Stroke = new SolidColorBrush(Colors.Black);
                linexminus.Stroke = new SolidColorBrush(Colors.Black);
                plot.Children.Add(linex);
                plot.Children.Add(linexminus);
            }
        }
        private void  podzialkaOY(int podzialka){
             for (int i = 0; i < (int)(plot.ActualHeight / 2); i = i + podzialka)
            {
                
                Line linex = new Line();
                Line linexminus = new Line();
                linex.Y1 = plot.ActualHeight / 2 - i;
                linex.Y2 = plot.ActualHeight / 2 - i;
                linex.X1 = (int)(plot.ActualWidth / 2) - 5;
                linex.X2 = (int)(plot.ActualWidth / 2) + 5;
                linexminus.Y1 = plot.ActualHeight / 2 + i;
                linexminus.Y2 = plot.ActualHeight / 2 + i;
                linexminus.X1 = (int)(plot.ActualWidth / 2) - 5;
                linexminus.X2 = (int)(plot.ActualWidth / 2) + 5;
                linex.Stroke = new SolidColorBrush(Colors.Black);
                linexminus.Stroke = new SolidColorBrush(Colors.Black);
                plot.Children.Add(linex);
                plot.Children.Add(linexminus);
            }
        }
        private void ukladwspolrzednych(int podzialka)
        {
            Line lineOY = new Line();
            lineOY.X1 = (int)(plot.ActualWidth / 2);
            lineOY.X2 = (int)(plot.ActualWidth / 2);
            lineOY.Y1 = 0;
            lineOY.Y2 = (int)(plot.ActualHeight);
            lineOY.Stroke = new SolidColorBrush(Colors.Red);
            plot.Children.Add(lineOY);
            Line lineOX = new Line();
            lineOX.X1 = 0;
            lineOX.X2 = (int)(plot.ActualWidth);
            lineOX.Y1 = (int)(plot.ActualHeight / 2);
            lineOX.Y2 = (int)(plot.ActualHeight / 2);
            lineOX.Stroke = new SolidColorBrush(Colors.Red);
            plot.Children.Add(lineOX);
            var p =(int)(zoom());
            podzialkaox(podzialka*p);
            podzialkaOY(podzialka*p);
            
           
        }
        private double zoom()
        {
            return slidertick.Value;
        }
        
        private void plotuj_Click(object sender, RoutedEventArgs e)
        {
            var formula = Maths.MathParse.Parse("0");
            try {  formula = Maths.MathParse.Parse(funkcja.Text);
                   //funkcja.Text = formula.Evaluate(2).ToString();
            }
            catch (Exception t) { funkcja.Text = "ERROR!"; }
            ukladwspolrzednych(10);
            var p = zoom();
            Polyline myPolygon = new Polyline();
            myPolygon.Stroke = new SolidColorBrush(Colors.Red); 
            
            myPolygon.StrokeThickness = 2;
            myPolygon.HorizontalAlignment = HorizontalAlignment.Left;
            myPolygon.VerticalAlignment = VerticalAlignment.Center;

            PointCollection points = new PointCollection();
            for (int x = -(int)(((plot.ActualWidth)/2)); x < ((plot.ActualWidth/2)) - 1; x += 1)
            {
                var t = x + (plot.ActualWidth/2);
                var y = (plot.ActualHeight / 2) - formula.Evaluate(x/p);
                if (y > 0 && y <= plot.ActualHeight)
                {
                    Point point = new Point(t , y);
                    points.Add(point);
                }
            }

            myPolygon.Points = points;
            plot.Children.Add(myPolygon);

            
        }

        private void nowy_Click(object sender, RoutedEventArgs e)
        {
            plot.Children.Clear();
            ukladwspolrzednych(20);

        }


    }
}
