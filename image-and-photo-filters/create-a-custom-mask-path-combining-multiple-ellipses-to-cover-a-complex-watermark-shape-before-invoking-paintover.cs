using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
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

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to PNG image (required for PaintOver)
                PngImage pngImage = (PngImage)image;

                // Create a graphics path mask composed of multiple ellipses
                GraphicsPath mask = new GraphicsPath();

                // First ellipse
                Figure ellipseFigure1 = new Figure();
                ellipseFigure1.AddShape(new EllipseShape(new RectangleF(100, 100, 200, 150)));
                mask.AddFigure(ellipseFigure1);

                // Second ellipse
                Figure ellipseFigure2 = new Figure();
                ellipseFigure2.AddShape(new EllipseShape(new RectangleF(300, 200, 180, 120)));
                mask.AddFigure(ellipseFigure2);

                // Third ellipse (optional, add more for complex shapes)
                Figure ellipseFigure3 = new Figure();
                ellipseFigure3.AddShape(new EllipseShape(new RectangleF(200, 350, 250, 180)));
                mask.AddFigure(ellipseFigure3);

                // Configure watermark removal options
                var options = new ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 4
                };

                // Perform the paint-over operation
                using (Image result = WatermarkRemover.PaintOver(pngImage, options))
                {
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