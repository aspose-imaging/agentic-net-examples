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
        string inputPath = @"c:\temp\sample.tif";
        string outputPath = @"c:\temp\sample.adjusted.png";

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
            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access AdjustBrightness
                TiffImage tiffImage = (TiffImage)image;

                // Increase brightness by 20 units
                tiffImage.AdjustBrightness(20);

                // Save the result as PNG
                tiffImage.Save(outputPath, new PngOptions());
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
 * 1. When a developer uses Aspose.Imaging for .NET to preprocess scanned TIFF documents, increase their brightness by 20 units, and save the clearer result as a PNG for web display.
 * 2. When an imaging application built with C# and Aspose.Imaging needs to automatically brighten low‑contrast satellite TIFF images and export them as PNG files for downstream analysis.
 * 3. When a medical imaging workflow employs Aspose.Imaging to adjust the brightness of TIFF scans derived from DICOM data and generate PNG thumbnails for quick review.
 * 4. When a batch‑processing script written in C# leverages Aspose.Imaging to enhance archival TIFF photographs by 20 brightness units and convert them to PNG for a digital archive.
 * 5. When a UI developer uses Aspose.Imaging for .NET to convert legacy TIFF graphics with poor lighting into brighter PNG assets suitable for modern application interfaces.
 */