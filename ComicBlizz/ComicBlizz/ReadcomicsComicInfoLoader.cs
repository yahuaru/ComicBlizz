using System;
using System.Collections.Generic;
using System.Text;

namespace ComicBlizz
{
    class ReadcomicsComicInfoLoader: IComicInfoLoader
    {
        public ComicInfo LoadComicInfo(string url)
        {

            //ComicInfo comicInfo = new ComicInfo();
            return new ComicInfo("", "", 0);
        }
    }
}
