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
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load image and keep original size
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                Size originalSize = image.Size;

                // Resize for faster masking
                image.ResizeHeightProportionally(600, ResizeType.HighQualityResample);

                // Masking export options (in‑memory)
                var exportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                };

                // Auto‑masking options (GraphCut)
                var maskingOptions = new AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = true,
                    FeatheringRadius = (Math.Max(image.Width, image.Height) / 500) + 1,
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = exportOptions,
                    BackgroundReplacementColor = Color.Transparent
                };

                // Perform masking
                var masking = new ImageMasking(image);
                using (MaskingResult maskingResult = masking.Decompose(maskingOptions))
                {
                    // Get foreground mask and resize to original dimensions
                    using (RasterImage foregroundMask = maskingResult[1].GetMask())
                    {
                        foregroundMask.Resize(originalSize.Width, originalSize.Height, ResizeType.NearestNeighbourResample);

                        // Apply mask to the original full‑size image
                        using (RasterImage original = (RasterImage)Image.Load(inputPath))
                        {
                            ImageMasking.ApplyMask(original, foregroundMask, maskingOptions);

                            // Apply median filter (kernel size 5)
                            original.Filter(original.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(5));

                            // Save processed image
                            var saveOptions = new PngOptions
                            {
                                ColorType = PngColorType.TruecolorWithAlpha
                            };
                            original.Save(outputPath, saveOptions);
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
 * 1. When an e‑commerce site must automatically remove product backgrounds from JPEG photos, apply a median filter to smooth edges, and export the result as a transparent PNG for catalog listings.
 * 2. When a mobile app needs to isolate a user’s portrait from an uploaded selfie, reduce image noise with a median filter, and save the processed bitmap as a high‑quality PNG with an alpha channel.
 * 3. When a document‑management system scans paper receipts, uses auto‑masking to separate text from the paper background, applies a median filter to clean speckles, and returns a clean bitmap for OCR processing.
 * 4. When a game developer prepares sprite assets by auto‑masking character images, removing background noise with a median filter, and exporting them as truecolor‑with‑alpha PNGs for use in the game engine.
 * 5. When a social‑media analytics tool batch‑processes thousands of profile pictures to extract foreground objects, apply median filtering for noise reduction, and generate transparent PNG thumbnails for visual reports.
 */