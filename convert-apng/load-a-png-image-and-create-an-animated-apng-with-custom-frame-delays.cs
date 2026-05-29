using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output_animation.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                int[] frameDelays = { 100, 200, 300, 400 };

                ApngOptions createOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = (uint)frameDelays[0],
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                using (ApngImage apngImage = (ApngImage)Image.Create(
                    createOptions,
                    sourceImage.Width,
                    sourceImage.Height))
                {
                    apngImage.RemoveAllFrames();

                    foreach (int delay in frameDelays)
                    {
                        apngImage.AddFrame(sourceImage);
                        ApngFrame lastFrame = (ApngFrame)apngImage.Pages[apngImage.PageCount - 1];
                        lastFrame.FrameTime = delay;
                    }

                    apngImage.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}