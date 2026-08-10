// HOW-TO: Convert OTG to PNG and Get MemoryStream in C# (Aspose.Imaging for .NET)
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

            // Verify that the input file exists
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

                // Save the image to a memory stream
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    otgImage.Save(memoryStream, pngOptions);
                    // Example usage of the resulting stream
                    Console.WriteLine($"PNG saved to memory stream, length = {memoryStream.Length} bytes");
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
 * 1. When you need to display or transmit an OpenDocument Graphic (OTG) as a PNG without writing a temporary file, you can load the OTG and save it directly to a MemoryStream.
 * 2. When a web API must return a PNG representation of an uploaded OTG image, this code converts the file in memory for a fast response.
 * 3. When generating thumbnails for OTG documents in a background service, converting to PNG in a MemoryStream avoids disk I/O and simplifies caching.
 * 4. When integrating Aspose.Imaging into a Windows service that processes batch OTG files and streams the PNG results to another system, this approach keeps the workflow entirely in memory.
 * 5. When performing on‑the‑fly rasterization of vector OTG graphics for PDF or email attachments, saving to a MemoryStream lets you embed the PNG without creating intermediate files.
 */
