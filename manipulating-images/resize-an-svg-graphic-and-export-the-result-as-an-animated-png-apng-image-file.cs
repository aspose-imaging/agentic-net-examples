using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputSvgPath = "input.svg";
        string outputApngPath = "output.apng";

        int targetWidth = 400;
        int targetHeight = 300;

        using (Image svgImage = Image.Load(inputSvgPath))
        {
            svgImage.Resize(targetWidth, targetHeight);

            using (MemoryStream pngStream = new MemoryStream())
            {
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size
                    }
                };
                svgImage.Save(pngStream, pngOptions);
                pngStream.Position = 0;

                using (RasterImage raster = (RasterImage)Image.Load(pngStream))
                {
                    ApngOptions apngOptions = new ApngOptions
                    {
                        Source = new FileCreateSource(outputApngPath, false),
                        DefaultFrameTime = 500,
                        ColorType = PngColorType.TruecolorWithAlpha
                    };

                    using (ApngImage apng = (ApngImage)Image.Create(apngOptions, raster.Width, raster.Height))
                    {
                        apng.RemoveAllFrames();

                        int frameCount = 5;
                        for (int i = 0; i < frameCount; i++)
                        {
                            apng.AddFrame(raster);
                        }

                        apng.Save();
                    }
                }
            }
        }
    }
}