using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            using (var exportStream = new MemoryStream())
            {
                var maskingExportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(exportStream)
                };

                var maskingOptions = new MaskingOptions
                {
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    Args = new AutoMaskingArgs(),
                    BackgroundReplacementColor = Color.Transparent,
                    ExportOptions = maskingExportOptions
                };

                var masking = new ImageMasking(sourceImage);
                using (MaskingResult maskingResult = masking.Decompose(maskingOptions))
                using (RasterImage foreground = (RasterImage)maskingResult[1].GetImage())
                {
                    foreground.Filter(foreground.Bounds, new MedianFilterOptions(3));

                    var saveOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new FileCreateSource(outputPath, false)
                    };
                    foreground.Save(outputPath, saveOptions);
                }
            }
        }
    }
}