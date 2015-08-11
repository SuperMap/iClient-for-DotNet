using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace SuperMap.Demo.WindowsPhone
{
    public partial class StartPage : PhoneApplicationPage
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MainPage.url = this.url.Text;
            string strUrl = string.Format("/MainPage.xaml?url={0}", this.url.Text);
            this.NavigationService.Navigate(new Uri(strUrl, UriKind.Relative));
        }
    }
}