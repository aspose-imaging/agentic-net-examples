using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.OpenDocument;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.otg";
        string outputPath = "result.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load OTG file into a memory stream
            using (FileStream fileStream = File.OpenRead(inputPath))
            using (MemoryStream memoryStream = new MemoryStream())
            {
                fileStream.CopyTo(memoryStream);
                memoryStream.Position = 0;

                // Wrap the memory stream in a StreamContainer required by OtgImage
                var streamContainer = new StreamContainer(memoryStream);

                // Create OtgImage from the stream container
                using (OtgImage otgImage = new OtgImage(streamContainer))
                {
                    // Prepare PNG save options with OTG rasterization settings
                    var pngOptions = new PngOptions();
                    var otgRaster = new OtgRasterizationOptions
                    {
                        PageSize = otgImage.Size // preserve original size
                    };
                    pngOptions.VectorRasterizationOptions = otgRaster;

                    // Save the image as PNG
                    otgImage.Save(outputPath, pngOptions);
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
 * 1. When a web service receives an OTG file as a byte array and needs to generate a PNG thumbnail for browser preview.
 * 2. When a desktop application batch‑converts OTG images stored in a database BLOB field into PNG files for printing or archival.
 * 3. When a mobile app downloads an OTG image over HTTP, loads it into a MemoryStream to avoid disk I/O, and saves it as PNG for UI display.
 * 4. When an automated report generator extracts vector graphics from an OTG template, rasterizes them at the original size, and embeds the resulting PNG into a PDF.
 * 5. When a cloud function processes OTG email attachments, streams the content directly to memory, and creates PNG versions for indexing by an image search engine.
 */