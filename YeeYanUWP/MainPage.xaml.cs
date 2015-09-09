using DataHelperLib.Helpers;
using HtmlAgilityPack;
using MVVMSidekick.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace YeeYanUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : MVVMPage
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
            
        private void Panel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.splitView.IsPaneOpen = !this.splitView.IsPaneOpen;
        }

        private void Download_Click(object sender, RoutedEventArgs e)
        {
            HttpRequest request = new HttpRequest() { _url = "http://article.yeeyan.org/", _requestType = RequestType.Get };
            request.OnSuccess += (result, statusCode) => 
            {
                //DealWith HTML
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(result);
                var list = doc.DocumentNode.SelectNodes("//div[@class='list-group']");
                //list[0] is channel
                //list[1] is tag        
                var channelNode = list[0];
                var tagNode = list[1];

                //频道
                foreach (HtmlNode channel in channelNode.SelectNodes("a"))
                {
                    string href = channel.GetAttributeValue("href", "");
                    string title = channel.InnerText;
                    Debug.WriteLine(title + "-------------" + href);
                }
                //标签
                foreach (HtmlNode tag in tagNode.SelectNodes("a"))
                {
                    string href = tag.GetAttributeValue("href", "");
                    string title = tag.InnerText;
                    Debug.WriteLine(title + "-------------" + href);
                }
            };
            request.Run();
        }
    }
}
