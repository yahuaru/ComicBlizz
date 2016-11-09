using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ComicBlizz
{
    [Serializable]
    class ComicInfo
    {
        public ComicInfo()
        {
            
        }

        public ComicInfo(Image cover, string name, string description, int chapters)
        {
            Cover = cover;
            Name = name;
            Description = description;
            Chapters = chapters;
        }

        public Image Cover;
        public string Name;
        public string Description;
        public int Chapters;
    }
}
