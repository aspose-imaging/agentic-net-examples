// HOW-TO: Convert PNG to SVG with Color Fill Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.svg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (RasterImage pngImage = (RasterImage)Image.Load(inputPath))
            {
                Image svgImage = Image.Create(new SvgOptions(), pngImage.Width, pngImage.Height);
                Graphics graphics = new Graphics(svgImage);

                using (SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 0, 0)))
                {
                    graphics.FillRectangle(brush, new Rectangle(0, 0, pngImage.Width, pngImage.Height));
                }

                graphics.DrawImage(pngImage, new Point(0, 0));

                svgImage.Save(outputPath);
                svgImage.Dispose();
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
 * 1. When you need to embed a raster PNG into a scalable SVG for web graphics while applying a uniform color overlay.
 * 2. When generating SVG assets from existing PNG logos and want to ensure the background matches brand colors programmatically.
 * 3. When converting product images to vector format for responsive design and need to add a solid fill before saving.
 * 4. When automating batch processing of PNG files to SVG with a custom fill to meet printing specifications.
 * 5. When creating dynamic SVG charts from PNG sources and applying a fill to match a theme in a C# application.
 */
