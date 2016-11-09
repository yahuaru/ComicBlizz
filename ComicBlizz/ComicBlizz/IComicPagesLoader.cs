﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ComicBlizz
{
    interface IComicPagesLoader
    {
        Task<List<Image>> LoadPages(string name, int issue);
    }
}
