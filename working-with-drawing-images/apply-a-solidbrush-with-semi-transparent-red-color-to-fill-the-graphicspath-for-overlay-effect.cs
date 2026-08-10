// HOW-TO: Apply Semi Transparent Red Overlay to PNG Image Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output\\result.png";

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

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Create a Graphics instance for drawing
                Graphics graphics = new Graphics(image);

                // Build a GraphicsPath covering the whole image
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(0, 0, image.Width, image.Height)));
                path.AddFigure(figure);

                // Create a semi‑transparent red SolidBrush
                using (SolidBrush brush = new SolidBrush(Color.Red))
                {
                    brush.Opacity = 0.5f; // 50% opacity (0 = fully visible, 1 = fully opaque)
                    graphics.FillPath(brush, path);
                }

                // Save the modified image as PNG
                PngOptions saveOptions = new PngOptions();
                image.Save(outputPath, saveOptions);
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
 * 1. When you need to add a semi‑transparent red tint over a PNG to highlight areas for a UI preview.
 * 2. When creating a visual warning overlay on product photos before publishing them on a website.
 * 3. When generating a red‑tinted thumbnail for error reporting in an automated image‑processing pipeline.
 * 4. When applying a colored overlay as a simple watermark without obscuring the original content.
 * 5. When testing color blending effects by programmatically filling an entire image with a partially opaque brush.
 */
