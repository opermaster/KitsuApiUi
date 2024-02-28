using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace KisuApiLogic
{
    static public class Main_Logic
    {
        static private string GetAnimeFav() {
            Uri link = new Uri("https://kitsu.io/api/edge/anime?sort=-favoritesCount&page[limit]=20");
            string response;
            HttpWebResponse res;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(link);
            res = (HttpWebResponse)req.GetResponse();
            using (var sr = new StreamReader(res.GetResponseStream())) {
                response = sr.ReadToEnd();
            };

            return response;
        }
        static private string GetAnimeData(string Anime_Name) {
            Anime_Name = Anime_Name.Replace(" ", "%20");
            Uri link = new Uri($"https://kitsu.io/api/edge/anime?filter[text]={Anime_Name}");

            string response;
            HttpWebResponse res;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(link);
            try {
                res = (HttpWebResponse)req.GetResponse();
                using (var sr = new StreamReader(res.GetResponseStream())) {
                    response = sr.ReadToEnd();
                };
            }
            catch {
                link = new Uri("https://kitsu.io/api/edge/anime?filter[text]=Naruto");
                req = (HttpWebRequest)WebRequest.Create(link);
                res = (HttpWebResponse)req.GetResponse();
                using (var sr = new StreamReader(res.GetResponseStream())) {
                    response = sr.ReadToEnd();
                };
            }
            return response;
        }
        static public AnimeResponse GetAnimeObj(string name) {
            string anime = GetAnimeData(name);
            AnimeResponse Anime_Obj = JsonConvert.DeserializeObject<AnimeResponse>(anime);
            return Anime_Obj;
        }
        static public AnimeResponse GetAnimeFavObj() {
            string anime = GetAnimeFav();
            AnimeResponse Anime_Obj = JsonConvert.DeserializeObject<AnimeResponse>(anime);
            return Anime_Obj;
        }
    }
}
