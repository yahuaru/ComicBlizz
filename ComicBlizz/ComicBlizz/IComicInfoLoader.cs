﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComicBlizz
{
    interface IComicInfoLoader
    {
        Task<ComicInfo> LoadComicInfo(string url);
    }

}
