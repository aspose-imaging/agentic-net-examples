using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Sources;

namespace ImageMaskingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Example usage:
            // Input image path
            string inputPath = @"C:\Images\sample.jpg";
            // Output image path (foreground isolated with transparent background)
            string outputPath = @"C:\Images\sample_foreground.png";

            AutoMaskForeground(inputPath, outputPath);
        }

        /// <summary>
        /// Performs automatic masking to isolate the foreground of the given image.
        /// The result is saved with a transparent background while preserving original foreground pixels.
        /// </summary>
        /// <param name="sourceFile">Full path to the source image.</param>
        /// <param name="destFile">Full path where the masked image will be saved.</param>
        static void AutoMaskForeground(string sourceFile, string destFile)
        {
            // Load the source image as a RasterImage (required for masking operations)
            using (RasterImage sourceImage = (RasterImage)Image.Load(sourceFile))
            {
                // Prepare export options for the resulting image (PNG with alpha channel)
                PngOptions exportOptions = new PngOptions
                {
                    ColorType = FileFormats.Png.PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                };

                // Configure automatic masking arguments (default settings are sufficient for many cases)
                AutoMaskingArgs autoArgs = new AutoMaskingArgs
                {
                    // Optional: adjust number of objects, iterations, or precision here
                    // NumberOfObjects = 2,
                    // MaxIterationNumber = 50,
                    // Precision = 1
                };

                // Set up masking options:
                // - Use GraphCut segmentation (good for foreground/background separation)
                // - Decompose = false because we only need the mask, not separate segment images
                // - BackgroundReplacementColor = Transparent to make background invisible
                MaskingOptions maskingOptions = new MaskingOptions
                {
                    Method = Masking.Options.SegmentationMethod.GraphCut,
                    Decompose = false,
                    Args = autoArgs,
                    BackgroundReplacementColor = Color.Transparent,
                    ExportOptions = exportOptions
                };

                // Create the ImageMasking instance
                ImageMasking masking = new ImageMasking(sourceImage);

                // Perform the masking operation
                using (MaskingResult maskingResult = masking.Decompose(maskingOptions))
                {
                    // The foreground mask is typically the first non‑background layer (index 1)
                    using (RasterImage foregroundMask = maskingResult[1].GetMask())
                    {
                        // Ensure the mask size matches the original image size
                        if (foregroundMask.Width != sourceImage.Width || foregroundMask.Height != sourceImage.Height)
                        {
                            foregroundMask.Resize(sourceImage.Width, sourceImage.Height, ResizeType.NearestNeighbourResample);
                        }

                        // Apply the mask to the original image.
                        // This replaces background pixels with the specified BackgroundReplacementColor (transparent).
                        ImageMasking.ApplyMask(sourceImage, foregroundMask, maskingOptions);
                    }

                    // Save the resulting image (foreground with transparent background)
                    sourceImage.Save(destFile, exportOptions);
                }
            }
        }
    }
}