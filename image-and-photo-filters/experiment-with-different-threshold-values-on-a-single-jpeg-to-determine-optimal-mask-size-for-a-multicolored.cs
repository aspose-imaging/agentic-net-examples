using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
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

            double[] thresholds = { 0.1, 0.2, 0.3, 0.4, 0.5 };

            foreach (double threshold in thresholds)
            {
                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    // Apply Bradley binarization with the current threshold
                    image.BinarizeBradley(threshold);

                    // Prepare output path for the mask
                    string outputPath = Path.Combine(outputDir, $"mask_{threshold:F2}.png");

                    // Ensure the output directory exists (already created above)
                    // Save the binarized image as PNG with alpha channel
                    PngOptions exportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new FileCreateSource(outputPath, false)
                    };

                    image.Save(outputPath, exportOptions);
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
 * 1. When a developer needs to generate binary PNG masks from a JPEG with a multicolored background by applying multiple Bradley binarization thresholds to determine the optimal mask size.
 * 2. When an image‑processing workflow requires saving a series of threshold‑based PNG masks with an alpha channel to evaluate visual quality before performing OCR on the original JPEG.
 * 3. When a C# application must automate batch creation of PNG masks for a single input JPEG, iterating over different threshold values to support later compositing or background removal.
 * 4. When a developer is fine‑tuning Aspose.Imaging’s BinarizeBradley method to achieve consistent edge detection across varying lighting conditions in a JPEG image.
 * 5. When a software solution needs to compare the effect of different threshold settings on mask density to select the best parameter for downstream computer‑vision tasks such as object segmentation.
 */