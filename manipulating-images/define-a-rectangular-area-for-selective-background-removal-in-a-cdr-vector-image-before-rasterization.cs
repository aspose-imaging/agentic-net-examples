using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Images\input.cdr";
            string outputPath = @"C:\Images\output.png";
            string tempPath = Path.Combine(Path.GetTempPath(), "temp_raster.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tempPath));

            using (var vectorImage = Image.Load(inputPath) as VectorImage)
            {
                if (vectorImage == null)
                {
                    Console.Error.WriteLine("Failed to load vector image.");
                    return;
                }

                vectorImage.RemoveBackground(new RemoveBackgroundSettings());

                var rasterOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(tempPath, false)
                };
                vectorImage.Save(tempPath, rasterOptions);
            }

            using (RasterImage raster = (RasterImage)Image.Load(tempPath))
            {
                var maskingOptions = new AutoMaskingGraphCutOptions
                {
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    BackgroundReplacementColor = Color.Transparent,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new StreamSource(new MemoryStream())
                    }
                };

                var masking = new ImageMasking(raster);
                using (MaskingResult result = masking.Decompose(maskingOptions))
                using (RasterImage foreground = (RasterImage)result[1].GetImage())
                {
                    var finalOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha
                    };
                    foreground.Save(outputPath, finalOptions);
                }
            }

            if (File.Exists(tempPath))
                File.Delete(tempPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}