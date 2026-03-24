using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Brushes;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\output.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure PNG creation options
        PngOptions createOptions = new PngOptions
        {
            BitDepth = 8, // 8 bits per channel
            ColorType = Aspose.Imaging.FileFormats.Png.PngColorType.TruecolorWithAlpha,
            CompressionLevel = 9, // maximum compression
            FilterType = Aspose.Imaging.FileFormats.Png.PngFilterType.Sub,
            Progressive = true
        };

        // Create a 200x200 PNG image with the specified options
        using (PngImage pngImage = new PngImage(createOptions, 200, 200))
        {
            // Create a linear gradient brush from blue to transparent
            LinearGradientBrush gradientBrush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(pngImage.Width, pngImage.Height),
                Color.Blue,
                Color.Transparent);

            // Draw the gradient onto the image
            Graphics graphics = new Graphics(pngImage);
            graphics.FillRectangle(gradientBrush, pngImage.Bounds);

            // Save the image to the hardcoded path
            pngImage.Save(outputPath);
        }
    }
}