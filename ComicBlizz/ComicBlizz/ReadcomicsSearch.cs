using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace ComicBlizz
{
    class ReadcomicsSearch : IComicSearch
    {
        private const string baseUrl = "http://readcomics.tv/comic-search?key=";

        public async Task<List<string>> SearchComic(string name)
        {
            List<string> comicsTitles = new List<string>();
            var url = baseUrl + name;
            HttpClient client = new HttpClient();
            using (HttpResponseMessage response = await client.GetAsync(url))
            {
                using (HttpContent content = response.Content)
                {
                    string result = await content.ReadAsStringAsync();
                    var doc = new HtmlDocument();
                    doc.LoadHtml(result);

                    var boxes = doc.DocumentNode.Descendants("div").Where(
                        n => n.Attributes.Contains("class") && n.Attributes["class"].Value.Contains("manga-box")
                    );


                    foreach (var box in boxes)
                    {
                        var titleBoxes = box.Descendants("div").Where(
                            n => n.Attributes.Contains("class") && n.Attributes["class"].Value.Contains("mb-right")
                        );
                        var titleBox = (titleBoxes as IList<HtmlNode> ?? titleBoxes.ToList())[0];
                        var titleNode = titleBox.Descendants("a");
                        var title = (titleNode as IList<HtmlNode> ?? titleNode.ToList())[0].InnerText;
                        comicsTitles.Add(title);
                    }
                }
            }
            return comicsTitles;
        }
    }
}
