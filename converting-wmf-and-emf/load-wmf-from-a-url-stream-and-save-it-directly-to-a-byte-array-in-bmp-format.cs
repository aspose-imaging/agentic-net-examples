using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Entry point
    static async Task Main(string[] args)
    {
        try
        {
            // Hardcoded URL of the WMF image
            string wmfUrl = "https://example.com/sample.wmf";

            // Download the WMF image into a stream
            using (HttpClient httpClient = new HttpClient())
            using (HttpResponseMessage response = await httpClient.GetAsync(wmfUrl))
            using (Stream wmfStream = await response.Content.ReadAsStreamAsync())
            {
                // Load the WMF image from the stream
                using (Image wmfImage = Image.Load(wmfStream))
                {
                    // Prepare a memory stream to hold the BMP data
                    using (MemoryStream bmpStream = new MemoryStream())
                    {
                        // BMP save options (default settings)
                        BmpOptions bmpOptions = new BmpOptions();

                        // Save the image as BMP into the memory stream
                        wmfImage.Save(bmpStream, bmpOptions);

                        // Retrieve the BMP bytes
                        byte[] bmpBytes = bmpStream.ToArray();

                        // Example usage: output the size of the resulting BMP byte array
                        Console.WriteLine($"BMP byte array length: {bmpBytes.Length}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}