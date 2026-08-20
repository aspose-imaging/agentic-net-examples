// HOW-TO: Convert PNG to SVG with Light Blue Background in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.svg";

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

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare SVG save options
                var svgOptions = new SvgOptions();

                // Configure rasterization options with a light‑blue background
                var rasterOptions = new SvgRasterizationOptions
                {
                    BackgroundColor = Color.FromArgb(255, 173, 216, 230), // LightBlue
                    PageSize = image.Size
                };

                svgOptions.VectorRasterizationOptions = rasterOptions;

                // Save as SVG
                image.Save(outputPath, svgOptions);
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
 * 1. When you need to embed a PNG logo into a web page as scalable SVG while ensuring a consistent light‑blue canvas behind it.
 * 2. When generating vector graphics from user‑uploaded raster photos for print layouts and you want a uniform background color.
 * 3. When converting product thumbnails to SVG for responsive UI designs and need to replace transparent areas with a light‑blue fill.
 * 4. When automating batch processing of scanned images to SVG format and require a specific background to match corporate branding.
 * 5. When creating SVG assets from raster icons for mobile apps and must set a light‑blue background to improve visibility on dark themes.
 */
