// HOW-TO: Remove Watermark From PNG Using Telea Or Content Aware Fill In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = Image.Load(inputPath))
            {
                var raster = (RasterImage)image;

                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(350, 170, 570 - 350, 400 - 170)));
                mask.AddFigure(figure);

                Console.WriteLine("Select algorithm: 1 - Telea, 2 - Content Aware Fill");
                var choice = Console.ReadLine();

                var options = choice == "2"
                    ? (Aspose.Imaging.Watermark.Options.WatermarkOptions)new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask)
                    : new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

                if (choice == "2")
                {
                    ((Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions)options).MaxPaintingAttempts = 4;
                }

                using (var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, options))
                {
                    result.Save(outputPath);
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
 * 1. When you need to automatically erase a logo or text watermark from a PNG image using a selectable inpainting algorithm in a C# application.
 * 2. When you want to provide a simple console UI that lets users choose between Telea and Content‑Aware Fill for optimal watermark removal.
 * 3. When you have to adjust the maximum painting attempts for the Content‑Aware Fill algorithm to improve the quality of the restored area.
 * 4. When you are processing scanned documents and need to mask a specific region before applying Aspose.Imaging’s WatermarkRemover to restore the background.
 * 5. When you must save the cleaned image to a predefined folder structure after removing the watermark in a .NET workflow.
 */
