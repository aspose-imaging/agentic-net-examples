// HOW-TO: Generate Binary Mask PNG From Image Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputMaskPath = "mask.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputMaskPath));

        try
        {
            // Load source image as RasterImage
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Export options required by masking API (stream source to avoid temp files)
                PngOptions exportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                };

                // Configure masking options (GraphCut auto masking)
                MaskingOptions maskingOptions = new MaskingOptions
                {
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    Args = new AutoMaskingArgs(),
                    BackgroundReplacementColor = Color.Transparent,
                    ExportOptions = exportOptions
                };

                // Perform masking
                ImageMasking masking = new ImageMasking(image);
                using (MaskingResult maskingResult = masking.Decompose(maskingOptions))
                {
                    // Retrieve the foreground mask (binary mask)
                    using (RasterImage mask = maskingResult[1].GetMask())
                    {
                        // Save mask as PNG (binary format) for external CV applications
                        mask.Save(outputMaskPath, new PngOptions
                        {
                            ColorType = PngColorType.TruecolorWithAlpha,
                            Source = new FileCreateSource(outputMaskPath, false)
                        });
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
 * 1. When a developer needs to create a binary PNG mask of an object for feeding into a machine‑learning model that expects foreground/background segmentation.
 * 2. When integrating Aspose.Imaging into a C# application to automatically separate foreground from background using GraphCut for image editing tools.
 * 3. When exporting a refined mask to a lossless PNG with alpha channel for use in external computer‑vision pipelines that require precise pixel‑level masks.
 * 4. When building an automated preprocessing step that generates masks for large batches of photos before running object detection or OCR.
 * 5. When a developer wants to replace the background of an image with transparency and save the resulting mask for further compositing in video or graphics software.
 */
