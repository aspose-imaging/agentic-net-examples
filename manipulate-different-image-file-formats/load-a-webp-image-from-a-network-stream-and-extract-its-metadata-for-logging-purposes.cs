using System;
using System.IO;
using System.Net.Http;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded paths (not used for input stream, but required by the task)
        string inputUrl = "https://example.com/sample.webp";
        string outputPath = @"C:\Temp\WebPMetadata.txt";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Download the WebP image into a memory stream
            using (HttpClient httpClient = new HttpClient())
            using (Stream networkStream = httpClient.GetStreamAsync(inputUrl).Result)
            using (MemoryStream memoryStream = new MemoryStream())
            {
                networkStream.CopyTo(memoryStream);
                memoryStream.Position = 0; // Reset stream position for reading

                // Load the WebP image from the stream
                using (WebPImage webPImage = new WebPImage(memoryStream))
                {
                    // Extract basic metadata
                    string format = webPImage.FileFormat.ToString();
                    int width = webPImage.Width;
                    int height = webPImage.Height;

                    // Attempt to retrieve original EXIF data via original options
                    string exifInfo = "No EXIF data";
                    ImageOptionsBase originalOptions = webPImage.GetOriginalOptions();
                    if (originalOptions is WebPOptions webPOptions && webPOptions.ExifData != null)
                    {
                        exifInfo = webPOptions.ExifData.ToString();
                    }

                    // Prepare log message
                    string log = $"WebP Image Metadata:{Environment.NewLine}" +
                                 $"Format: {format}{Environment.NewLine}" +
                                 $"Dimensions: {width}x{height}{Environment.NewLine}" +
                                 $"EXIF: {exifInfo}{Environment.NewLine}";

                    // Output to console
                    Console.WriteLine(log);

                    // Save metadata to a file
                    File.WriteAllText(outputPath, log);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}