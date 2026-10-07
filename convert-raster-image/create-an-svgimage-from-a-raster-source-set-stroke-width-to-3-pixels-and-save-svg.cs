// HOW-TO: Create SVG From JPEG With 3‑Pixel Border Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "input/input.jpg";
            string outputPath = "output/output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                int width = raster.Width;
                int height = raster.Height;

                using (Image svgImage = Image.Create(new SvgOptions(), width, height))
                {
                    Graphics graphics = new Graphics(svgImage);
                    graphics.DrawImage(raster, new Point(0, 0));

                    Pen pen = new Pen(Color.Black, 3);
                    graphics.DrawRectangle(pen, new Rectangle(0, 0, width, height));

                    svgImage.Save(outputPath);
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
 * 1. When you need to convert a JPEG photo into a scalable SVG for responsive web design while adding a uniform 3‑pixel black outline.
 * 2. When generating vector graphics from raster scans for printing and you want a consistent border thickness around the image.
 * 3. When creating thumbnails in SVG format that retain the original dimensions and include a visible frame for UI components.
 * 4. When automating batch processing of raster assets to SVG with a predefined stroke width for brand‑consistent styling.
 * 5. When integrating Aspose.Imaging in a C# application to overlay a rectangular border on converted SVG files for diagram annotations.
 */
