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
            string inputPath = "input.jpg";
            string outputDir = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            int[] thresholds = new int[] { 10, 20, 30, 40, 50 };

            foreach (int threshold in thresholds)
            {
                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    // Export options for the masked result
                    PngOptions exportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new StreamSource(new MemoryStream())
                    };

                    // Auto masking arguments – using Precision as a stand‑in for threshold experimentation
                    AutoMaskingArgs argsMask = new AutoMaskingArgs
                    {
                        Precision = threshold
                    };

                    // Masking options configuration
                    MaskingOptions maskingOptions = new MaskingOptions
                    {
                        Method = SegmentationMethod.GraphCut,
                        Decompose = false,
                        Args = argsMask,
                        BackgroundReplacementColor = Color.Transparent,
                        ExportOptions = exportOptions
                    };

                    // Perform masking
                    using (MaskingResult maskingResult = new ImageMasking(image).Decompose(maskingOptions))
                    {
                        // Obtain the foreground mask (index 1)
                        using (RasterImage foregroundMask = maskingResult[1].GetMask())
                        {
                            string outputPath = Path.Combine(outputDir, $"mask_{threshold}.png");
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                            foregroundMask.Save(outputPath, exportOptions);
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
 * 1. When a developer needs to isolate a product photo with a multicolored backdrop to create a transparent PNG for e‑commerce listings, they can iterate over threshold values to find the mask that cleanly separates the item from the background.
 * 2. When preparing assets for a mobile game, a programmer may experiment with different Precision thresholds on a JPEG sprite sheet to generate the smallest possible PNG mask that preserves edge detail while removing the colorful background.
 * 3. When automating batch processing of marketing banners, a developer can use the code to test multiple thresholds on a single JPEG to determine the optimal mask size that balances file size and visual quality before exporting to PNG with alpha transparency.
 * 4. When integrating a photo‑editing feature into a web application, a developer might run the threshold loop to discover the best GraphCut segmentation setting that removes a multicolored studio backdrop without leaving halos around the subject.
 * 5. When creating AI training data that requires precise foreground extraction, a developer can apply the threshold experimentation to a JPEG image to generate a transparent PNG mask that accurately captures complex edges for machine‑learning models.
 */