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
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            const int animationDuration = 1000; // total duration in ms
            const int frameDuration = 100; // duration per frame in ms
            int numFrames = animationDuration / frameDuration;

            ApngOptions apngOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = (uint)frameDuration,
                ColorType = PngColorType.TruecolorWithAlpha
            };

            using (ApngImage apngImage = (ApngImage)Image.Create(apngOptions, 0, 0))
            {
                apngImage.RemoveAllFrames();

                for (int i = 0; i < numFrames; i++)
                {
                    float angle = 360f * i / numFrames;

                    using (Image vectorImage = Image.Load(inputPath))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            PngOptions pngOptions = new PngOptions
                            {
                                VectorRasterizationOptions = new SvgRasterizationOptions { PageSize = vectorImage.Size }
                            };
                            vectorImage.Save(ms, pngOptions);
                            ms.Position = 0;

                            using (RasterImage rasterFrame = (RasterImage)Image.Load(ms))
                            {
                                rasterFrame.Rotate(angle, true, Color.Transparent);
                                apngImage.AddFrame(rasterFrame);
                            }
                        }
                    }
                }

                apngImage.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}