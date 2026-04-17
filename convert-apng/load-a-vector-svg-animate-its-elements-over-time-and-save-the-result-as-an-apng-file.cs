using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        string inputPath = "input.svg";
        string outputPath = "output.apng";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image svgImage = Image.Load(inputPath))
        {
            SvgImage svg = (SvgImage)svgImage;
            int width = svg.Width;
            int height = svg.Height;

            using (MemoryStream rasterStream = new MemoryStream())
            {
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svg.Size
                };
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };
                svg.Save(rasterStream, pngOptions);
                rasterStream.Position = 0;

                using (RasterImage baseFrame = (RasterImage)Image.Load(rasterStream))
                {
                    const int animationDurationMs = 1000;
                    const int frameDurationMs = 100;
                    int frameCount = animationDurationMs / frameDurationMs;

                    ApngOptions apngOptions = new ApngOptions
                    {
                        Source = new FileCreateSource(outputPath, false),
                        DefaultFrameTime = (uint)frameDurationMs,
                        ColorType = PngColorType.TruecolorWithAlpha
                    };

                    using (ApngImage apng = (ApngImage)Image.Create(apngOptions, width, height))
                    {
                        apng.RemoveAllFrames();

                        for (int i = 0; i < frameCount; i++)
                        {
                            apng.AddFrame(baseFrame);
                        }

                        apng.Save();
                    }
                }
            }
        }
    }
}