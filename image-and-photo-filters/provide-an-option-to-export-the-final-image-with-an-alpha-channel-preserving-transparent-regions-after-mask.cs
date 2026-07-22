using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"c:\temp\BigImage.jpg";
            string outputPath = @"c:\temp\BigImage_foreground.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Prepare export options with alpha channel support
            var exportOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new StreamSource(new MemoryStream())
            };

            // Configure masking options
            var maskingOptions = new MaskingOptions
            {
                Method = SegmentationMethod.GraphCut,
                Decompose = false,
                Args = new AutoMaskingArgs(),
                BackgroundReplacementColor = Color.Transparent,
                ExportOptions = exportOptions
            };

            // Load the source image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Keep original size for later resizing of mask
                var originalSize = image.Size;

                // Reduce size to speed up segmentation (optional)
                image.ResizeHeightProportionally(600, ResizeType.HighQualityResample);

                // Create masking instance
                var masking = new ImageMasking(image);

                // Perform segmentation
                using (MaskingResult maskingResult = masking.Decompose(maskingOptions))
                {
                    // Get the foreground mask (index 1 is typically the first object)
                    using (RasterImage foregroundMask = maskingResult[1].GetMask())
                    {
                        // Resize mask back to original image dimensions
                        foregroundMask.Resize(originalSize.Width, originalSize.Height, ResizeType.NearestNeighbourResample);

                        // Load the original image again for final output
                        using (RasterImage originalImage = (RasterImage)Image.Load(inputPath))
                        {
                            // Apply the mask to the original image
                            ImageMasking.ApplyMask(originalImage, foregroundMask, maskingOptions);

                            // Save the result preserving transparency
                            originalImage.Save(outputPath, exportOptions);
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
 * 1. When a developer needs to remove the background from a high‑resolution JPEG photo and save the foreground as a PNG with transparent areas for use in web design.
 * 2. When an e‑commerce platform wants to generate product cut‑outs automatically from product photos so the images can be layered over different background colors in a catalog.
 * 3. When a mobile app creates stickers by extracting objects from user‑uploaded images and requires a PNG with an alpha channel to preserve the shape of each sticker.
 * 4. When a game engine imports character sprites from photographs and needs the masked images with preserved transparency to blend seamlessly with the game scene.
 * 5. When a digital marketing tool batch‑processes social‑media graphics, applying graph‑cut segmentation to isolate logos and exporting them as PNGs with transparent backgrounds for overlay on promotional videos.
 */