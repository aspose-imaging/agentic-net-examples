using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input\\image.png";
        string outputPath = "output\\result.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Prompt user to select algorithm
        Console.WriteLine("Select watermark removal algorithm:");
        Console.WriteLine("1 - Telea (fast)");
        Console.WriteLine("2 - Content Aware Fill (high quality)");
        Console.Write("Enter choice (1 or 2): ");
        string choice = Console.ReadLine();

        // Load the image
        using (var image = Image.Load(inputPath))
        {
            // Cast to specific format (PNG) for demonstration
            var pngImage = (PngImage)image;

            // Create a mask (ellipse shape)
            var mask = new GraphicsPath();
            var figure = new Figure();
            figure.AddShape(new EllipseShape(new RectangleF(350, 170, 570 - 350, 400 - 170)));
            mask.AddFigure(figure);

            // Create appropriate options based on user choice
            WatermarkOptions options;
            if (choice == "2")
            {
                // Content Aware Fill algorithm
                var cafOptions = new ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 4
                };
                options = cafOptions;
            }
            else
            {
                // Default to Telea algorithm
                options = new TeleaWatermarkOptions(mask);
            }

            // Perform watermark removal
            var result = WatermarkRemover.PaintOver(pngImage, options);

            // Save the result
            result.Save(outputPath);
        }
    }
}