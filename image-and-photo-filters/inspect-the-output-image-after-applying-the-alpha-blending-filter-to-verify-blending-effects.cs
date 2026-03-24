using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        string baseImagePath = "input/base.png";
        string overlayImagePath = "input/overlay.png";
        string outputPath = "output/blended.png";

        if (!File.Exists(baseImagePath))
        {
            Console.Error.WriteLine($"File not found: {baseImagePath}");
            return;
        }
        if (!File.Exists(overlayImagePath))
        {
            Console.Error.WriteLine($"File not found: {overlayImagePath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Aspose.Imaging.RasterImage baseImage = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(baseImagePath))
        using (Aspose.Imaging.RasterImage overlayImage = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(overlayImagePath))
        {
            var blendingOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ImageBlendingFilterOptions
            {
                Image = overlayImage,
                Opacity = 0.5f,
                Position = new Aspose.Imaging.Point(0, 0)
            };
            baseImage.Filter(baseImage.Bounds, blendingOptions);

            var outputSource = new FileCreateSource(outputPath, false);
            var pngOptions = new PngOptions { Source = outputSource };
            baseImage.Save(outputPath, pngOptions);
        }

        using (Aspose.Imaging.RasterImage resultImage = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(outputPath))
        {
            int argb = resultImage.GetArgb32Pixel(0, 0);
            Console.WriteLine($"Top-left pixel ARGB after blending: 0x{argb:X8}");
        }
    }
}