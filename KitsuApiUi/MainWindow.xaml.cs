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
using System.Xml.Linq;
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
            AnimeResponse anime = Main_Logic.GetAnimeFavObj();
            Anime_List.Children.Add(CreateAnimeList(anime));
        }
        private StackPanel CreateAnimeList(AnimeResponse anime_response) {
            StackPanel main_list = new StackPanel();

            foreach (Data dt in anime_response.data) {
                var imgUrl = new Uri(dt.attributes.posterImage.large);
                var imageData = new WebClient().DownloadData(imgUrl);
                var bitmapImage = new BitmapImage { CacheOption = BitmapCacheOption.OnLoad };
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = new MemoryStream(imageData);
                bitmapImage.EndInit();

                Image poster = new Image(); poster.Width = 400; poster.Height= 400;
                poster.Source = bitmapImage;

                TextBlock anime_text_block = new TextBlock();
                anime_text_block.TextWrapping = TextWrapping.Wrap;
                anime_text_block.FontSize =30;

                anime_text_block.Text += dt.attributes.titles.en + " / "
                + dt.attributes.titles.ja_jp + "\n";
                anime_text_block.Text += "Type: "+dt.type + "\n";
                anime_text_block.Text += "Slug: " + dt.attributes.slug + "\n";
                anime_text_block.Text += "Synopsis: " + dt.attributes.synopsis + "\n";
                anime_text_block.Text += "Created at: " + dt.attributes.createdAt + "\n";
                main_list.Children.Add(poster);
                main_list.Children.Add(anime_text_block);
            }
            return main_list;
        }
        private void Enter_User_Name_Click(object sender, RoutedEventArgs e) {
            Anime_List.Children.Clear();
            AnimeResponse anime = Main_Logic.GetAnimeObj(Input_Name.Text);
            Anime_List.Children.Add(CreateAnimeList(anime));
        }
    }
}
