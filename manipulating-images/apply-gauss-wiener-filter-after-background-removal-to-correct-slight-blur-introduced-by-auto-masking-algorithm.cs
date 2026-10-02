// HOW-TO: Apply Gauss Wiener Filter After Auto Masking Background Removal in C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                var maskingOptions = new AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = true,
                    FeatheringRadius = (Math.Max(image.Width, image.Height) / 500) + 1,
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new StreamSource(new MemoryStream())
                    },
                    BackgroundReplacementColor = Color.Transparent
                };

                var masking = new ImageMasking(image);
                using (MaskingResult results = masking.Decompose(maskingOptions))
                using (RasterImage foreground = (RasterImage)results[1].GetImage())
                {
                    foreground.Filter(foreground.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussWienerFilterOptions());

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    foreground.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
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
 * 1. When you need to extract a subject from a JPEG photo, make the background transparent, and save the result as a PNG with an alpha channel.
 * 2. When an automatic graph‑cut masking algorithm leaves slight blur on the foreground and you want to sharpen it using a Gauss‑Wiener filter.
 * 3. When you are processing batch images in a C# application and require both background removal and post‑processing de‑blurring before storing them in a lossless format.
 * 4. When you need to replace the original background with transparency for later compositing while preserving image quality in .NET.
 * 5. When you want to combine Aspose.Imaging’s auto‑masking and advanced filtering features to prepare product photos for e‑commerce catalogs.
 */
