// HOW-TO: How to Enable Anti‑Aliasing When Converting SVG to BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "C:\\temp\\input.svg";
            string outputPath = "C:\\temp\\output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (SvgImage svgImage = (SvgImage)Image.Load(inputPath))
            {
                // Configure rasterization options with anti‑aliasing
                SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    SmoothingMode = SmoothingMode.AntiAlias
                };

                // Set BMP save options and attach rasterization options
                BmpOptions bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the rasterized image as BMP
                svgImage.Save(outputPath, bmpOptions);
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
 * 1. When a web application needs to generate high‑quality BMP thumbnails from user‑uploaded SVG logos, enabling anti‑aliasing ensures smooth edges.
 * 2. When exporting vector diagrams to BMP for legacy Windows printing, applying smoothing prevents jagged lines in the printed output.
 * 3. When creating raster assets for a game engine that only accepts BMP files, anti‑aliased conversion maintains the visual fidelity of the original SVG artwork.
 * 4. When batch‑processing SVG icons into BMP format for a desktop UI, using Aspose.Imaging with anti‑aliasing reduces visual artifacts without manual editing.
 * 5. When converting SVG floor plans to BMP for integration with GIS software, enabling smoothing improves the clarity of walls and annotations.
 */
