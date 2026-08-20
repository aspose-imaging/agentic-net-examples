// HOW-TO: Auto Mask and Median Filter a JPEG to PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
                // Prepare export options for masking (required Source)
                var maskingExportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                };

                // Configure auto‑masking options (GraphCut with default strokes)
                var autoMaskingOptions = new Aspose.Imaging.Masking.Options.AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = true,
                    FeatheringRadius = (Math.Max(sourceImage.Width, sourceImage.Height) / 500) + 1,
                    Method = Aspose.Imaging.Masking.Options.SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = maskingExportOptions,
                    BackgroundReplacementColor = Color.Transparent
                };

                // Perform auto‑masking
                var masking = new Aspose.Imaging.Masking.ImageMasking(sourceImage);
                using (Aspose.Imaging.Masking.Result.MaskingResult maskingResult = masking.Decompose(autoMaskingOptions))
                {
                    // Get the foreground mask (index 1)
                    using (RasterImage foregroundMask = maskingResult[1].GetMask())
                    {
                        // Apply the mask to a fresh copy of the original image
                        using (RasterImage maskedImage = (RasterImage)Image.Load(inputPath))
                        {
                            Aspose.Imaging.Masking.ImageMasking.ApplyMask(maskedImage, foregroundMask, autoMaskingOptions);

                            // Apply median filter (kernel size 5) to the masked image
                            maskedImage.Filter(maskedImage.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(5));

                            // Save the processed image
                            var saveOptions = new PngOptions { ColorType = PngColorType.TruecolorWithAlpha };
                            maskedImage.Save(outputPath, saveOptions);
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
 * 1. When you need to remove the background from a photo and save it as a transparent PNG in a C# web service.
 * 2. When you want to preprocess scanned documents by applying a median filter to reduce noise before further analysis.
 * 3. When you are building a batch image conversion tool that automatically masks objects and preserves image quality.
 * 4. When you need to integrate Aspose.Imaging auto‑masking into a desktop application to isolate subjects for graphic design.
 * 5. When you require a reusable method that loads any raster image, applies background removal and smoothing, and returns a processed bitmap for further manipulation.
 */
