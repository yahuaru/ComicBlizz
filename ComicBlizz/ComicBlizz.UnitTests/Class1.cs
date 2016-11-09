using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ComicBlizz.UnitTests
{
    public class Class1
    {
        [Fact]
        public void PassingTest()
        {
            var taskImage = WebUtils.LoadImage(new Uri("https://66.media.tumblr.com/avatar_7880574f7005_128.png"));
            taskImage.Wait();
        }
    }
}
