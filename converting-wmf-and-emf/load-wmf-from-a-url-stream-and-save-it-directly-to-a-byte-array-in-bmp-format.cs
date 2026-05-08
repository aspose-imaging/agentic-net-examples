using System;
using System.IO;
using System.Net.Http;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded URL of the WMF image
            string inputUrl = "https://example.com/sample.wmf";

            // Download the WMF data into a stream
            using (HttpClient httpClient = new HttpClient())
            using (Stream wmfStream = httpClient.GetStreamAsync(inputUrl).Result)
            // Load the WMF image from the stream
            using (Image wmfImage = Image.Load(wmfStream))
            {
                // Prepare BMP save options (default options are sufficient)
                BmpOptions bmpOptions = new BmpOptions();

                // Save the image to a memory stream in BMP format
                using (MemoryStream bmpMemory = new MemoryStream())
                {
                    wmfImage.Save(bmpMemory, bmpOptions);
                    // Retrieve the byte array containing the BMP data
                    byte[] bmpBytes = bmpMemory.ToArray();

                    // Example usage: output the size of the resulting byte array
                    Console.WriteLine($"BMP byte array length: {bmpBytes.Length}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}