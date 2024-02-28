using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KisuApiLogic
{
    public class Titles
    {
        public string en;
        public string en_jp;
        public string ja_jp;
          
    }
    public class PosterImage
    {
        public string tiny;
        public string small;
        public string medium;
        public string large;
        public string original;
    }
    public class Attribs
    {
        public PosterImage posterImage;
        public string createdAt;
        public string slug;
        public string synopsis;
        public Titles titles;
    }
    public class Data
    {
        public int id;
        public string type;
        public Attribs attributes;

    }
    public class AnimeResponse
    {
        public List<Data> data;
    }
}
