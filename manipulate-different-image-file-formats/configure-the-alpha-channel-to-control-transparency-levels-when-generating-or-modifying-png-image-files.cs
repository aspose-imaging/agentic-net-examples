using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = Path.Combine(Environment.CurrentDirectory, "alpha_gradient.png");

        PngOptions pngOptions = new PngOptions
        {
            ColorType = PngColorType.TruecolorWithAlpha,
            BitDepth = 8,
            Source = new FileCreateSource(outputPath, false)
        };

        int width = 400;
        int height = 400;

        using (PngImage pngImage = (PngImage)Image.Create(pngOptions, width, height))
        {
            LinearGradientBrush gradientBrush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(width, height),
                Color.FromArgb(0, 0, 0, 255),
                Color.FromArgb(255, 0, 0, 255)
            );

            Graphics graphics = new Graphics(pngImage);
            graphics.FillRectangle(gradientBrush, pngImage.Bounds);
            pngImage.Save();
        }

        Console.WriteLine($"PNG image with alpha gradient saved to: {outputPath}");
    }
}