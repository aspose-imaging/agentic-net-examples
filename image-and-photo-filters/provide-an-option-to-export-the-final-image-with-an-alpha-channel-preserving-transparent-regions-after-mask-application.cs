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
            string inputPath = @"C:\temp\input.jpg";
            string outputPath = @"C:\temp\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                // Prepare export options to preserve alpha channel
                PngOptions exportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                };

                // Configure masking options: use GraphCut, no decomposition, transparent background
                MaskingOptions maskingOptions = new MaskingOptions
                {
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    Args = new AutoMaskingArgs(),
                    BackgroundReplacementColor = Color.Transparent,
                    ExportOptions = exportOptions
                };

                // Create ImageMasking instance
                ImageMasking masking = new ImageMasking(sourceImage);

                // Perform segmentation to obtain mask
                using (MaskingResult maskingResult = masking.Decompose(maskingOptions))
                {
                    // Get the foreground mask (index 1 is typically the first object)
                    using (RasterImage mask = maskingResult[1].GetMask())
                    {
                        // Resize mask to original image size if needed
                        mask.Resize(sourceImage.Width, sourceImage.Height, ResizeType.NearestNeighbourResample);

                        // Apply the mask to the original image
                        ImageMasking.ApplyMask(sourceImage, mask, maskingOptions);

                        // Save the resulting image with alpha channel preserved
                        sourceImage.Save(outputPath, exportOptions);
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
 * 1. When a developer uses Aspose.Imaging for .NET to remove the background from a JPEG photo and export the result as a PNG with an alpha channel so the transparent regions can be placed on any web page.
 * 2. When an e‑commerce site needs to generate product thumbnails by applying Aspose.Imaging masking to isolate items and save them as PNG files with preserved transparency for dynamic background colors in a mobile app.
 * 3. When a game developer extracts character sprites from source artwork using Aspose.Imaging’s GraphCut segmentation and exports them as PNGs with an alpha channel for seamless integration into Unity.
 * 4. When a marketing automation workflow automatically masks company logos from various image formats with Aspose.Imaging and outputs PNGs that retain transparent backgrounds for responsive email banners.
 * 5. When a document management system converts scanned documents into PNGs, applying Aspose.Imaging masking to isolate signatures and preserving the alpha channel so the signatures can be overlaid on PDFs without a white box.
 */