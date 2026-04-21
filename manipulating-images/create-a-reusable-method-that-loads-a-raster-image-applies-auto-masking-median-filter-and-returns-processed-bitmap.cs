using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.RasterImage originalImage = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.Size originalSize = originalImage.Size;

                PngOptions exportOptions = new PngOptions
                {
                    ColorType = Aspose.Imaging.FileFormats.Png.PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                };

                var maskingOptions = new Aspose.Imaging.Masking.Options.AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = true,
                    FeatheringRadius = (Math.Max(originalImage.Width, originalImage.Height) / 500) + 1,
                    Method = Aspose.Imaging.Masking.Options.SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = exportOptions,
                    BackgroundReplacementColor = Aspose.Imaging.Color.Transparent
                };

                using (Aspose.Imaging.Masking.Result.MaskingResult maskingResult =
                    new Aspose.Imaging.Masking.ImageMasking(originalImage).Decompose(maskingOptions))
                {
                    using (Aspose.Imaging.RasterImage foreground = (Aspose.Imaging.RasterImage)maskingResult[1].GetImage())
                    {
                        foreground.Resize(originalSize.Width, originalSize.Height, Aspose.Imaging.ResizeType.NearestNeighbourResample);

                        using (Aspose.Imaging.RasterImage maskedImage = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
                        {
                            Aspose.Imaging.Masking.ImageMasking.ApplyMask(maskedImage, foreground, maskingOptions);

                            maskedImage.Filter(maskedImage.Bounds,
                                new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(5));

                            maskedImage.Save(outputPath, exportOptions);
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