using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        Source source = new FileCreateSource(outputPath, false);
        PngOptions options = new PngOptions() { Source = source };

        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);
            image.Save(outputPath, options);
        }
    }
}