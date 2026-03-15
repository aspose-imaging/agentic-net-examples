using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.apng";
        string outputPath = "output.apng";

        Color blendColor = Color.FromArgb(255, 255, 0, 0);
        byte opacity = 128;

        using (ApngImage apng = (ApngImage)Image.Load(inputPath))
        {
            string overlayTempPath = "overlay_temp.png";
            using (RasterImage overlay = (RasterImage)Image.Create(
                new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(overlayTempPath, false)
                },
                apng.Width,
                apng.Height))
            {
                Graphics graphics = new Graphics(overlay);
                graphics.Clear(blendColor);

                var blendOptions = new ImageBlendingFilterOptions
                {
                    Image = overlay,
                    Opacity = opacity,
                    Position = new Point(0, 0)
                };

                apng.Filter(apng.Bounds, blendOptions);
            }

            apng.Save(outputPath, new ApngOptions());

            if (File.Exists(overlayTempPath))
                File.Delete(overlayTempPath);
        }
    }
}