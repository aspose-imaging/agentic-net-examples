using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Output PNG file path (hard‑coded)
        string outputPath = @"C:\temp\output.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure PNG options
        PngOptions pngOptions = new PngOptions
        {
            // Use truecolor with alpha for full fidelity
            ColorType = Aspose.Imaging.FileFormats.Png.PngColorType.TruecolorWithAlpha,
            // Maximum compression (optional)
            CompressionLevel = 9,
            // Enable progressive loading (optional)
            Progressive = true
        };

        // Create a PNG image with the specified options and size
        using (PngImage pngImage = new PngImage(pngOptions, 200, 200))
        {
            // Create a graphics object for drawing
            Graphics graphics = new Graphics(pngImage);

            // Create a linear gradient brush from blue to transparent
            using (LinearGradientBrush brush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(pngImage.Width, pngImage.Height),
                Color.Blue,
                Color.Transparent))
            {
                // Fill the entire image with the gradient
                graphics.FillRectangle(brush, pngImage.Bounds);
            }

            // Save the image to the specified file using the same options
            pngImage.Save(outputPath, pngOptions);
        }
    }
}