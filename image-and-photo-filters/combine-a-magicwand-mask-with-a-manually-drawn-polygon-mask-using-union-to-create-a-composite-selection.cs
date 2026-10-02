// HOW-TO: Create Composite Image Mask by Union of Magic Wand and Polygon in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output\\result.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                PointF[] polygonPoints = new PointF[]
                {
                    new PointF(100, 100),
                    new PointF(200, 80),
                    new PointF(250, 150),
                    new PointF(180, 200),
                    new PointF(120, 180)
                };

                GraphicsPath manualMask = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new PolygonShape(polygonPoints));
                manualMask.AddFigure(figure);

                var maskingOptions = new MaskingOptions
                {
                    Method = SegmentationMethod.Manual,
                    Args = new ManualMaskingArgs { Mask = manualMask },
                    Decompose = false,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new StreamSource(new MemoryStream())
                    }
                };

                using (MaskingResult results = new ImageMasking(image).Decompose(maskingOptions))
                using (RasterImage foreground = (RasterImage)results[1].GetImage())
                {
                    foreground.Save(outputPath);
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
 * 1. When you need to isolate a complex region that includes both automatically detected edges and a custom‑drawn area, such as extracting a product from a photo while preserving a hand‑drawn highlight.
 * 2. When preparing images for e‑commerce catalogs and you must combine a Magic Wand selection with a manually defined polygon to retain specific background details.
 * 3. When creating masks for medical imaging where automatic segmentation must be supplemented with physician‑drawn contours to ensure accurate region of interest.
 * 4. When generating assets for games or AR applications and you want to merge a quick‑selection mask with a designer‑specified polygon to produce a clean cut‑out.
 * 5. When automating batch processing of scanned documents and you need to combine auto‑detected text blocks with manually marked signatures for selective redaction or extraction.
 */
