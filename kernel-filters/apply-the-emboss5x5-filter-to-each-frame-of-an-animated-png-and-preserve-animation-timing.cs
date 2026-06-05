using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (ApngImage sourceApng = (ApngImage)Image.Load(inputPath))
            {
                ApngOptions createOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                using (ApngImage resultApng = (ApngImage)Image.Create(
                    createOptions,
                    sourceApng.Width,
                    sourceApng.Height))
                {
                    int frameCount = sourceApng.PageCount;

                    for (int i = 0; i < frameCount; i++)
                    {
                        ApngFrame srcFrame = (ApngFrame)sourceApng.Pages[i];
                        RasterImage frameImage = (RasterImage)srcFrame;

                        frameImage.Filter(frameImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5));

                        uint frameTime = (uint)srcFrame.FrameTime;
                        resultApng.AddFrame(frameImage, frameTime);
                    }

                    resultApng.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When creating a stylized animated logo for a website, a developer can use this code to emboss each frame of the APNG while keeping the original animation speed.
 * 2. When generating an animated tutorial that highlights texture, a developer can apply the Emboss5x5 filter to every frame of a PNG animation to give a 3‑D effect without altering frame delays.
 * 3. When converting a series of hand‑drawn sketches into an animated PNG for a mobile app, a developer can emboss the drawings frame‑by‑frame to enhance depth while preserving the timing for smooth playback.
 * 4. When preparing an APNG badge for a game UI that needs a subtle relief effect, a developer can run this C# routine to emboss each frame and retain the original frame‑time values.
 * 5. When processing user‑uploaded animated PNG stickers for a messaging platform, a developer can apply the Emboss5x5 convolution filter to each frame to add visual flair while ensuring the sticker animation speed remains unchanged.
 */