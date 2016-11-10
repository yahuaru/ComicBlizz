using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComicBlizz
{
    interface IComicSearch
    {
        Task<List<string>> SearchComic(string name);
    }
}
