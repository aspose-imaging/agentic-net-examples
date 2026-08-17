// HOW-TO: Check If TIFF Has Alpha Channel After Gaussian Blur in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.tif";
        string outputPath = @"C:\Images\output.png";

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
                TiffImage tiffImage = (TiffImage)image;

                // Check alpha channel before processing
                bool hasAlphaBefore = tiffImage.HasAlpha;

                // Apply Gaussian blur filter to the whole image
                tiffImage.Filter(
                    tiffImage.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                // Save the processed image as PNG
                PngOptions pngOptions = new PngOptions();
                tiffImage.Save(outputPath, pngOptions);

                // Check alpha channel after processing
                bool hasAlphaAfter = tiffImage.HasAlpha;

                Console.WriteLine($"HasAlpha before blur: {hasAlphaBefore}, after blur: {hasAlphaAfter}");
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
 * 1. When you need to verify whether a multi‑page TIFF retains its transparency after applying a Gaussian blur before converting it to PNG.
 * 2. When a workflow requires detecting alpha channel changes in medical imaging TIFF files after noise‑reduction filtering in a C# application.
 * 3. When you want to ensure that a scanned document’s transparency is preserved after blur processing for watermarking purposes.
 * 4. When building an automated batch job that blurs satellite TIFF images and must log if the blur operation removes or adds an alpha channel before saving as PNG.
 * 5. When debugging image‑processing pipelines to compare the presence of an alpha channel in a TIFF before and after applying a Gaussian blur filter using Aspose.Imaging for .NET.
 */
