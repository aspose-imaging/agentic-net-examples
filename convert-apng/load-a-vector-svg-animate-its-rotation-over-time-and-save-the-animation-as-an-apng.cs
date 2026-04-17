using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Apng;
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

        int width;
        int height;
        using (Image temp = Image.Load(inputPath))
        {
            width = temp.Width;
            height = temp.Height;
        }

        const int totalDurationMs = 2000;
        const int frameDurationMs = 100;
        int frameCount = totalDurationMs / frameDurationMs;
        float angleStep = 360f / frameCount;

        ApngOptions apngOptions = new ApngOptions
        {
            Source = new FileCreateSource(outputPath, false),
            DefaultFrameTime = (uint)frameDurationMs,
            ColorType = PngColorType.TruecolorWithAlpha
        };

        using (ApngImage apngImage = (ApngImage)Image.Create(apngOptions, width, height))
        {
            apngImage.RemoveAllFrames();

            for (int i = 0; i < frameCount; i++)
            {
                float angle = i * angleStep;

                using (Image svg = Image.Load(inputPath))
                using (MemoryStream ms = new MemoryStream())
                {
                    svg.Save(ms, new PngOptions());
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        if (!raster.IsCached) raster.CacheData();
                        raster.Rotate(angle, true, Color.White);
                        apngImage.AddFrame(raster);
                    }
                }
            }

            apngImage.Save();
        }
    }
}