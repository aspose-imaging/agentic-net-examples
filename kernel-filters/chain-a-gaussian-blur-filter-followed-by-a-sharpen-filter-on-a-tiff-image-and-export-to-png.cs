// HOW-TO: Apply Gaussian Blur Then Sharpen to TIFF and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output\\result.png";

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
                // Cast to TiffImage to access Filter method
                TiffImage tiffImage = (TiffImage)image;

                // Apply Gaussian blur filter (radius 5, sigma 4.0) to the whole image
                tiffImage.Filter(tiffImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Apply Sharpen filter (radius 5, sigma 4.0) to the whole image
                tiffImage.Filter(tiffImage.Bounds, new SharpenFilterOptions(5, 4.0));

                // Save the processed image as PNG
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
 * 1. When you need to reduce noise in a scanned TIFF document before enhancing edges and delivering the result as a web‑friendly PNG.
 * 2. When a batch process must soften a high‑resolution TIFF photograph and then sharpen details for a product catalog, outputting PNG files.
 * 3. When converting medical imaging TIFFs to PNG while applying a blur‑then‑sharpen pipeline to improve visual clarity for reports.
 * 4. When preparing archival TIFF images for mobile apps, applying Gaussian blur to smooth artifacts and sharpening to retain key features before saving as PNG.
 * 5. When integrating image preprocessing in a C# service that receives TIFF uploads, applies blur and sharpen filters, and stores the final PNG for downstream analysis.
 */
