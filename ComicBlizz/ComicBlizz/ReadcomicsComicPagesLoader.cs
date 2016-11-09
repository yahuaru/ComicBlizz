using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Xamarin.Forms;

namespace ComicBlizz
{
    class ReadcomicsComicPagesLoader : IComicPagesLoader
    {
        private const string _readcomicsImageBaseUrl = "http://www.readcomics.tv/images/manga/{0}/{1}/{2}.jpg";
        private const string _readcomicsPageBaseUrl = "http://www.readcomics.tv/{0}/chapter-{1}";

        public async Task<List<Image>> LoadPages(string name, int issue)
        {
            int pagesCount = 0;

            string url = string.Format(_readcomicsPageBaseUrl, name, issue);
            HttpClient client = new HttpClient();
            using (HttpResponseMessage response = await client.GetAsync(url))
            {
                using (HttpContent content = response.Content)
                {
                    string result = await content.ReadAsStringAsync();
                    var doc = new HtmlDocument();
                    doc.LoadHtml(result);

                    var select = doc.DocumentNode.Descendants("select").Where(
                        n =>
                        {
                            var htmlAttribute = n.Attributes["name"];
                            return htmlAttribute != null && htmlAttribute.Value != "select_page";
                        });

                    var htmlNodes = @select as IList<HtmlNode> ?? @select.ToList();
                    var htmlNode = htmlNodes.Count > 0 ? htmlNodes[0] : null;

                    pagesCount = htmlNode.ChildNodes.Count;
                }
            }
            if (pagesCount == 0) return null;
            List<Image> images = new List<Image>(pagesCount);

            for (int i = 0; i < pagesCount; i++)
            {
                var imgUrl = string.Format(_readcomicsImageBaseUrl, name, issue, i);
                images.Add(await WebUtils.LoadImage(new Uri(imgUrl)));
            }

            return images;
        }
    }
}
