using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the source image
        using (Image loadedImage = Image.Load(inputPath))
        {
            // Ensure the image is a raster image for masking operations
            if (loadedImage is RasterImage rasterImage)
            {
                // Prepare export options for the final image (preserve quality and alpha)
                var exportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                };

                // Prepare masking arguments (default auto-masking)
                var autoMaskArgs = new AutoMaskingArgs();

                // Configure masking options: use GraphCut, transparent background, no decomposition
                var maskingOptions = new MaskingOptions
                {
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    Args = autoMaskArgs,
                    BackgroundReplacementColor = Aspose.Imaging.Color.Transparent,
                    ExportOptions = exportOptions
                };

                // Create ImageMasking instance
                var imageMasking = new ImageMasking(rasterImage);

                // Perform masking to obtain the foreground mask
                using (var maskingResult = imageMasking.Decompose(maskingOptions))
                {
                    // The second object (index 1) typically represents the foreground mask
                    using (RasterImage foregroundMask = maskingResult[1].GetMask())
                    {
                        // Resize mask to original image dimensions (if needed)
                        foregroundMask.Resize(rasterImage.Width, rasterImage.Height, ResizeType.NearestNeighbourResample);

                        // Reload original image to apply the mask (preserves original metadata)
                        using (RasterImage original = (RasterImage)Image.Load(inputPath))
                        {
                            // Apply the mask, making background transparent
                            ImageMasking.ApplyMask(original, foregroundMask, maskingOptions);

                            // Ensure output directory exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Save the processed image
                            original.Save(outputPath, exportOptions);
                        }
                    }
                }
            }
            else if (loadedImage is VectorImage vectorImage)
            {
                // For vector images, use the built‑in RemoveBackground method
                vectorImage.RemoveBackground();

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the vector image (preserving metadata)
                vectorImage.Save(outputPath);
            }
            else
            {
                // Unsupported image type; simply copy the original to the output location
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                File.Copy(inputPath, outputPath, overwrite: true);
            }
        }
    }
}