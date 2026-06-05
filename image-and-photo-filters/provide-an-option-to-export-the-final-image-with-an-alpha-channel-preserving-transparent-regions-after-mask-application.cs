using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\BigImage.jpg";
        string outputPath = @"c:\temp\BigImage_foreground.png";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Preserve original size for later use
                Aspose.Imaging.Size originalSize = image.Size;

                // Optional: reduce size to speed up segmentation
                image.ResizeHeightProportionally(600, ResizeType.HighQualityResample);

                // Prepare export options with alpha channel support
                PngOptions exportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                };

                // Configure masking options
                MaskingOptions maskingOptions = new MaskingOptions
                {
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    Args = new AutoMaskingArgs(),
                    BackgroundReplacementColor = Color.Transparent,
                    ExportOptions = exportOptions
                };

                // Create masking instance and decompose
                ImageMasking masking = new ImageMasking(image);
                using (MaskingResult maskingResult = masking.Decompose(maskingOptions))
                {
                    // Obtain the foreground mask (index 1 is typically the first object)
                    using (RasterImage foregroundMask = maskingResult[1].GetMask())
                    {
                        // Resize mask back to original image dimensions
                        foregroundMask.Resize(originalSize.Width, originalSize.Height, ResizeType.NearestNeighbourResample);

                        // Load the original image again for final composition
                        using (RasterImage originalImage = (RasterImage)Image.Load(inputPath))
                        {
                            // Apply the mask preserving transparency
                            ImageMasking.ApplyMask(originalImage, foregroundMask, maskingOptions);

                            // Save the result with alpha channel
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