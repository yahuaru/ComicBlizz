using System;
using System.Collections.Generic;
using System.Text;

namespace ComicBlizz
{
    interface IComicInfoLoader
    {
        ComicInfo LoadComicInfo(string url);
    }

}
