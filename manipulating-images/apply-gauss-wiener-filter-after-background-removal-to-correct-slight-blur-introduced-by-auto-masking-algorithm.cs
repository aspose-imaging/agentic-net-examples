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
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image as RasterImage
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Prepare export options for masking (in‑memory stream)
            var maskingExportOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new StreamSource(new MemoryStream())
            };

            // Configure auto‑masking (GraphCut) to remove background
            var maskingOptions = new AutoMaskingGraphCutOptions
            {
                CalculateDefaultStrokes = true,
                FeatheringRadius = (Math.Max(sourceImage.Width, sourceImage.Height) / 500) + 1,
                Method = SegmentationMethod.GraphCut,
                Decompose = false,
                ExportOptions = maskingExportOptions,
                BackgroundReplacementColor = Color.Transparent
            };

            // Perform masking
            using (MaskingResult maskingResult = new ImageMasking(sourceImage).Decompose(maskingOptions))
            {
                // Obtain the foreground (masked object) image
                using (RasterImage foreground = (RasterImage)maskingResult[1].GetImage())
                {
                    // Apply Gauss‑Wiener filter to reduce blur introduced by masking
                    foreground.Filter(
                        foreground.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.GaussWienerFilterOptions());

                    // Save the filtered foreground image
                    var saveOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha
                    };
                    foreground.Save(outputPath, saveOptions);
                }
            }
        }
    }
}