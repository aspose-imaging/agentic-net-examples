// HOW-TO: Create SVG from BMP with Dashed Rectangle Border in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.bmp");
            string outputPath = Path.Combine("Output", "result.svg");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image bmpImage = Image.Load(inputPath))
            {
                int width = bmpImage.Width;
                int height = bmpImage.Height;

                SvgOptions svgOptions = new SvgOptions();

                using (Image svgImage = Image.Create(svgOptions, width, height))
                {
                    Graphics graphics = new Graphics(svgImage);
                    Pen pen = new Pen(Color.Black);
                    pen.DashPattern = new float[] { 5, 2 };
                    graphics.DrawRectangle(pen, new Rectangle(0, 0, width, height));

                    svgImage.Save(outputPath, new SvgOptions());
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
 * 1. When you need to convert a raster BMP file into a scalable SVG and add a custom dashed border for use in web graphics.
 * 2. When generating vector placeholders from bitmap assets for responsive UI designs that require consistent stroke styling.
 * 3. When creating printable diagrams from scanned BMP images and need to overlay a patterned outline to highlight margins.
 * 4. When automating batch processing of legacy BMP icons into SVG icons with uniform dash patterns for a design system.
 * 5. When integrating Aspose.Imaging in a C# application to programmatically draw styled shapes on an SVG canvas derived from an existing bitmap.
 */
