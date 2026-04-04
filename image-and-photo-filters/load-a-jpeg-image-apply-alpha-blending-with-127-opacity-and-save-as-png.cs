using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (RasterImage jpegImage = (RasterImage)Image.Load(inputPath))
        {
            Source pngSource = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions { Source = pngSource };

            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, jpegImage.Width, jpegImage.Height))
            {
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.White);

                canvas.Blend(new Point(0, 0), jpegImage, 127);
                canvas.Save();
            }
        }
    }
}