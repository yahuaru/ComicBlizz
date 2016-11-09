using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ComicBlizz.UnitTests
{
    public class ReadcomicsLoaderTests
    {
        [Fact]
        public void PassingTest()
        {
            var taskImage = WebUtils.LoadImage(new Uri("https://66.media.tumblr.com/avatar_7880574f7005_128.png"));
            taskImage.Wait();
            Assert.True(taskImage.IsCompleted);
        }

        [Fact]
        public void LoadComics()
        {
            var comicLoader = new ReadcomicsComicPagesLoader();
            var task = comicLoader.LoadPages("daredevil-2016", 1);
            task.Wait();
        }

        [Fact]
        public void LoadInfo()
        {
            var comicLoader = new ReadcomicsComicInfoLoader();
            var task = comicLoader.LoadComicInfo("daredevil-2016");
            task.Wait();
        }
    }
}
