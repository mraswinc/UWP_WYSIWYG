using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP_WYSIWYG
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

        private async void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            string result=await InvokeScript();
            richEditBox.Document.SetText(TextSetOptions.None, result.ToString());
        }

        private async Task<string> InvokeScript()
        {
            string result = "";
            try
            {
                result = await summernoteWebView.InvokeScriptAsync("getHTML", null);
                return result;
            }
            catch (Exception ex)
            {
                result = "";
                return result;
            }
        }
    }
}
