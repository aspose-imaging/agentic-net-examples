// HOW-TO: Apply Manual Polygon Mask to PNG Image Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            using (MemoryStream ms = new MemoryStream())
            {
                // Define manual mask points
                PointF[] points = new PointF[]
                {
                    new PointF(50, 50),
                    new PointF(200, 50),
                    new PointF(200, 200),
                    new PointF(50, 200)
                };

                // Build mask geometry
                PolygonShape polygon = new PolygonShape(points);
                Figure figure = new Figure();
                figure.AddShape(polygon);
                GraphicsPath maskPath = new GraphicsPath();
                maskPath.AddFigure(figure);

                // Masking options
                var maskingOptions = new MaskingOptions
                {
                    Method = SegmentationMethod.Manual,
                    Args = new ManualMaskingArgs { Mask = maskPath },
                    Decompose = false,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new StreamSource(ms)
                    }
                };

                // Apply manual masking
                using (MaskingResult result = new ImageMasking(image).Decompose(maskingOptions))
                using (RasterImage foreground = (RasterImage)result[1].GetImage())
                {
                    foreground.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
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
 * 1. When you need to hide or reveal a specific area of a PNG by defining a custom polygon mask with point coordinates in C#.
 * 2. When you want to programmatically remove background or sensitive parts from product images before uploading them to an e‑commerce site using Aspose.Imaging.
 * 3. When you must generate transparent cut‑outs of scanned documents by manually tracing the region of interest and saving the result as a PNG with alpha channel.
 * 4. When you are building a desktop application that lets users select arbitrary shapes on a map image and export the masked portion as a high‑quality PNG.
 * 5. When you need to automate batch processing of PNG assets where each file requires a predefined manual mask shape for compliance or branding purposes.
 */
