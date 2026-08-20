// HOW-TO: Create 150x150 PNG Thumbnail From Large TIFF Using Bicubic Resize In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\large.tif";
        string outputPath = @"C:\Images\thumbnail.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (TiffImage image = (TiffImage)Image.Load(inputPath))
            {
                // Resize to 150x150 using bicubic (CubicConvolution) resampling
                image.Resize(150, 150, ResizeType.CubicConvolution);

                // Save the result as PNG
                image.Save(outputPath, new PngOptions());
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
 * 1. When you need to generate a small preview PNG for a high‑resolution TIFF scanned document in a web application.
 * 2. When you want to display fast‑loading thumbnails of large medical imaging files without losing quality by using bicubic interpolation.
 * 3. When an e‑commerce site must create uniform 150 × 150 product image icons from original TIFF photos for catalog listings.
 * 4. When a desktop utility processes batch TIFF files and saves compact PNG thumbnails for quick file‑system browsing.
 * 5. When a reporting tool requires consistent PNG thumbnails of TIFF charts to embed in PDF or HTML reports.
 */
