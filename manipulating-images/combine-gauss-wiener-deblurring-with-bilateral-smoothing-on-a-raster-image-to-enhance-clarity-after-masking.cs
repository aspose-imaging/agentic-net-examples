// HOW-TO: Apply Gauss Wiener Deblurring and Bilateral Smoothing After Masking in C# (Aspose.Imaging for .NET)
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

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Export options for masking (transparent PNG in memory)
                var exportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                };

                // Configure auto graph‑cut masking
                var maskingOptions = new AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = true,
                    FeatheringRadius = (Math.Max(image.Width, image.Height) / 500) + 1,
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = exportOptions,
                    BackgroundReplacementColor = Color.Transparent
                };

                // Perform masking to obtain foreground mask
                using (MaskingResult maskingResult = new ImageMasking(image).Decompose(maskingOptions))
                {
                    using (RasterImage foregroundMask = (RasterImage)maskingResult[1].GetMask())
                    {
                        // Apply mask to original image to isolate foreground
                        using (RasterImage foreground = (RasterImage)Image.Load(inputPath))
                        {
                            ImageMasking.ApplyMask(foreground, foregroundMask, maskingOptions);

                            // Gauss‑Wiener deblurring
                            foreground.Filter(foreground.Bounds,
                                new Aspose.Imaging.ImageFilters.FilterOptions.GaussWienerFilterOptions(5, 4.0));

                            // Bilateral smoothing
                            foreground.Filter(foreground.Bounds,
                                new Aspose.Imaging.ImageFilters.FilterOptions.BilateralSmoothingFilterOptions(5));

                            // Save enhanced image
                            foreground.Save(outputPath, exportOptions);
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

/*
 * Real-World Use Cases:
 * 1. When you need to extract the foreground of a noisy JPEG photo, save it as a transparent PNG, and improve its sharpness with Gauss‑Wiener deblurring and bilateral smoothing.
 * 2. When you want to automatically segment an image using graph‑cut masking in C# and then enhance the isolated subject’s details for product photography.
 * 3. When you are building a .NET application that removes blur from scanned documents after separating text from the background with Aspose.Imaging.
 * 4. When you require a workflow to clean up blurry wildlife pictures by masking the animal and applying edge‑preserving smoothing to retain natural textures.
 * 5. When you need to prepare images for machine‑learning datasets by isolating objects, de‑blurring them, and exporting the result as a PNG with an alpha channel.
 */
