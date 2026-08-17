// HOW-TO: Batch Dither TIFF Images to 1‑Bit PNGs Using C# Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

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
            // Also include *.tiff files
            string[] tiffFilesAlt = Directory.GetFiles(inputFolder, "*.tiff");
            string[] allFiles = new string[tiffFiles.Length + tiffFilesAlt.Length];
            tiffFiles.CopyTo(allFiles, 0);
            tiffFilesAlt.CopyTo(allFiles, tiffFiles.Length);

            foreach (string inputPath in allFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the TIFF image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to TiffImage to access Dither method
                    TiffImage tiffImage = (TiffImage)image;

                    // Apply Floyd‑Steinberg dithering with a 1‑bit palette
                    tiffImage.Dither(DitheringMethod.FloydSteinbergDithering, 1, null);

                    // Build the output PNG path
                    string outputPath = Path.Combine(
                        outputFolder,
                        Path.GetFileNameWithoutExtension(inputPath) + ".png");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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
 * 1. When you need to convert a collection of high‑resolution scanned TIFF files into small, 1‑bit black‑and‑white PNGs for archival or web preview.
 * 2. When you must apply Floyd‑Steinberg dithering to reduce color depth before saving TIFFs as PNGs for printing on monochrome devices.
 * 3. When an automated script has to process all TIFF files in a folder and output PNGs with consistent dithering for a document‑management system.
 * 4. When you want to generate lightweight PNG thumbnails from multi‑page TIFFs while preserving visual detail using a 1‑bit palette.
 * 5. When a batch conversion tool must ensure the output directory exists and handle both .tif and .tiff extensions in a C# application.
 */
