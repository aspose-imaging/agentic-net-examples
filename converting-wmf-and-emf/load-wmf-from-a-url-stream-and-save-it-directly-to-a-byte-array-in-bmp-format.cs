// HOW-TO: Download WMF from URL and Convert to BMP Byte Array in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Net;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths (required by priority rules)
            string inputUrl = "https://example.com/sample.wmf";
            string outputPath = "output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Download WMF data from URL
            using (WebClient client = new WebClient())
            {
                byte[] wmfData = client.DownloadData(inputUrl);
                using (MemoryStream wmfStream = new MemoryStream(wmfData))
                {
                    // Load WMF image
                    using (Image image = Image.Load(wmfStream))
                    {
                        // Save image to BMP format in a memory stream
                        using (MemoryStream bmpStream = new MemoryStream())
                        {
                            BmpOptions bmpOptions = new BmpOptions();
                            image.Save(bmpStream, bmpOptions);
                            byte[] bmpBytes = bmpStream.ToArray();

                            // Example usage: output the size of the BMP byte array
                            Console.WriteLine($"BMP byte array length: {bmpBytes.Length}");
                        }
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

/*
 * Real-World Use Cases:
 * 1. When you need to fetch a vector WMF graphic from a web service and embed it as a BMP byte array in a PDF or email attachment.
 * 2. When you want to convert online WMF icons to BMP for use in a Windows Forms application without writing to disk.
 * 3. When a cloud function must download a WMF logo, transform it to BMP, and store the resulting bytes in a database.
 * 4. When generating thumbnails for WMF files in a web API that returns the image data as a byte array.
 * 5. When integrating legacy WMF assets into a modern C# service that requires BMP data for further processing like OCR or printing.
 */
