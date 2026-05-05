using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = "InputImages";
            string outputDirectory = "OutputImages";

            // Get all PNG files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in files)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Prepare output path
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + "_clean.png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to PNG image type
                    PngImage pngImage = (PngImage)image;

                    // Define a reusable ellipse mask
                    var mask = new GraphicsPath();
                    var figure = new Figure();
                    // Example ellipse parameters (x, y, width, height)
                    figure.AddShape(new EllipseShape(new RectangleF(50, 50, 200, 150)));
                    mask.AddFigure(figure);

                    // Configure Telea watermark removal options
                    var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

                    // Apply the watermark removal (object removal) algorithm
                    var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(pngImage, options);

                    // Save the processed image
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