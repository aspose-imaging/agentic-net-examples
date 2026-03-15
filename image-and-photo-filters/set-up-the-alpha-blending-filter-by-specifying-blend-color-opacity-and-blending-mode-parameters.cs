using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string backgroundPath = "background.jpg";
        string overlayPath = "overlay.png";
        string outputPath = "blended.png";

        using (RasterImage background = (RasterImage)Image.Load(backgroundPath))
        using (RasterImage overlay = (RasterImage)Image.Load(overlayPath))
        {
            var blendOptions = new ImageBlendingFilterOptions
            {
                Image = overlay,
                Opacity = 0.5f,
                Position = new Point(100, 100),
                BlendingMode = BlendingMode.Multiply
            };

            background.Filter(background.Bounds, blendOptions);

            var pngOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };
            background.Save(outputPath, pngOptions);
        }
    }
}