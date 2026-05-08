using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.tif";
        string outputPath = @"C:\Images\output.webp";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            // Load the multi‑page TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // If the image supports page exporting actions, release each page after it is processed
                if (image is RasterCachedMultipageImage rasterImage)
                {
                    rasterImage.PageExportingAction = (index, page) =>
                    {
                        // Force garbage collection to free memory of the processed page
                        GC.Collect();
                    };
                }

                // Prepare WebP export options (default settings export all pages as animated frames)
                var webpOptions = new WebPOptions();

                // Save as a single WebP file
                image.Save(outputPath, webpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}