using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace ComicBlizz
{
    class ReadcomicsComicInfoLoader : IComicInfoLoader
    {
        private const string baseUrl = "http://www.readcomics.tv/comic/";

        public async Task<Task<ComicInfo>> LoadComicInfo(string name)
        {
            var comicInfo = new ComicInfo();
            var url = baseUrl + name;
            HttpClient client = new HttpClient();
            using (HttpResponseMessage response = await client.GetAsync(url))
            {
                using (HttpContent content = response.Content)
                {
                    string result = await content.ReadAsStringAsync();
                    var doc = new HtmlDocument();
                    doc.LoadHtml(result);

                    var imgUrl = doc.GetElementbyId("series_image").GetAttributeValue("src", "");
                    var img = await WebUtils.LoadImage(new Uri(imgUrl));
                    comicInfo.Cover = img;

                    var titleDiv = doc.DocumentNode.Descendants("h1").Where(
                        n => n.Attributes.Contains("class") && n.Attributes["class"].Value.Contains("manga-title")
                        );

                    comicInfo.Name = (@titleDiv as IList<HtmlNode> ?? @titleDiv.ToList())[0].InnerText;

                    var descDiv = doc.DocumentNode.Descendants("p").Where(
                        n =>
                        {
                            var htmlAttribute = n.Attributes["class"];
                            return htmlAttribute != null && htmlAttribute.Value == "pdesc";
                        });

                    comicInfo.Description = (descDiv as IList<HtmlNode> ?? descDiv.ToList())[0].InnerText;
                }
            }

            return null;
        }
    }
}
