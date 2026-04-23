using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string backgroundPath = "background.png";
            string overlayPath = "overlay.png";
            string outputPath = "output.png";

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

            using (Aspose.Imaging.RasterImage background = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(backgroundPath))
            using (Aspose.Imaging.RasterImage overlay = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(overlayPath))
            {
                background.Blend(new Aspose.Imaging.Point(0, 0), overlay, 0);
                Aspose.Imaging.Sources.FileCreateSource src = new Aspose.Imaging.Sources.FileCreateSource(outputPath, false);
                PngOptions options = new PngOptions() { Source = src };
                background.Save(outputPath, options);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}