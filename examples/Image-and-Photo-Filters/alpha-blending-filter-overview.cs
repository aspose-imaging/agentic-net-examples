using System;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 3)
        {
            Console.WriteLine("Usage: <backgroundImagePath> <overlayImagePath> <outputImagePath>");
            return;
        }

        string backgroundPath = args[0];
        string overlayPath = args[1];
        string outputPath = args[2];

        using (Aspose.Imaging.RasterImage background = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(backgroundPath))
        {
            using (Aspose.Imaging.RasterImage overlay = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(overlayPath))
            {
                var blendOptions = new ImageBlendingFilterOptions
                {
                    Image = overlay,
                    Opacity = 128, // 50% opacity
                    Position = new Aspose.Imaging.Point(50, 50) // place overlay at (50,50)
                };

                background.Filter(background.Bounds, blendOptions);
            }

            var source = new FileCreateSource(outputPath, false);
            var pngOptions = new PngOptions { Source = source };
            background.Save(outputPath, pngOptions);
        }
    }
}