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
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "uniform_image.png";
            string outputPath = "mask_output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                var exportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(outputPath, false)
                };

                var maskingOptions = new AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = true,
                    FeatheringRadius = 1,
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = exportOptions,
                    BackgroundReplacementColor = Color.Transparent
                };

                var masking = new ImageMasking(image);
                using (MaskingResult maskingResult = masking.Decompose(maskingOptions))
                {
                    using (RasterImage mask = (RasterImage)maskingResult[1].GetMask())
                    {
                        int width = mask.Width;
                        int height = mask.Height;
                        var rect = new Rectangle(0, 0, width, height);
                        int[] pixels = new int[width * height];
                        mask.SaveArgb32Pixels(rect, pixels);

                        bool hasContent = false;
                        foreach (int pixel in pixels)
                        {
                            if (pixel != 0)
                            {
                                hasContent = true;
                                break;
                            }
                        }

                        if (!hasContent)
                        {
                            Console.Error.WriteLine("Mask is empty: low threshold produced no foreground.");
                        }
                        else
                        {
                            mask.Save(outputPath, exportOptions);
                            Console.WriteLine($"Mask saved to: {outputPath}");
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
 * 1. When a developer needs to ensure that the AutoMaskingGraphCutOptions with a very low threshold still generates a non‑empty alpha mask for a solid‑color PNG before applying background removal in a batch image‑processing pipeline.
 * 2. When testing a photo‑editing application that uses Aspose.Imaging’s GraphCut segmentation to create transparent cutouts, a developer validates that even a uniform‑color image does not result in an empty mask when the threshold is set near zero.
 * 3. When integrating automated product‑photo cleanup, a developer checks that low‑threshold masking does not mistakenly discard the entire image mask for a single‑color background, preserving the ability to replace it with a custom color.
 * 4. When building a quality‑assurance suite for image‑mask export to PNG with truecolor with alpha, a developer runs this code to confirm that the mask file contains pixel data despite the image being uniformly colored.
 * 5. When optimizing performance for large‑scale image segmentation, a developer uses this example to verify that reducing the threshold does not produce an empty mask on uniform images, ensuring consistent results across diverse input files.
 */