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
        // Hardcoded input JPEG path
        string inputPath = @"C:\Images\input.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Output directory for mask results
        string outputDir = @"C:\Images\MaskResults";

        // Ensure output directory exists
        Directory.CreateDirectory(outputDir);

        // Threshold values to experiment with
        int[] thresholds = new int[] { 10, 20, 30, 40, 50 };

        // Load source image as RasterImage
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Iterate over each threshold value
            foreach (int threshold in thresholds)
            {
                // Prepare export options (in‑memory stream source)
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
                    BackgroundReplacementColor = Color.Transparent,
                    ExportOptions = exportOptions,
                    // Using Precision as a placeholder for threshold experimentation
                    Args = new AutoMaskingArgs { Precision = threshold }
                };

                // Perform masking
                using (MaskingResult maskingResult = new ImageMasking(sourceImage).Decompose(maskingOptions))
                {
                    // Obtain foreground mask image (index 1)
                    using (RasterImage foregroundMask = (RasterImage)maskingResult[1].GetMask())
                    {
                        // Build output file path
                        string outputPath = Path.Combine(outputDir, $"mask_threshold_{threshold}.png");

                        // Ensure directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the mask
                        foregroundMask.Save(outputPath, exportOptions);
                    }
                }
            }
        }
    }
}