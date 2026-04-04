using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string backgroundPath = "input/background.png";
        string overlayPath = "input/overlay.png";
        string outputPath = "output/result.png";

        if (!File.Exists(backgroundPath))
        {
            Console.Error.WriteLine($"File not found: {backgroundPath}");
            return;
        }
        if (!File.Exists(overlayPath))
        {
            Console.Error.WriteLine($"File not found: {overlayPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        Source outputSource = new FileCreateSource(outputPath, false);
        PngOptions pngOptions = new PngOptions() { Source = outputSource };

        using (RasterImage background = (RasterImage)Image.Load(backgroundPath))
        using (RasterImage overlay = (RasterImage)Image.Load(overlayPath))
        {
            background.Blend(new Point(0, 0), overlay, 0);
            background.Save(outputPath, pngOptions);
        }
    }
}