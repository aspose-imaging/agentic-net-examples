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
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output/cleaned.png";

            // Validate input file existence
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

                // Define the mask region (ellipse in this example)
                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(350, 170, 570 - 350, 400 - 170)));
                mask.AddFigure(figure);

                // Create Telea watermark options and enable anti‑aliasing via HalfPatchSize
                var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask)
                {
                    HalfPatchSize = 2 // larger half‑patch size gives smoother results
                };

                // Perform watermark removal
                using (var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(pngImage, options))
                {
                    // Save the resulting image as PNG
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