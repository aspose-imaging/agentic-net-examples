using System;
using System.IO;
using System.Net.Http;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded URL of the WebP image to load.
            string url = "https://example.com/sample.webp";

            // Download the image into a stream.
            using (HttpClient client = new HttpClient())
            using (Stream networkStream = client.GetStreamAsync(url).Result)
            // Load the WebP image from the network stream.
            using (WebPImage webPImage = new WebPImage(networkStream))
            {
                // Extract and log basic metadata.
                Console.WriteLine($"File Format : {webPImage.FileFormat}");
                Console.WriteLine($"Dimensions  : {webPImage.Width} x {webPImage.Height}");

                // Attempt to retrieve original options which may contain EXIF data.
                var originalOptions = webPImage.GetOriginalOptions() as WebPOptions;
                if (originalOptions != null && originalOptions.ExifData != null)
                {
                    Console.WriteLine("EXIF data is present.");
                }
                else
                {
                    Console.WriteLine("No EXIF data found.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application needs to download a WebP image from a remote server and log its format, dimensions, and EXIF presence for audit trails.
 * 2. When a cloud‑based image processing pipeline must validate incoming WebP assets by reading them directly from an HTTP stream without saving to disk.
 * 3. When a mobile backend service wants to extract metadata from user‑uploaded WebP photos to populate a database of image attributes.
 * 4. When a monitoring tool requires real‑time inspection of WebP files served over the network to detect missing or corrupted EXIF data.
 * 5. When a content management system integrates Aspose.Imaging to fetch WebP graphics from external URLs and record their size and metadata for SEO optimization.
 */