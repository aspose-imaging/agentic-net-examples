using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputDir = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            int[] thresholds = new int[] { 10, 20, 30, 40, 50 };

            foreach (int threshold in thresholds)
            {
                using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
                {
                    string tempMaskPath = Path.Combine(outputDir, $"mask_{threshold}.png");
                    var exportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new FileCreateSource(tempMaskPath, false)
                    };

                    var maskingOptions = new MaskingOptions
                    {
                        Method = SegmentationMethod.GraphCut,
                        Decompose = false,
                        Args = new AutoMaskingArgs(),
                        BackgroundReplacementColor = Color.Transparent,
                        ExportOptions = exportOptions
                    };

                    using (MaskingResult maskingResult = new ImageMasking(sourceImage).Decompose(maskingOptions))
                    using (RasterImage foregroundMask = (RasterImage)maskingResult[1].GetMask())
                    {
                        foregroundMask.Resize(sourceImage.Width, sourceImage.Height, ResizeType.NearestNeighbourResample);
                        ImageMasking.ApplyMask(sourceImage, foregroundMask, maskingOptions);

                        string outputPath = Path.Combine(outputDir, $"result_threshold_{threshold}.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                        var finalSaveOptions = new PngOptions
                        {
                            ColorType = PngColorType.TruecolorWithAlpha,
                            Source = new FileCreateSource(outputPath, false)
                        };
                        sourceImage.Save(outputPath, finalSaveOptions);
                    }

                    if (File.Exists(tempMaskPath))
                    {
                        File.Delete(tempMaskPath);
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