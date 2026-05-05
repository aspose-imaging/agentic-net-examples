using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
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

        // Ensure output directory exists (null‑safe)
        string outputDir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrEmpty(outputDir))
            Directory.CreateDirectory(outputDir);

        try
        {
            // Load the source image
            using (var image = Image.Load(inputPath))
            {
                var pngImage = (PngImage)image;

                // Build a mask consisting of multiple ellipses
                var mask = new GraphicsPath();

                var fig1 = new Figure();
                fig1.AddShape(new EllipseShape(new RectangleF(100, 100, 200, 150)));
                mask.AddFigure(fig1);

                var fig2 = new Figure();
                fig2.AddShape(new EllipseShape(new RectangleF(250, 120, 180, 130)));
                mask.AddFigure(fig2);

                var fig3 = new Figure();
                fig3.AddShape(new EllipseShape(new RectangleF(180, 200, 220, 160)));
                mask.AddFigure(fig3);

                // Configure Telea algorithm options with the custom mask
                var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

                // Remove the watermark
                var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(pngImage, options);

                // Save the cleaned image
                result.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}