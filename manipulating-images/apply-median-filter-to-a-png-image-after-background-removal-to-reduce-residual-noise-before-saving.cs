// HOW-TO: Remove Background From PNG and Apply Median Filter In C# (Aspose.Imaging for .NET)
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
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
            string tempMaskPath = Path.Combine(Path.GetTempPath(), "mask_temp.png");
            Directory.CreateDirectory(Path.GetDirectoryName(tempMaskPath) ?? ".");

            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
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

                var masking = new Aspose.Imaging.Masking.ImageMasking(sourceImage);
                using (Aspose.Imaging.Masking.Result.MaskingResult result = masking.Decompose(maskingOptions))
                using (RasterImage foreground = (RasterImage)result[1].GetImage())
                {
                    foreground.Filter(foreground.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));

                    var saveOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new FileCreateSource(outputPath, false)
                    };
                    foreground.Save(outputPath, saveOptions);
                }
            }

            if (File.Exists(tempMaskPath))
                File.Delete(tempMaskPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to isolate a product photo by removing its background and then smooth out remaining speckles before storing it as a PNG file in a C# application.
 * 2. When preparing scanned documents for OCR, you can strip the page background and apply a median filter to reduce salt‑and‑pepper noise using Aspose.Imaging in .NET.
 * 3. When generating transparent icons from screenshots, you can automatically mask the unwanted area and clean up edge artifacts with a median filter in C#.
 * 4. When processing medical imaging slices that contain a uniform background, you can remove the background and denoise the foreground to improve visual clarity before saving as PNG.
 * 5. When building a web service that receives user‑uploaded PNGs, you can programmatically remove the background and apply a median filter to ensure consistent image quality across all uploads.
 */
