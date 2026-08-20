// HOW-TO: Sharpen PNG Image With 5x5 Filter While Preserving Brightness In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output\\sharpened.png";

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

            // Load the image and apply Sharpen5x5 filter
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;
                // Sharpen filter with kernel size 5 and sigma 4.0 (preserves original brightness)
                rasterImage.Filter(rasterImage.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));
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
 * 1. When a web application needs to enhance scanned drawings in PNG format without altering their original lighting, developers can use this code to apply a 5x5 sharpen filter while keeping brightness consistent.
 * 2. When preparing product manuals, a developer may want to improve the clarity of line art before embedding it in PDFs, using Aspose.Imaging to sharpen the PNG images without over‑exposing them.
 * 3. When building an automated batch‑processing tool that receives user‑uploaded PNG sketches, this snippet can quickly sharpen each image while preserving its visual tone for downstream analysis.
 * 4. When integrating image enhancement into a C# desktop utility that cleans up old architectural drawings, the code provides a simple way to apply a 5x5 sharpen filter and save the result to a designated folder.
 * 5. When creating a CI pipeline that validates visual assets, developers can use this example to programmatically sharpen PNG assets and verify that brightness remains unchanged before publishing.
 */
