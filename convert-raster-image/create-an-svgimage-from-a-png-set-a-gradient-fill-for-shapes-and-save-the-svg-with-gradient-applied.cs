using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.png";
        string outputPath = "output.svg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (PngImage pngImage = new PngImage(inputPath))
            {
                // Create an SVG graphics context with the same dimensions as the PNG
                int width = pngImage.Width;
                int height = pngImage.Height;
                int dpi = 96;
                SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

                // Draw the PNG onto the SVG canvas
                graphics.DrawImage(pngImage, new Point(0, 0), new Size(width, height));

                // Create a linear gradient brush (red to blue) covering the whole image
                // Note: LinearGradientBrush constructor signature may vary; adjust as needed.
                LinearGradientBrush gradientBrush = new LinearGradientBrush(
                    new PointF(0, 0),
                    new PointF(width, height),
                    Color.Red,
                    Color.Blue);

                // Fill a rectangle with the gradient brush
                Pen outlinePen = new Pen(Color.Black, 1);
                graphics.FillRectangle(outlinePen, gradientBrush, 0, 0, width, height);

                // Finalize SVG image
                using (SvgImage svgImage = graphics.EndRecording())
                {
                    // Save the SVG file
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
 * 1. When a developer needs to convert a raster PNG logo into a scalable SVG for responsive web design while applying a custom linear gradient fill to the entire image.
 * 2. When a C# application must generate vector graphics from user‑uploaded PNGs and overlay a red‑to‑blue gradient rectangle to match brand colors before saving as SVG.
 * 3. When an automated reporting tool has to embed PNG charts into SVG documents and enhance visual appeal by filling the background with a gradient brush.
 * 4. When a desktop utility is required to batch‑process PNG assets, convert them to SVG format, and apply a consistent gradient effect for use in print‑ready PDFs.
 * 5. When a developer wants to programmatically create an SVG file from a PNG source, draw the raster image onto the SVG canvas, and then apply a linear gradient fill to a shape for dynamic theming in a .NET application.
 */