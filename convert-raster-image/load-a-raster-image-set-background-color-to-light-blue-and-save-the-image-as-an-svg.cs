// HOW-TO: Convert PNG to SVG with White Background Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output/output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                SvgOptions options = new SvgOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        BackgroundColor = Color.White
                    }
                };
                image.Save(outputPath, options);
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
 * 1. When you need to embed a raster PNG into a web page as scalable SVG while ensuring a solid white background for consistent rendering across browsers.
 * 2. When generating printable graphics from user‑uploaded images, converting them to SVG format with a defined background to avoid transparency issues.
 * 3. When creating vector‑based assets for responsive UI components, you can convert existing PNG icons to SVG with a preset background color using Aspose.Imaging in C#.
 * 4. When automating batch processing of image assets, this code lets you programmatically transform multiple PNG files into SVG files with a uniform background for branding consistency.
 * 5. When integrating image conversion into a .NET service that supplies SVG files to downstream applications, you can load PNGs, set a background, and save them as SVGs with minimal code.
 */
