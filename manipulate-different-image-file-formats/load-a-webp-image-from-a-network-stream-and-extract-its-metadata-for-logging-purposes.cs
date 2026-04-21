using System;
using System.IO;
using System.Net.Http;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded URL of the WebP image
            string url = "https://example.com/image.webp";

            using (var httpClient = new HttpClient())
            {
                using (Stream stream = httpClient.GetStreamAsync(url).GetAwaiter().GetResult())
                {
                    using (var webPImage = new WebPImage(stream))
                    {
                        // Extract metadata
                        var exif = webPImage.ExifData;
                        var xmp = webPImage.XmpData;

                        Console.WriteLine("Metadata extraction:");
                        Console.WriteLine("Exif data: " + (exif != null ? "Present" : "None"));
                        Console.WriteLine("XMP data: " + (xmp != null ? "Present" : "None"));
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