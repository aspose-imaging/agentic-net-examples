// HOW-TO: Apply Semi Transparent Red Overlay to PNG Image Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input/input.png";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage inputImage = (RasterImage)Image.Load(inputPath))
            {
                var path = new GraphicsPath();

                var figure = new Figure();
                var rectShape = new RectangleShape(new RectangleF(0, 0, inputImage.Width, inputImage.Height));
                figure.AddShape(rectShape);
                path.AddFigure(figure);

                using (SolidBrush brush = new SolidBrush(Color.FromArgb(128, 255, 0, 0)))
                {
                    var graphics = new Graphics(inputImage);
                    graphics.FillPath(brush, path);
                }

                var options = new PngOptions();
                inputImage.Save(outputPath, options);
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
 * 1. Use this code to add a semi‑transparent red watermark over a PNG photo for visual warnings or branding.
 * 2. Use it to create a red overlay mask on an image that highlights a selected area in a C# desktop application.
 * 3. Use it to generate a preview image with a red tint that indicates a processing error or invalid data.
 * 4. Use it to overlay a red translucent layer on a map screenshot to emphasize a region in a reporting tool.
 * 5. Use it to batch‑process PNG files, applying a consistent red tint for corporate visual identity across all assets.
 */
