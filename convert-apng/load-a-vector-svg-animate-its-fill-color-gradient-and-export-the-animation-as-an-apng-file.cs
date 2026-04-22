using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.apng";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image svgImg = Image.Load(inputPath))
            {
                SvgImage svgImage = (SvgImage)svgImg;
                int width = svgImage.Width;
                int height = svgImage.Height;

                using (RasterImage canvas = (RasterImage)Image.Create(new BmpOptions(), width, height))
                {
                    Graphics graphics = new Graphics(canvas);
                    graphics.Clear(Color.Transparent);
                    graphics.DrawImage(svgImage, new Point(0, 0));

                    const int animationDuration = 2000; // total duration in ms
                    const int frameDuration = 100; // each frame duration in ms
                    int numFrames = animationDuration / frameDuration;
                    int halfFrames = numFrames / 2;

                    ApngOptions apngOptions = new ApngOptions
                    {
                        Source = new FileCreateSource(outputPath, false),
                        DefaultFrameTime = (uint)frameDuration,
                        ColorType = PngColorType.TruecolorWithAlpha
                    };

                    using (ApngImage apngImage = (ApngImage)Image.Create(apngOptions, width, height))
                    {
                        apngImage.RemoveAllFrames();

                        // first frame
                        apngImage.AddFrame(canvas);

                        // intermediate frames with varying gamma to simulate color gradient
                        for (int i = 1; i < numFrames - 1; i++)
                        {
                            apngImage.AddFrame(canvas);
                            ApngFrame lastFrame = (ApngFrame)apngImage.Pages[apngImage.PageCount - 1];
                            float gamma = i >= halfFrames ? numFrames - i - 1 : i;
                            lastFrame.AdjustGamma(gamma);
                        }

                        // last frame
                        apngImage.AddFrame(canvas);

                        apngImage.Save();
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