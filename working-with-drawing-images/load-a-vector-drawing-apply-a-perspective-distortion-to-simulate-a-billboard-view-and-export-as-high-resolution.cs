// HOW-TO: Convert SVG To High‑Resolution PNG At 300 DPI Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output.png";

            // Validate input file existence
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
                // Configure rasterization options for high‑resolution output
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Set PNG export options with desired DPI (e.g., 300)
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    ResolutionSettings = new ResolutionSetting(300, 300)
                };

                // NOTE: Perspective distortion is not directly supported by Aspose.Imaging API.
                // If needed, additional processing (e.g., custom transformation) should be applied here.

                // Save as high‑resolution PNG
                image.Save(outputPath, pngOptions);
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
 * 1. When you need to generate print‑ready PNG assets from SVG logos at 300 DPI for marketing materials.
 * 2. When an application must display vector icons as high‑resolution raster images on high‑DPI screens.
 * 3. When a server‑side service converts user‑uploaded SVG diagrams into PNG thumbnails for web previews.
 * 4. When preparing artwork for large‑format displays such as billboards, requiring a high‑resolution PNG export.
 * 5. When automating batch processing of SVG files into PNGs with consistent resolution settings in a C# workflow.
 */
