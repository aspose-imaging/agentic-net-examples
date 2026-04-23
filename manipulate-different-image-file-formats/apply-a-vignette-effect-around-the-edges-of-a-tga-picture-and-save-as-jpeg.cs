using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tga;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tga";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TgaImage image = (TgaImage)Image.Load(inputPath))
            {
                // Apply a simple vignette effect using a linear gradient brush
                Graphics graphics = new Graphics(image);
                var rect = image.Bounds;
                var brush = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(image.Width, image.Height),
                    Color.Transparent,
                    Color.Black);
                graphics.FillRectangle(brush, rect);

                // Save the result as JPEG
                var jpegOptions = new JpegOptions();
                image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}