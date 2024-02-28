using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using KisuApiLogic;

namespace KitsuApiUi
{
    /// <summary>
    /// MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() {
            InitializeComponent();
        }
        private void Enter_User_Name_Click(object sender, RoutedEventArgs e) {
            AnimeResponse anime = Main_Logic.GetAnimeObj(Input_Name.Text);

            var imgUrl = new Uri(anime.data[0].attributes.posterImage.large);
            var imageData = new WebClient().DownloadData(imgUrl);
            var bitmapImage = new BitmapImage { CacheOption = BitmapCacheOption.OnLoad };
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = new MemoryStream(imageData);
            bitmapImage.EndInit();
            Anime_Poster.Source = bitmapImage;
            Output_User.Text += anime.data[0].attributes.titles.en + "/"
                + anime.data[0].attributes.titles.ja_jp+"\n";
            Output_User.Text += anime.data[0].type + "\n";
            Output_User.Text += anime.data[0].attributes.slug + "\n";
            Output_User.Text += anime.data[0].attributes.synopsis + "\n";
            Output_User.Text += anime.data[0].attributes.createdAt + "\n";


        }
    }
}
