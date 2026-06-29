using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input\\ball.png";
        string outputPath = "output\\result.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            Console.WriteLine("Select watermark removal algorithm:");
            Console.WriteLine("1 - Telea");
            Console.WriteLine("2 - Content Aware Fill");
            Console.Write("Enter choice (1 or 2): ");
            string choice = Console.ReadLine();

            using (var image = Image.Load(inputPath))
            {
                var pngImage = (PngImage)image;

                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(350, 170, 570 - 350, 400 - 170)));
                mask.AddFigure(figure);

                object options;
                if (choice == "2")
                {
                    options = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask)
                    {
                        MaxPaintingAttempts = 4
                    };
                }
                else
                {
                    options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);
                }

                var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(pngImage, (Aspose.Imaging.Watermark.Options.WatermarkOptions)options);
                result.Save(outputPath);
                result.Dispose();
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
 * 1. When a developer needs to integrate a UI that lets users choose between Telea and Content‑Aware Fill algorithms to remove watermarks from PNG files in a C# application.
 * 2. When an image‑processing tool must support interactive selection of a mask shape (e.g., an ellipse) and apply the chosen algorithm to paint over the watermark region.
 * 3. When a batch‑processing service requires configurable watermark removal options, allowing clients to specify the algorithm at runtime for better visual results on different image contents.
 * 4. When a desktop utility must validate the existence of the input image, create the output directory, and then perform watermark removal using Aspose.Imaging’s WatermarkRemover with user‑selected settings.
 * 5. When a developer wants to expose a simple console or graphical interface that captures user input, maps it to TeleaWatermarkOptions or ContentAwareFillWatermarkOptions, and saves the cleaned PNG image.
 */