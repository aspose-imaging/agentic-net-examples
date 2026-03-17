using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Brushes;

public class Program
{
    public static void Main(string[] args)
    {
        // Output file path
        string outputPath = "output.png";

        // Configure PNG options, including the desired bit depth
        PngOptions pngOptions = new PngOptions();
        pngOptions.BitDepth = 8; // Valid values: 1, 2, 4, 8, 16 (depending on ColorType)
        pngOptions.ColorType = PngColorType.TruecolorWithAlpha;
        pngOptions.CompressionLevel = 9;
        pngOptions.Progressive = true;

        // Create a PNG image with the specified options
        using (PngImage pngImage = new PngImage(pngOptions, 200, 200))
        {
            // Fill the image with a gradient
            LinearGradientBrush brush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(pngImage.Width, pngImage.Height),
                Color.Blue,
                Color.Transparent);

            Graphics graphics = new Graphics(pngImage);
            graphics.FillRectangle(brush, pngImage.Bounds);

            // Save the image; the BitDepth setting is applied during save
            pngImage.Save(outputPath);
        }
    }
}