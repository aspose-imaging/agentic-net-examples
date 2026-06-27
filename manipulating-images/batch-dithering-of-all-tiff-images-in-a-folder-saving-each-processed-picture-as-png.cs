using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputFolder = @"C:\Images\Input";
        string outputFolder = @"C:\Images\Output";

        try
        {
            // Get all TIFF files in the input folder
            string[] tiffFiles = Directory.GetFiles(inputFolder, "*.tif");

            foreach (string inputPath in tiffFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output PNG path
                string outputPath = Path.Combine(
                    outputFolder,
                    Path.GetFileNameWithoutExtension(inputPath) + ".png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image, apply dithering, and save as PNG
                using (Image image = Image.Load(inputPath))
                {
                    TiffImage tiffImage = (TiffImage)image;

                    // Apply Floyd‑Steinberg dithering with a 1‑bit palette
                    tiffImage.Dither(DitheringMethod.FloydSteinbergDithering, 1, null);

                    // Save the processed image as PNG
                    tiffImage.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to batch‑convert a folder of high‑resolution TIFF scans into web‑ready PNG files while applying Floyd‑Steinberg 1‑bit dithering to reduce size and preserve detail.
 * 2. When an archival system must automatically process incoming TIFF documents, dither them, and store the results as lossless PNG images for long‑term preservation.
 * 3. When a printing workflow requires converting multi‑page TIFF assets into single‑page PNGs with a binary palette to ensure compatibility with raster printers.
 * 4. When a digital asset management application needs to generate thumbnail PNG previews from a directory of TIFF images using Aspose.Imaging’s dithering API in C#.
 * 5. When a migration script has to bulk‑convert legacy TIFF graphics to PNG format with consistent dithering to maintain uniform appearance across different platforms.
 */