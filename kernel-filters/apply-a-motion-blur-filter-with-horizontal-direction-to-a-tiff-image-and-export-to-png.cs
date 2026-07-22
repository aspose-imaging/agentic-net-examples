using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.tif";
        string outputPath = @"C:\Images\sample_motionblur.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access the Filter method
                TiffImage tiffImage = (TiffImage)image;

                // Apply a horizontal motion blur (angle = 0 degrees)
                // Length = 10, Smooth = 1.0 (default), Angle = 0.0 (horizontal)
                tiffImage.Filter(
                    tiffImage.Bounds,
                    new MotionWienerFilterOptions(10, 1.0, 0.0));

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
 * 1. When a developer needs to create a preview thumbnail of a high‑resolution TIFF document with a horizontal motion‑blur effect for faster web loading, they can use this C# Aspose.Imaging code to filter and save it as a PNG.
 * 2. When a medical imaging application must anonymize patient scans by obscuring fine horizontal details in a TIFF X‑ray image before sharing it as a PNG, the motion blur filter in C# provides a quick solution.
 * 3. When a GIS system wants to simulate camera shake on aerial TIFF maps and export the result as a lightweight PNG for UI overlays, the horizontal MotionWienerFilterOptions can be applied using Aspose.Imaging for .NET.
 * 4. When an e‑commerce platform needs to generate stylized product images by adding a subtle horizontal blur to original TIFF photos and converting them to PNG for responsive design, this code automates the process.
 * 5. When a digital archiving workflow requires batch processing of scanned TIFF pages to add a uniform horizontal motion blur for visual effect and then store them as PNG files for archival browsers, the provided C# snippet handles the filter and conversion.
 */