using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hard‑coded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists before any save operation
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Temporary file used by masking export options
        string tempMaskPath = "tempMask.png";

        // Load the source image as a raster image
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Configure auto‑masking (GraphCut) options
            var maskingOptions = new Aspose.Imaging.Masking.Options.AutoMaskingGraphCutOptions
            {
                CalculateDefaultStrokes = true,
                FeatheringRadius = (Math.Max(sourceImage.Width, sourceImage.Height) / 500) + 1,
                Method = Aspose.Imaging.Masking.Options.SegmentationMethod.GraphCut,
                Decompose = false,
                ExportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(tempMaskPath, false)
                },
                BackgroundReplacementColor = Color.Transparent
            };

            // Perform masking to obtain the foreground segment
            using (Aspose.Imaging.Masking.Result.MaskingResult maskResult =
                new Aspose.Imaging.Masking.ImageMasking(sourceImage).Decompose(maskingOptions))
            {
                using (RasterImage foreground = (RasterImage)maskResult[1].GetImage())
                {
                    // Apply Gauss‑Wiener deblurring
                    foreground.Filter(foreground.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.GaussWienerFilterOptions(5, 4.0));

                    // Apply bilateral smoothing
                    foreground.Filter(foreground.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.BilateralSmoothingFilterOptions(5));

                    // Save the enhanced foreground image as PNG
                    foreground.Save(outputPath, new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new StreamSource(new MemoryStream())
                    });
                }
            }
        }

        // Clean up temporary mask file
        if (File.Exists(tempMaskPath))
        {
            File.Delete(tempMaskPath);
        }
    }
}