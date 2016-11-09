using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ComicBlizz
{
    class WebUtils
    {
        public static async Task<Image> LoadImage(Uri uri)
        {
            Image image = new Image();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (var response = await client.GetAsync(uri))
                    {
                        response.EnsureSuccessStatusCode();

                        using (Stream stream = await response.Content.ReadAsStreamAsync())
                        {
                            image.Source = ImageSource.FromStream(() => { return stream; });
                        }
                    }
                }
                return image;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to load the image: {0}", ex.Message);
            }

            return null;
        }
    }
}
