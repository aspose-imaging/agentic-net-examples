using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
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
            string inputImagePath = "C:\\temp\\input.jpg";
            string outputImagePath = "C:\\temp\\output.png";

            // Verify input file exists
            if (!File.Exists(inputImagePath))
            {
                Console.Error.WriteLine($"File not found: {inputImagePath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputImagePath));

            // Load the source image
            using (RasterImage image = (RasterImage)Image.Load(inputImagePath))
            {
                // Configure export options to preserve alpha channel
                PngOptions exportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                };

                // Set up masking options
                MaskingOptions maskingOptions = new MaskingOptions
                {
                    Method = SegmentationMethod.GraphCut, // any segmentation method
                    Decompose = false,
                    Args = new AutoMaskingArgs(), // default arguments
                    BackgroundReplacementColor = Color.Transparent,
                    ExportOptions = exportOptions
                };

                // Create masking instance
                ImageMasking masking = new ImageMasking(image);

                // Perform masking (no decomposition, just obtain mask)
                using (MaskingResult maskingResult = masking.Decompose(maskingOptions))
                {
                    // Get the foreground mask (object number 1)
                    using (RasterImage foregroundMask = maskingResult[1].GetMask())
                    {
                        // Resize mask to match original image size if needed
                        foregroundMask.Resize(image.Width, image.Height, ResizeType.NearestNeighbourResample);

                        // Apply the mask to the original image
                        ImageMasking.ApplyMask(image, foregroundMask, maskingOptions);

                        // Save the final image with alpha channel preserved
                        image.Save(outputImagePath, exportOptions);
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