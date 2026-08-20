// HOW-TO: Remove Watermark From JPEG Using Content-Aware Fill And Telea In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPathCaf = "output_caf.jpg";
            string outputPathTelea = "output_telea.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPathCaf));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathTelea));

            using (Image image = Image.Load(inputPath))
            {
                JpegImage jpegImage = (JpegImage)image;

                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(50, 50, 200, 200)));
                mask.AddFigure(figure);

                var cafOptions = new ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 2
                };

                using (RasterImage resultCaf = WatermarkRemover.PaintOver(jpegImage, cafOptions))
                {
                    resultCaf.Save(outputPathCaf);
                }

                var teleaOptions = new TeleaWatermarkOptions(mask);

                using (RasterImage resultTelea = WatermarkRemover.PaintOver(jpegImage, teleaOptions))
                {
                    resultTelea.Save(outputPathTelea);
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
 * 1. When you need to automatically erase a logo or watermark from a JPEG image in a C# application using Aspose.Imaging's content‑aware fill with limited painting attempts.
 * 2. When you want to compare the quality of Aspose.Imaging’s Content‑Aware Fill algorithm against the Telea inpainting method on the same masked region.
 * 3. When you are building a batch‑processing tool that removes unwanted objects from photos and saves the cleaned JPEGs to a specific output folder.
 * 4. When you need to programmatically define a custom mask shape (e.g., an ellipse) to target a specific area for removal in image preprocessing pipelines.
 * 5. When you must handle missing input files gracefully and ensure the output directories are created before saving the processed JPEGs.
 */
