using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\input_multi.tif";
        string outputPath = @"C:\Images\output.webp";

        // Ensure any runtime exception is reported cleanly
        try
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the multi‑page TIFF
            using (Image tiffImage = Image.Load(inputPath))
            {
                // Cast to RasterCachedMultipageImage to release each page after it is processed
                if (tiffImage is RasterCachedMultipageImage rasterImage)
                {
                    rasterImage.PageExportingAction = (index, page) =>
                    {
                        // Release resources for the just‑processed page
                        GC.Collect();
                    };
                }

                // Prepare WebP export options (animated WebP will contain all pages as frames)
                var webpOptions = new WebPOptions
                {
                    // Keep all pages; MultiPageOptions left null to export the whole image
                    // Adjust quality/compression as needed
                    Quality = 80,
                    Lossless = false
                };

                // Save as a single (animated) WebP file
                tiffImage.Save(outputPath, webpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}