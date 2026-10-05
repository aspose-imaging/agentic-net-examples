// HOW-TO: Set Custom Hex Background Color When Converting SVG to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.svg";
        string outputPath = "Output/sample.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                using (var pngOptions = new PngOptions())
                {
                    pngOptions.Source = new FileCreateSource(outputPath, false);

                    var rasterOptions = new SvgRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.FromArgb(255, 0x12, 0x34, 0x56)
                    };

                    pngOptions.VectorRasterizationOptions = rasterOptions;

                    image.Save(outputPath, pngOptions);
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
 * 1. When generating product thumbnails from SVG logos and you need the PNG background to use a specific brand hex color.
 * 2. When exporting SVG diagrams to PNG for email attachments and want a consistent dark background defined by a custom hex value.
 * 3. When creating printable PNG assets from vector icons and must ensure the background matches a corporate color palette specified in hex.
 * 4. When processing user‑uploaded SVG files on a web service and need to replace transparent backgrounds with a custom hex color before saving as PNG.
 * 5. When automating batch conversion of SVG charts to PNG for a reporting dashboard that requires a uniform background shade in hex.
 */
