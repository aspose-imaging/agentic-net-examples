using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/multipage.tif";
            string outputPath = "Output/animated.webp";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the multi‑page TIFF
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Configure WebP export options
                using (WebPOptions webpOptions = new WebPOptions())
                {
                    // Example settings (adjust as needed)
                    webpOptions.Lossless = false;
                    webpOptions.Quality = 80;
                    webpOptions.AnimLoopCount = 0; // infinite loop

                    // Batch processing: action executed for each page before it is saved
                    tiffImage.PageExportingAction = delegate (int index, Image page)
                    {
                        // Optional per‑page processing can be placed here
                        // For demonstration, force garbage collection to free previous page resources
                        GC.Collect();
                    };

                    // Save all pages as an animated WebP
                    tiffImage.Save(outputPath, webpOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}