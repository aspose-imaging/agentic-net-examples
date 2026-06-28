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
        try
        {
            string inputPath1 = "input1.png";
            string outputPath1 = "output1.png";
            string inputPath2 = "input2.png";
            string outputPath2 = "output2.png";

            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath1));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath2));

            string tempFile1 = Path.Combine(Path.GetTempPath(), "mask_temp1.png");
            string tempFile2 = Path.Combine(Path.GetTempPath(), "mask_temp2.png");

            AutoMaskingGraphCutOptions options;
            using (RasterImage image1 = (RasterImage)Image.Load(inputPath1))
            {
                options = new AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = true,
                    FeatheringRadius = (Math.Max(image1.Width, image1.Height) / 500) + 1,
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new FileCreateSource(tempFile1, false)
                    },
                    BackgroundReplacementColor = Color.Transparent
                };

                using (MaskingResult results1 = new ImageMasking(image1).Decompose(options))
                {
                    using (RasterImage resultImage1 = (RasterImage)results1[1].GetImage())
                    {
                        resultImage1.Save(outputPath1, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                    }
                }
            }

            if (File.Exists(tempFile1))
                File.Delete(tempFile1);

            options.CalculateDefaultStrokes = false;
            options.ExportOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new FileCreateSource(tempFile2, false)
            };

            using (RasterImage image2 = (RasterImage)Image.Load(inputPath2))
            {
                using (MaskingResult results2 = new ImageMasking(image2).Decompose(options))
                {
                    using (RasterImage resultImage2 = (RasterImage)results2[1].GetImage())
                    {
                        resultImage2.Save(outputPath2, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                    }
                }
            }

            if (File.Exists(tempFile2))
                File.Delete(tempFile2);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When an e‑commerce platform needs to automatically remove and replace the background of product photos in multiple PNG files, a developer can reuse the configured AutoMaskingGraphCutOptions to apply consistent GraphCut segmentation and feathering across all images.
 * 2. When a marketing team processes a batch of promotional PNG assets and wants to maintain the same transparent background settings without recalculating strokes for each file, the pre‑configured AutoMaskingGraphCutOptions can be applied to the second image for fast, repeatable masking.
 * 3. When a photo‑editing web service offers users the ability to upload a PNG and receive a cut‑out with a transparent background, the service can store the AutoMaskingGraphCutOptions from the first upload and reuse them to speed up background removal on subsequent uploads.
 * 4. When a digital publishing workflow needs to generate PNG thumbnails with clean edges for a series of illustrations, developers can reuse the same AutoMaskingGraphCutOptions to ensure uniform feathering radius and GraphCut method across all thumbnails.
 * 5. When a mobile app syncs PNG stickers from a server and must strip their backgrounds while preserving alpha transparency, the app can apply the previously set AutoMaskingGraphCutOptions to each new sticker image for consistent background removal.
 */