// HOW-TO: Remove Background From PNG and Apply 3x3 Median Filter In C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                var maskingOptions = new AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = true,
                    FeatheringRadius = (Math.Max(raster.Width, raster.Height) / 500) + 1,
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new StreamSource(new MemoryStream())
                    },
                    BackgroundReplacementColor = Color.Transparent
                };

                var masking = new ImageMasking(raster);
                using (MaskingResult result = masking.Decompose(maskingOptions))
                {
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
 * 1. When you need to automatically remove a solid or complex background from a PNG image and keep the foreground intact for further processing in a C# application.
 * 2. When you want to replace the original background with a transparent layer after segmentation using Aspose.Imaging’s GraphCut algorithm.
 * 3. When you have minor noise or edge artifacts left after background removal and require a 3×3 median filter to smooth the foreground without blurring details.
 * 4. When you are preparing PNG assets for web or UI design and must ensure they have clean edges and an alpha channel for seamless overlay.
 * 5. When you are building an automated image‑pre‑processing pipeline in .NET that loads, masks, filters, and saves PNG files with true‑color with alpha using Aspose.Imaging.
 */
