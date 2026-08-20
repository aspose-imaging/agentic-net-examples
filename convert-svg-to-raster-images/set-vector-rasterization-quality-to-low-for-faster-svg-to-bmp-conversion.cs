// HOW-TO: Convert SVG to BMP with Low Quality Rasterization in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.svg";
        string outputPath = @"C:\temp\output.bmp";

        // Ensure any runtime exception is reported cleanly
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

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options for low quality (no smoothing)
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size,
                    SmoothingMode = Aspose.Imaging.SmoothingMode.None
                };

                // Set up BMP save options and attach rasterization options
                var bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the rasterized BMP image
                image.Save(outputPath, bmpOptions);
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
 * 1. When you need to quickly generate thumbnail BMP images from SVG icons for a web dashboard without preserving fine details.
 * 2. When a server‑side C# application must batch‑convert large numbers of SVG diagrams to BMP format while minimizing CPU usage.
 * 3. When you are building a reporting tool that embeds BMP snapshots of vector graphics and prefer faster rendering over high‑resolution quality.
 * 4. When you want to reduce memory consumption during SVG to BMP conversion in a low‑power device or cloud function.
 * 5. When you need to create low‑quality BMP previews of SVG files for preview panes in a Windows desktop application.
 */
