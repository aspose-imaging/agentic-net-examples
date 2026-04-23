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

            // Prepare export options that preserve alpha channel
            var exportOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new StreamSource(new MemoryStream())
            };

            // Configure masking options: transparent background, GraphCut method
            var maskingOptions = new MaskingOptions
            {
                Method = SegmentationMethod.GraphCut,
                Decompose = false,
                Args = new AutoMaskingArgs(),
                BackgroundReplacementColor = Color.Transparent,
                ExportOptions = exportOptions
            };

            // Load the source image
            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                // Optional: reduce size for faster segmentation
                var originalSize = sourceImage.Size;
                sourceImage.ResizeHeightProportionally(600, ResizeType.HighQualityResample);

                // Perform segmentation to obtain mask
                var imageMasking = new ImageMasking(sourceImage);
                using (MaskingResult maskingResult = imageMasking.Decompose(maskingOptions))
                {
                    // Get the foreground mask (index 1 is typically the first object)
                    using (RasterImage mask = maskingResult[1].GetMask())
                    {
                        // Resize mask back to original dimensions
                        mask.Resize(originalSize.Width, originalSize.Height, ResizeType.NearestNeighbourResample);

                        // Apply mask to the original (full‑size) image
                        using (RasterImage fullSizeImage = (RasterImage)Image.Load(inputPath))
                        {
                            ImageMasking.ApplyMask(fullSizeImage, mask, maskingOptions);
                            // Save the result preserving transparency
                            fullSizeImage.Save(outputPath, exportOptions);
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