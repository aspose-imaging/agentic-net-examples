using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output\\output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                BmpImage bmpImage = (BmpImage)image;

                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(50, 50, 200, 200)));
                mask.AddFigure(figure);

                var options = new TeleaWatermarkOptions(mask);

                using (RasterImage result = WatermarkRemover.PaintOver(bmpImage, options))
                {
                    result.Save(outputPath, new PngOptions());
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
 * 1. When a medical imaging system receives scanned BMP X‑ray files with patient ID watermarks that must be removed before archiving them as lossless high‑resolution PNGs for diagnostic review.
 * 2. When a manufacturing quality‑control application needs to strip proprietary logo watermarks from BMP photos of circuit boards and store the cleaned images as PNGs for automated defect analysis.
 * 3. When a digital forensics tool processes BMP screenshots containing confidential watermarks and converts the sanitized results to PNG to preserve detail for evidence presentation.
 * 4. When an e‑learning platform imports legacy BMP diagrams with publisher watermarks, removes them, and saves the clean graphics as PNGs for inclusion in modern course materials.
 * 5. When a real‑estate website batch‑processes BMP floor‑plan images that include agency watermarks, cleans them with PaintOver, and outputs high‑resolution PNGs for responsive web display.
 */