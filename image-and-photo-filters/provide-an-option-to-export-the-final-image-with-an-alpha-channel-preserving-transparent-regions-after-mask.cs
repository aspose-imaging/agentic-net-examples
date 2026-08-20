// HOW-TO: Export JPEG As PNG With Transparent Background Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputImagePath = @"C:\temp\BigImage.jpg";
            string outputImagePath = @"C:\temp\BigImage_foreground.png";

            // Verify input file exists
            if (!File.Exists(inputImagePath))
            {
                Console.Error.WriteLine($"File not found: {inputImagePath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputImagePath));

            // Prepare export options with alpha channel support
            var exportOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new StreamSource(new MemoryStream())
            };

            // Configure masking options
            var maskingOptions = new MaskingOptions
            {
                Method = SegmentationMethod.GraphCut, // any method; GraphCut used in examples
                Decompose = false,                    // we will apply mask manually
                Args = new AutoMaskingArgs(),
                BackgroundReplacementColor = Color.Transparent,
                ExportOptions = exportOptions
            };

            // Load the source image
            using (RasterImage sourceImage = (RasterImage)Image.Load(inputImagePath))
            {
                // Reduce size for faster segmentation (optional)
                sourceImage.ResizeHeightProportionally(600, ResizeType.HighQualityResample);

                // Create ImageMasking instance
                var masking = new ImageMasking(sourceImage);

                // Perform segmentation to obtain a mask
                using (MaskingResult maskingResult = masking.Decompose(maskingOptions))
                {
                    // Assume the first foreground object is at index 1
                    using (RasterImage foregroundMask = maskingResult[1].GetMask())
                    {
                        // Resize mask back to original dimensions
                        foregroundMask.Resize(sourceImage.Width, sourceImage.Height, ResizeType.NearestNeighbourResample);

                        // Apply the mask to the original (full‑size) image
                        using (RasterImage originalFullSize = (RasterImage)Image.Load(inputImagePath))
                        {
                            ImageMasking.ApplyMask(originalFullSize, foregroundMask, maskingOptions);
                            // Save the result preserving transparency
                            originalFullSize.Save(outputImagePath, exportOptions);
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
 * 1. When you need to remove the background of a large JPEG photo and save the result as a PNG that retains transparent areas for web or UI overlays.
 * 2. When you want to generate cut‑out images for e‑commerce product listings, preserving alpha channels so the product can be placed on any background.
 * 3. When you are building a graphics pipeline that requires converting scanned images to PNG with mask‑based transparency for further compositing in design tools.
 * 4. When you need to automate batch processing of images to create foreground PNGs with transparent backgrounds for game assets or AR applications.
 * 5. When you must integrate Aspose.Imaging masking to produce PNGs with true‑color and alpha for printing workflows that demand precise color and transparency handling.
 */
