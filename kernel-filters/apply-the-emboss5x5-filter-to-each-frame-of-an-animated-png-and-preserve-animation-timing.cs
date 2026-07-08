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
                    resultApng.RemoveAllFrames();

                    foreach (var page in sourceApng.Pages)
                    {
                        ApngFrame sourceFrame = (ApngFrame)page;

                        sourceFrame.Filter(sourceFrame.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5));

                        resultApng.AddFrame(sourceFrame);

                        ApngFrame addedFrame = (ApngFrame)resultApng.Pages[resultApng.PageCount - 1];
                        addedFrame.FrameTime = sourceFrame.FrameTime;
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
 * 1. When a developer wants to add a 5×5 emboss filter to every frame of an animated PNG (APNG) while preserving the original frame delays, this code can be used.
 * 2. When you need to convert a multi‑frame PNG into a stylized animation with consistent color depth (TruecolorWithAlpha) and maintain the animation timing, the example shows how.
 * 3. When processing user‑uploaded APNG files to give them a raised‑edge visual effect without losing the animation sequence, this C# routine applies the ConvolutionFilter.Emboss5x5 to each frame.
 * 4. When integrating image processing into a .NET web service that must read an APNG, apply a convolution filter, and output a new APNG with the same frame rate, the code demonstrates the required steps.
 * 5. When creating a batch job that automatically enhances animated PNG icons with an emboss effect while keeping their original playback speed, this snippet provides the complete workflow.
 */