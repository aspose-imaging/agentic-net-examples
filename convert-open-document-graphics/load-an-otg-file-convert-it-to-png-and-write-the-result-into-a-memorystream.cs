using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input path
            string inputPath = @"C:\Images\sample.otg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the OTG image
            using (Image otgImage = Image.Load(inputPath))
            {
                // Prepare PNG save options with OTG rasterization settings
                var pngOptions = new PngOptions();
                var otgRasterOptions = new OtgRasterizationOptions
                {
                    // Preserve original size
                    PageSize = otgImage.Size
                };
                pngOptions.VectorRasterizationOptions = otgRasterOptions;

                // Save the image to a memory stream in PNG format
                using (var memoryStream = new MemoryStream())
                {
                    otgImage.Save(memoryStream, pngOptions);

                    // Example usage of the resulting PNG data
                    Console.WriteLine($"PNG data size: {memoryStream.Length} bytes");
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
 * 1. When a web service needs to receive an OpenDocument graphic (OTG) upload and return a PNG thumbnail without writing temporary files to disk.
 * 2. When a desktop application must embed a vector OTG diagram into a PDF report by first rasterizing it to a PNG stream for further processing.
 * 3. When an automated batch job converts a library of OTG icons to PNG format for use in a mobile app, storing the results in memory before uploading to a CDN.
 * 4. When a cloud function generates on‑the‑fly PNG previews of user‑submitted OTG files for display in a gallery, using a MemoryStream to avoid filesystem I/O.
 * 5. When a unit test validates that the Aspose.Imaging OTG rasterization options correctly preserve the original page size by converting the image to PNG in a memory buffer.
 */