using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        const int animationDuration = 1000; // milliseconds
        const int frameDuration = 100; // milliseconds per frame
        int numFrames = animationDuration / frameDuration;

        using (Image vectorImage = Image.Load(inputPath))
        {
            int width = vectorImage.Width;
            int height = vectorImage.Height;

            ApngOptions apngCreateOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = (uint)frameDuration,
                ColorType = PngColorType.TruecolorWithAlpha
            };

            using (ApngImage apngImage = (ApngImage)Image.Create(apngCreateOptions, width, height))
            {
                apngImage.RemoveAllFrames();

                for (int i = 0; i < numFrames; i++)
                {
                    float angle = i * 360f / numFrames;

                    using (MemoryStream ms = new MemoryStream())
                    {
                        PngOptions pngOptions = new PngOptions
                        {
                            VectorRasterizationOptions = new SvgRasterizationOptions { PageSize = vectorImage.Size }
                        };
                        vectorImage.Save(ms, pngOptions);
                        ms.Position = 0;

                        using (RasterImage frameRaster = (RasterImage)Image.Load(ms))
                        {
                            frameRaster.Rotate(angle, true, Color.Transparent);
                            apngImage.AddFrame(frameRaster);
                        }
                    }
                }

                apngImage.Save();
            }
        }
    }
}