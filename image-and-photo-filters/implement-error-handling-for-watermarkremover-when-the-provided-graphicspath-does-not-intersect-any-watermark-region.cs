using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input/ball.png";
        string outputPath = "output/result.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the source image
            using (var image = Image.Load(inputPath))
            {
                var pngImage = (PngImage)image;

                // Create a mask that does NOT intersect any watermark region
                var mask = new GraphicsPath();
                var figure = new Figure();
                // Rectangle placed outside the image bounds
                figure.AddShape(new RectangleShape(new RectangleF(-100, -100, 10, 10)));
                mask.AddFigure(figure);

                // Use Telea algorithm options with the empty mask
                var options = new TeleaWatermarkOptions(mask);

                // Attempt watermark removal with error handling for non‑intersecting mask
                try
                {
                    using (var result = WatermarkRemover.PaintOver(pngImage, options))
                    {
                        result.Save(outputPath);
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Watermark removal error: {ex.Message}");
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}