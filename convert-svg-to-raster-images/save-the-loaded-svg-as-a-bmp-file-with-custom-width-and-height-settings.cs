// HOW-TO: Convert SVG to BMP with Specific Width and Height in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output/output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var rasterizationOptions = new SvgRasterizationOptions
            {
                PageWidth = 800,
                PageHeight = 600
            };

            var bmpOptions = new BmpOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            using (Image image = Image.Load(inputPath))
            {
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
 * 1. When you need to generate a bitmap preview of an SVG logo at a fixed 800×600 size for a Windows desktop application.
 * 2. When you must embed an SVG diagram into a legacy system that only accepts BMP files and requires exact dimensions for layout consistency.
 * 3. When creating thumbnails of vector graphics for email attachments, converting the SVG to a BMP with predetermined width and height to meet size constraints.
 * 4. When preparing assets for a printing workflow that demands BMP format and specific pixel dimensions to match the printer’s resolution settings.
 * 5. When automating batch conversion of SVG icons to BMPs for a game engine that cannot render SVGs and needs each image at a uniform size.
 */
