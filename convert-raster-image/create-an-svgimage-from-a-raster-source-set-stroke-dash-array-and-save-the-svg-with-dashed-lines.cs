// HOW-TO: Create SVG With Dashed Rectangle From PNG In C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "source.png");
            string outputPath = Path.Combine("Output", "result.svg");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width;
            int height;

            using (Image rasterImage = Image.Load(inputPath))
            {
                width = rasterImage.Width;
                height = rasterImage.Height;
            }

            SvgOptions svgOptions = new SvgOptions();

            using (Image svgImage = Image.Create(svgOptions, width, height))
            {
                Graphics graphics = new Graphics(svgImage);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Black);
                pen.Width = 2;
                pen.DashPattern = new float[] { 5, 5 };

                graphics.DrawRectangle(pen, new Rectangle(10, 10, width - 20, height - 20));

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
 * 1. When you need to generate a scalable vector graphic that outlines a raster image with a dashed border for printing or web display.
 * 2. When you want to convert a PNG logo into an SVG file while preserving a custom stroke pattern for consistent styling across devices.
 * 3. When you are building a reporting tool that overlays dashed frames on images and exports them as SVG for resolution‑independent rendering.
 * 4. When you need to programmatically add decorative dashed outlines to thumbnails before embedding them in an HTML5 canvas.
 * 5. When you are automating the creation of SVG assets with specific dash patterns for use in vector‑based UI components or diagrams.
 */
