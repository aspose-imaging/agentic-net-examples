// HOW-TO: Apply 3x3 Median Filter to PNG After Background Removal in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage rasterImage = (RasterImage)image;

                // TODO: Perform background removal here if needed
                // (Background removal logic would be placed here)

                // Apply median filter with kernel size 3 to the entire image
                rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(3));

                // Save the processed image
                rasterImage.Save(outputPath);
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
 * 1. When you need to clean up scanned PNG documents by removing speckles after extracting the foreground.
 * 2. When preparing product photos for an e‑commerce site, you want to smooth minor noise after making the background transparent.
 * 3. When processing medical imaging PNGs, you apply a median filter to reduce salt‑and‑pepper artifacts while preserving edges.
 * 4. When automating batch conversion of PNG screenshots, you use the filter to improve visual quality after removing unwanted background colors.
 * 5. When developing a C# application that enhances PNG graphics for printing, you smooth small imperfections post‑background removal.
 */
