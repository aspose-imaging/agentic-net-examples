// HOW-TO: Render SVG to PNG with Custom Width and Height in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions();
                rasterOptions.PageWidth = 800;   // custom width
                rasterOptions.PageHeight = 600;  // custom height

                var pngOptions = new PngOptions();
                pngOptions.VectorRasterizationOptions = rasterOptions;

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
 * 1. When you need to generate thumbnail images of vector graphics for a web gallery, you can load an SVG and save it as a PNG with a specific size using Aspose.Imaging in C#.
 * 2. When a reporting system requires raster images of scalable icons at a fixed resolution, this code converts the SVG icons to PNG files with the desired width and height.
 * 3. When preparing assets for mobile apps that only support raster formats, you can rasterize SVG logos into PNGs of exact dimensions to ensure consistent layout.
 * 4. When automating a batch process that converts user‑uploaded SVG files into printable PNGs with preset dimensions, the example shows how to handle file existence checks and directory creation in C#.
 * 5. When integrating vector‑to‑bitmap conversion into a CI pipeline to produce preview images for documentation, this snippet demonstrates using Aspose.Imaging to render SVGs to PNGs with custom page size.
 */
