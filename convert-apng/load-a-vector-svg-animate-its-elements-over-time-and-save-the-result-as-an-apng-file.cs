using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Apng;
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

            // Load SVG and rasterize to a raster image (PNG in memory)
            using (Image svgImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions { PageSize = svgImage.Size };
                var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };

                using (MemoryStream ms = new MemoryStream())
                {
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        const int animationDuration = 1000; // total ms
                        const int frameDuration = 100; // ms per frame
                        int totalFrames = animationDuration / frameDuration;

                        var createOptions = new ApngOptions
                        {
                            Source = new FileCreateSource(outputPath, false),
                            DefaultFrameTime = (uint)frameDuration,
                            ColorType = PngColorType.TruecolorWithAlpha
                        };

                        using (ApngImage apng = (ApngImage)Image.Create(createOptions, raster.Width, raster.Height))
                        {
                            apng.RemoveAllFrames();

                            // Add frames with varying gamma to create a simple fade animation
                            for (int i = 0; i < totalFrames; i++)
                            {
                                apng.AddFrame(raster);
                                ApngFrame lastFrame = (ApngFrame)apng.Pages[apng.PageCount - 1];
                                float gamma = (float)i / totalFrames;
                                lastFrame.AdjustGamma(gamma);
                            }

                            apng.Save();
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}