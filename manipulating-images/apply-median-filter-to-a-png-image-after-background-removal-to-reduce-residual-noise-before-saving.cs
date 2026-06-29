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

            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                var maskingOptions = new AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = true,
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    BackgroundReplacementColor = Color.Transparent,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new StreamSource(new MemoryStream())
                    }
                };

                var masking = new ImageMasking(sourceImage);
                using (MaskingResult result = masking.Decompose(maskingOptions))
                using (RasterImage foreground = (RasterImage)result[1].GetImage())
                {
                    foreground.Filter(foreground.Bounds, new MedianFilterOptions(5));

                    var saveOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new FileCreateSource(outputPath, false)
                    };
                    foreground.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to extract a clean foreground from a scanned product photo, remove the background, and smooth out speckle noise before saving as a transparent PNG for e‑commerce catalogs.
 * 2. When building an automated document digitization pipeline that isolates handwritten signatures, replaces the page background with transparency, and applies a median filter to eliminate scanning artifacts before storing the result as a PNG file.
 * 3. When creating a web‑based avatar editor that lets users upload PNG images, automatically cuts out the person, removes the original background, and uses a median filter to smooth edge noise before exporting the final image.
 * 4. When processing medical imaging scans in a C# application, separating tissue regions from the background, applying a median filter to reduce residual grain, and saving the cleaned foreground as a PNG with alpha channel for further analysis.
 * 5. When developing a batch image‑processing tool that prepares PNG assets for game development by removing green‑screen backgrounds, applying a median filter to reduce color noise, and exporting the result with truecolor with alpha for seamless integration.
 */