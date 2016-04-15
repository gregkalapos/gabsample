using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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

namespace Gab.Uwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static string SERVICEURIBASE = "PAST SERVICE ADDRESS";

        public MainPage()
        {
            this.InitializeComponent();
            LoadData();
        }

        private async void LoadData()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(SERVICEURIBASE);

            var notesList = JsonConvert.DeserializeObject<List<Note>>(await response.Content.ReadAsStringAsync());

            NotesGridView.ItemsSource = notesList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CreatePage));
        }
    }
}
