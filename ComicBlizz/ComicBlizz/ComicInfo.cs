using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBlizz
{
    class ComicInfo
    {
        public ComicInfo(string name, string description, int chapters)
        {
            _name = name;
            _description = description;
            _chapters = chapters;
        }

        private string _name;
        private string _description;
        private int _chapters;
    }
}
