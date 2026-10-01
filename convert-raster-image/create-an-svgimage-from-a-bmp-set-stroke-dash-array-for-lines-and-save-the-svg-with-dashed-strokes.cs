// HOW-TO: Create SVG from BMP with Dashed Line Stroke in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\image.bmp";
            string outputPath = "Output\\image.svg";

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
                svgOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    PageWidth = width,
                    PageHeight = height,
                    BackgroundColor = Color.White
                };

                using (Image svgImage = Image.Create(svgOptions, width, height))
                {
                    Graphics graphics = new Graphics(svgImage);
                    Pen pen = new Pen(Color.Black);
                    pen.DashPattern = new float[] { 5, 5 };
                    graphics.DrawLine(pen, new Point(0, 0), new Point(width, height));

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
 * 1. When you need to convert a bitmap diagram into a scalable SVG for web display while adding a custom dashed border line.
 * 2. When generating vector graphics from legacy BMP assets and you want to highlight edges with a patterned stroke using Aspose.Imaging in a C# application.
 * 3. When creating printable diagrams where the source image is a BMP but the final output must be an SVG with stylized dashed lines for better visual emphasis.
 * 4. When automating a workflow that transforms scanned BMP images into SVG files and programmatically applies dash patterns to lines for diagram annotations.
 * 5. When developing a C# tool that extracts dimensions from a BMP, creates an SVG canvas of the same size, and draws custom dashed lines for UI overlays or reporting.
 */
