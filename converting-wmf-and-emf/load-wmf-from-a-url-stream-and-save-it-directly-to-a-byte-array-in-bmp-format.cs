using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // URL of the WMF image
        string url = "https://example.com/sample.wmf";

        // Download the WMF data into a stream
        var httpClient = new System.Net.Http.HttpClient();
        var response = httpClient.GetAsync(url).Result;
        if (!response.IsSuccessStatusCode)
        {
            Console.Error.WriteLine($"Failed to download WMF from: {url}");
            return;
        }

        using (Stream inputStream = response.Content.ReadAsStreamAsync().Result)
        {
            // Load the WMF image from the stream
            using (Image image = Image.Load(inputStream))
            {
                using (Aspose.Imaging.FileFormats.Wmf.WmfImage wmfImage = (Aspose.Imaging.FileFormats.Wmf.WmfImage)image)
                {
                    // Save the image as BMP into a memory stream
                    using (var outputStream = new MemoryStream())
                    {
                        wmfImage.Save(outputStream, new BmpOptions());
                        byte[] bmpBytes = outputStream.ToArray();
                        Console.WriteLine($"BMP byte array length: {bmpBytes.Length}");
                    }
                }
            }
        }
    }
}