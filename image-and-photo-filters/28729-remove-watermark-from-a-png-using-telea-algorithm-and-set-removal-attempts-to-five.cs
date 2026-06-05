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
        // Hardcoded input and output file paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (var image = Image.Load(inputPath))
            {
                var pngImage = (PngImage)image;

                // Define the mask area using a graphics path
                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(350, 170, 570 - 350, 400 - 170)));
                mask.AddFigure(figure);

                // Create Telea algorithm options
                var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

                // Perform watermark removal
                var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(pngImage, options);

                // Save the resulting image
                result.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}