using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Output file path
        string outputPath = "output.png";

        // Configure PNG creation options
        PngOptions createOptions = new PngOptions
        {
            BitDepth = 8,
            ColorType = PngColorType.TruecolorWithAlpha,
            CompressionLevel = 9,
            FilterType = PngFilterType.Sub,
            Progressive = true
        };

        // Create a PNG image with the specified options
        using (PngImage pngImage = new PngImage(createOptions, 200, 200))
        {
            // Prepare a linear gradient brush (blue to transparent)
            using (LinearGradientBrush brush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(pngImage.Width, pngImage.Height),
                Color.Blue,
                Color.Transparent))
            {
                // Draw the gradient onto the image
                Graphics graphics = new Graphics(pngImage);
                graphics.FillRectangle(brush, pngImage.Bounds);
            }

            // Save the image to the file system
            pngImage.Save(outputPath);
        }

        Console.WriteLine("PNG image saved to " + outputPath);
    }
}