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
using Windows.UI.Xaml.Media.Imaging;
using System.ComponentModel;
using Windows.UI.Xaml.Media.Animation;
using Шашки.ViewModel;

// Шаблон элемента пользовательского элемента управления задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234236

namespace Шашки.View
{
    public sealed partial class CheckerControl : UserControl, INotifyPropertyChanged
    {
        public CheckerControl()
        {
            this.InitializeComponent();
        }
        public string SourceOfImage { get; private set; }
        public double WidthOfImage { get; private set; }
        private int code;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if (propertyChanged != null)
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public int X { get; private set; }
        public int Y { get; private set; }
        public CheckerControl(int code, int x, int y, bool bigImage) : this()
        {
            DataContext = this;
            X = x;
            Y = y;
            this.code = code;
            if (bigImage)
            {
                WidthOfImage = 72;
            }
            else
            {
                WidthOfImage = 39;
            }
            //Margin = new Thickness(x * WidthOfImage, y * WidthOfImage, 0, 0);
            Canvas.SetLeft(this, X * 72);
            Canvas.SetTop(this, Y * 72);
            OnPropertyChanged("WidthOfImage");
            if (code == 1)
                SourceOfImage = "/Assets/BlackUsual.png";
            if (code == 2)
                SourceOfImage = "/Assets/BlackQueen.png";
            if (code == 3)
                SourceOfImage = "/Assets/WhiteUsual.png";
            if (code == 4)
                SourceOfImage = "/Assets/WhiteQueen.png";
            OnPropertyChanged("SourceOfImage");
        }
        public void AnimateChangeOfPositon(int endX, int endY)
        {
            Storyboard Xstoryboard = new Storyboard();
            DoubleAnimation XdoubleAnimation = new DoubleAnimation();
            Storyboard.SetTarget(XdoubleAnimation, this);
            Storyboard.SetTargetProperty(XdoubleAnimation, "(Canvas.Left)");
            XdoubleAnimation.From = X * 72;
            XdoubleAnimation.To = endX * 72;
            XdoubleAnimation.Duration = TimeSpan.FromMilliseconds(500);
            Xstoryboard.Children.Add(XdoubleAnimation);
            X = endX;

            Storyboard Ystoryboard = new Storyboard();
            DoubleAnimation YdoubleAnimation = new DoubleAnimation();
            Storyboard.SetTarget(YdoubleAnimation, this);
            Storyboard.SetTargetProperty(YdoubleAnimation, "(Canvas.Top)");
            YdoubleAnimation.From = Y * 72;
            YdoubleAnimation.To = endY * 72;
            YdoubleAnimation.Duration = TimeSpan.FromMilliseconds(500);
            Ystoryboard.Children.Add(YdoubleAnimation);
            Y = endY;

            Xstoryboard.Begin();
            Ystoryboard.Begin();
        }
    }
}
