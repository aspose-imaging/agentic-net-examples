using System;
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
        string inputPath = args.Length > 0 ? args[0] : "input_image.png";
        string outputPath = args.Length > 1 ? args[1] : "output_animation.apng";

        using (Image sourceImage = Image.Load(inputPath))
        {
            ApngOptions apngOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 100,
                ColorType = PngColorType.TruecolorWithAlpha
            };

            using (ApngImage apng = (ApngImage)Image.Create(apngOptions, sourceImage.Width, sourceImage.Height))
            {
                apng.RemoveAllFrames();

                if (sourceImage is IMultipageImage multipage)
                {
                    foreach (Image page in multipage.Pages)
                    {
                        RasterImage raster = (RasterImage)page;
                        var blurOptions = new GaussianBlurFilterOptions { Radius = 5 };
                        raster.Filter(raster.Bounds, blurOptions);
                        apng.AddFrame(raster);
                    }
                }
                else
                {
                    RasterImage raster = (RasterImage)sourceImage;
                    var blurOptions = new GaussianBlurFilterOptions { Radius = 5 };
                    raster.Filter(raster.Bounds, blurOptions);
                    apng.AddFrame(raster);
                }

                apng.Save();
            }
        }
    }
}