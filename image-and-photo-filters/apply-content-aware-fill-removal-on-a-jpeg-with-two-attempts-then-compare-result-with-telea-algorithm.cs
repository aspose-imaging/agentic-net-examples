using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputCafPath = "output/output_caf.jpg";
        string outputTeleaPath = "output/output_telea.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (var image = Image.Load(inputPath))
            {
                var jpegImage = (JpegImage)image;

                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(50, 50, 100, 100)));
                mask.AddFigure(figure);

                var cafOptions = new ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 2
                };
                using (var cafResult = WatermarkRemover.PaintOver(jpegImage, cafOptions))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(outputCafPath));
                    cafResult.Save(outputCafPath);
                }

                var teleaOptions = new TeleaWatermarkOptions(mask);
                using (var teleaResult = WatermarkRemover.PaintOver(jpegImage, teleaOptions))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(outputTeleaPath));
                    teleaResult.Save(outputTeleaPath);
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
 * 1. When a developer needs to automatically erase a circular logo or watermark from a JPEG photo and wants to limit the content‑aware fill to two painting attempts before comparing it with another inpainting method.
 * 2. When an e‑commerce platform must clean product images by removing brand marks using Aspose.Imaging’s ContentAwareFill algorithm with a custom mask and then evaluate the visual quality against the Telea watermark‑removal technique.
 * 3. When a digital archivist wants to restore scanned historical photographs by programmatically painting over unwanted stamps in C# and compare the results of two different watermark‑removal algorithms.
 * 4. When a mobile‑app backend processes user‑uploaded JPEGs and needs to generate two versions—one using content‑aware fill with a maximum of two attempts and another using the Telea algorithm—to decide which approach preserves image detail best.
 * 5. When a developer is building an automated batch job that removes elliptical watermarks from JPEG files, saves the content‑aware fill output and the Telea output to separate folders, and later runs a quality‑assessment step.
 */