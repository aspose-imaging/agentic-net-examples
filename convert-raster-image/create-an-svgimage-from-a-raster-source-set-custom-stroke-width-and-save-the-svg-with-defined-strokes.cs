// HOW-TO: Create SVG from PNG with Custom Stroke Width in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                int width = raster.Width;
                int height = raster.Height;

                SvgOptions svgOptions = new SvgOptions();

                using (Image svgImage = Image.Create(svgOptions, width, height))
                {
                    Graphics graphics = new Graphics(svgImage);
                    graphics.Clear(Color.White);
                    graphics.DrawImage(raster, new Point(0, 0));

                    Pen pen = new Pen(Color.Black);
                    pen.Width = 5;
                    graphics.DrawRectangle(pen, 0, 0, width - 1, height - 1);

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
 * 1. When you need to embed a PNG raster image into an SVG and draw a thick black border around it for web graphics.
 * 2. When you want to convert user‑uploaded screenshots to scalable SVG files while adding a uniform stroke for documentation purposes.
 * 3. When you must generate vector placeholders for bitmap logos, applying a 5‑pixel outline to keep the design resolution‑independent.
 * 4. When an automated batch process adds a consistent border to icons before saving them as SVG for a UI component library.
 * 5. When you are preparing printable assets that require a raster image inside an SVG with a defined stroke to meet branding guidelines.
 */
