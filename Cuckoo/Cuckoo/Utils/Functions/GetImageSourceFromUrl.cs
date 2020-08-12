using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cuckoo.Utils
{
    public partial class Functions
    {
        public static async Task<ImageSource> GetImageSourceFromUrlAsync(string url)
        {
            byte[] imageData = null;
            MemoryStream ms = null;

            try
            {
                using (var wc = new System.Net.WebClient())
                {
                    imageData = await wc.DownloadDataTaskAsync(url);
                }
                ms = new MemoryStream(imageData);
            }
            catch { }

            return ImageSource.FromStream(() => ms);
        }
    }
}
