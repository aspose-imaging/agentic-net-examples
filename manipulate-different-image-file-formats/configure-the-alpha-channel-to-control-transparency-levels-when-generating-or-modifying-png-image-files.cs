using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png"; // Not used in this example but kept per requirement
        string outputPath = "output.png";

        // Verify input file existence (if needed)
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure PNG options with alpha channel support
        PngOptions pngOptions = new PngOptions
        {
            ColorType = PngColorType.TruecolorWithAlpha,
            BitDepth = 8,
            // Bind the output file to the options
            Source = new FileCreateSource(outputPath, false)
        };

        // Create a PNG image canvas (bound to the output file)
        using (PngImage pngImage = new PngImage(pngOptions, 400, 200))
        {
            // Create a linear gradient brush from opaque red to fully transparent
            using (LinearGradientBrush gradientBrush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(pngImage.Width, pngImage.Height),
                Color.Red,
                Color.Transparent))
            {
                // Draw the gradient onto the canvas
                Graphics graphics = new Graphics(pngImage);
                graphics.FillRectangle(gradientBrush, pngImage.Bounds);
            }

            // Save the image (output is already bound via FileCreateSource)
            pngImage.Save();
        }
    }
}