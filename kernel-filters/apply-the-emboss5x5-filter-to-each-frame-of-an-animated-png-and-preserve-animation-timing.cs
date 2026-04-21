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
        string outputPath = "output/output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (ApngImage sourceApng = (ApngImage)Image.Load(inputPath))
            {
                int width = sourceApng.Width;
                int height = sourceApng.Height;

                ApngOptions createOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                using (ApngImage resultApng = (ApngImage)Image.Create(createOptions, width, height))
                {
                    resultApng.RemoveAllFrames();

                    for (int i = 0; i < sourceApng.PageCount; i++)
                    {
                        ApngFrame srcFrame = (ApngFrame)sourceApng.Pages[i];
                        uint frameTime = (uint)srcFrame.FrameTime;

                        srcFrame.Filter(
                            srcFrame.Bounds,
                            new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                                Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss5x5));

                        resultApng.AddFrame(srcFrame, frameTime);
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