// HOW-TO: Convert BMP to Grayscale TIFF for Archival Storage in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.bmp";
        string outputPath = @"C:\Images\output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load BMP image
            using (Image bmpImage = Image.Load(inputPath))
            {
                // Save as TIFF (initial conversion)
                bmpImage.Save(outputPath, new TiffOptions(Aspose.Imaging.FileFormats.Tiff.Enums.TiffExpectedFormat.Default));
            }

            // Ensure output directory exists again (unconditional as required)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the newly created TIFF image
            using (Image tiffBase = Image.Load(outputPath))
            {
                // Cast to TiffImage to access Grayscale method
                TiffImage tiffImage = (TiffImage)tiffBase;

                // Convert to grayscale
                tiffImage.Grayscale();

                // Save the grayscale TIFF (overwrites the previous file)
                tiffImage.Save(outputPath);
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
 * 1. When you need to archive legacy BMP scans as lossless grayscale TIFF files for long‑term storage.
 * 2. When a document management system requires all incoming images to be in a single grayscale TIFF format.
 * 3. When you must convert color BMP screenshots to grayscale TIFF to reduce file size while preserving detail for legal records.
 * 4. When integrating a C# batch job that standardizes various bitmap assets into archival‑ready TIFF images.
 * 5. When preparing medical or engineering drawings originally in BMP for compliance with TIFF‑only archival standards.
 */
