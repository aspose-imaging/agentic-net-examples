using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.cdr";
        string outputPath = @"C:\temp\sample_brightness.tif";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the CDR document
            using (Image image = Image.Load(inputPath))
            {
                // Attempt to treat the loaded image as a raster image
                if (image is RasterImage rasterImage)
                {
                    // Increase brightness by ~15% (15% of 255 ≈ 38)
                    rasterImage.AdjustBrightness(38);

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the result as a TIFF file
                    var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    rasterImage.Save(outputPath, tiffOptions);
                }
                else
                {
                    Console.Error.WriteLine("The loaded image is not a raster image and cannot be processed for brightness adjustment.");
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
 * 1. When a graphic designer needs to batch‑process CorelDRAW (CDR) files to make them slightly brighter for printing proofs and then archive the results as high‑resolution TIFF images using C# and Aspose.Imaging.
 * 2. When an automated document‑conversion service must increase the visual contrast of scanned CDR artwork by about 15 % before delivering the output in a lossless TIFF format for downstream publishing workflows.
 * 3. When a legacy CAD system exports drawings as CDR files that appear too dark on screen, a developer can use this code to brighten the images and save them as TIFF files for integration with GIS mapping tools.
 * 4. When a web application generates product catalogs from CDR source files and wants to ensure consistent brightness across all pages, the code can adjust each image and store the results as TIFF files for high‑quality PDF generation.
 * 5. When a digital archiving solution needs to normalize the exposure of CDR illustrations by raising brightness 15 % and preserve them in a widely supported TIFF format for long‑term storage, this C# snippet provides the required processing.
 */