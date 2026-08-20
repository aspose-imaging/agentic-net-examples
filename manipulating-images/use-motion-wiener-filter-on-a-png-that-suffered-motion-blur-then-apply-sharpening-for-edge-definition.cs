// HOW-TO: Remove Motion Blur From PNG and Sharpen Edges Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\blurred.png";
            string outputPath = @"C:\Images\processed.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering methods
                RasterImage rasterImage = (RasterImage)image;

                // Apply Motion Wiener filter to reduce motion blur
                var motionOptions = new MotionWienerFilterOptions(size: 10, sigma: 1.0, angle: 90.0);
                rasterImage.Filter(rasterImage.Bounds, motionOptions);

                // Apply Sharpen filter for edge definition
                var sharpenOptions = new SharpenFilterOptions(size: 5, sigma: 4.0);
                rasterImage.Filter(rasterImage.Bounds, sharpenOptions);

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
 * 1. When a web application receives user‑uploaded PNG photos that are blurry due to camera shake, you can use this code to deblur and sharpen them before displaying.
 * 2. If an e‑commerce platform stores product images as PNG and wants to improve visual quality of motion‑blurred shots taken on a conveyor line, the filter sequence restores clarity.
 * 3. For a desktop utility that batch‑processes scanned PNG documents with motion blur, the code automatically reduces blur and enhances edge definition.
 * 4. When preparing PNG assets for a game’s UI where motion blur from screenshots degrades readability, applying the Motion Wiener and Sharpen filters restores crispness.
 * 5. In a scientific imaging workflow that captures PNG frames from a moving microscope slide, the snippet cleans up blur and highlights fine details for analysis.
 */
