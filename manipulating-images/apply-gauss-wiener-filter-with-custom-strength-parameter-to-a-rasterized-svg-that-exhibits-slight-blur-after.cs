// HOW-TO: Apply Custom Gauss Wiener Filter to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
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
            string inputPath = @"C:\Images\input.svg";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                using (RasterImage rasterImage = (RasterImage)image)
                {
                    // Custom Gauss‑Wiener filter parameters
                    int size = 5;          // kernel size (must be odd)
                    double sigma = 4.0;    // smoothing sigma (positive)

                    // Apply the filter to the whole image
                    rasterImage.Filter(rasterImage.Bounds, new GaussWienerFilterOptions(size, sigma));

                    // Save the processed image
                    rasterImage.Save(outputPath);
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
 * 1. When you need to remove slight blur from an SVG after rasterizing it to a high‑resolution PNG for web publishing.
 * 2. When you want to programmatically enhance scanned vector graphics by applying a custom‑strength Gauss‑Wiener filter in a C# batch process.
 * 3. When you must ensure consistent image quality across a folder of SVG icons before embedding them in a mobile app.
 * 4. When you are building an automated pipeline that converts user‑uploaded SVG logos to sharpened PNG thumbnails using Aspose.Imaging.
 * 5. When you require fine‑tuned noise reduction on vector‑derived images to meet print‑ready specifications without manual editing.
 */
