using System;
using System.Diagnostics;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

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
            // Cast to specific raster image type
            PngImage pngImage = (PngImage)image;

            // Create a mask (example ellipse)
            GraphicsPath mask = new GraphicsPath();
            Figure figure = new Figure();
            // Adjust rectangle as needed for the area to remove
            figure.AddShape(new EllipseShape(new RectangleF(350, 170, 570 - 350, 400 - 170)));
            mask.AddFigure(figure);

            // Define processing time limit (e.g., 5 seconds)
            TimeSpan timeLimit = TimeSpan.FromSeconds(5);

            // First attempt with Content Aware Fill
            ContentAwareFillWatermarkOptions cafOptions = new ContentAwareFillWatermarkOptions(mask)
            {
                MaxPaintingAttempts = 4
            };

            Stopwatch sw = Stopwatch.StartNew();
            Image result = WatermarkRemover.PaintOver(pngImage, cafOptions);
            sw.Stop();

            // If processing exceeds the limit, fallback to Telea algorithm
            if (sw.Elapsed > timeLimit)
            {
                // Dispose previous result if needed
                result.Dispose();

                TeleaWatermarkOptions teleaOptions = new TeleaWatermarkOptions(mask);
                result = WatermarkRemover.PaintOver(pngImage, teleaOptions);
            }

            // Save the resulting image
            result.Save(outputPath);
            result.Dispose();
        }
    }
}