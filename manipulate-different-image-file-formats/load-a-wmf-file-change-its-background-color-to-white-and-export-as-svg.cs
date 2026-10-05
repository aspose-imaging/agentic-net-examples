// HOW-TO: Convert WMF to SVG with White Background Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.wmf";
        string outputPath = "output/output.svg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };

                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

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
 * 1. When you need to embed a legacy WMF diagram into a web page that only supports SVG, you can convert it while forcing a white background to match the page design.
 * 2. When generating printable reports that require vector graphics, converting WMF charts to SVG ensures scalability and a consistent white canvas across different browsers.
 * 3. When automating a batch process that cleans up old WMF assets, you can use this code to replace transparent or colored backgrounds with white before saving them as SVG files.
 * 4. When integrating with a design workflow that expects SVG input, this snippet lets you programmatically transform WMF icons to SVG with a uniform background color using Aspose.Imaging for .NET.
 * 5. When creating an SVG export feature in a C# application, you can load any WMF file, set the background to white, and save it as SVG to guarantee proper rendering on platforms that ignore WMF transparency.
 */
