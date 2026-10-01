// HOW-TO: Convert BMP To SVG With Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\image.bmp";
            string outputPath = "Output\\image.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage bmp = (RasterImage)Image.Load(inputPath))
            {
                int width = bmp.Width;
                int height = bmp.Height;

                SvgGraphics2D svgGraphics = new SvgGraphics2D(width, height, 96);
                svgGraphics.DrawImage(bmp, new Point(0, 0));

                SvgImage svgImage = svgGraphics.EndRecording();
                svgImage.Save(outputPath);
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
 * 1. When you need to embed a legacy BMP asset into a web page as a scalable SVG without losing quality, you can use this code to convert the bitmap to vector format in C#.
 * 2. When an application must generate printable graphics that scale on high‑resolution devices, converting BMP images to SVG ensures resolution‑independent output using Aspose.Imaging.
 * 3. When a batch‑processing service has to transform a folder of BMP icons into SVG files for modern UI frameworks, this snippet provides the core conversion logic.
 * 4. When you want to programmatically create SVG placeholders from raster screenshots for further vector editing or annotation in a .NET workflow, the code demonstrates how to record and save the SVG.
 * 5. When integrating image conversion into a CI/CD pipeline to replace outdated BMP resources with lightweight SVGs for faster page loads, this example shows the required C# steps.
 */
