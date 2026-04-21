using System;
using System.IO;
using Aspose.Imaging;
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
            // Hard‑coded input JPEG path
            string inputPath = @"C:\temp\input.jpg";

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Directory where all results will be stored
            string outputBaseDir = @"C:\temp\output";
            Directory.CreateDirectory(outputBaseDir); // ensure the base output folder exists

            // Load the source image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Common export options for all results (PNG with alpha)
                PngOptions exportOptions = new PngOptions
                {
                    ColorType = Aspose.Imaging.FileFormats.Png.PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                };

                // Different threshold (precision) values to test
                int[] thresholds = new int[] { 1, 2, 3, 4, 5 };

                foreach (int thresh in thresholds)
                {
                    // Configure arguments for the segmentation algorithm
                    AutoMaskingArgs args = new AutoMaskingArgs
                    {
                        // Using Precision as a stand‑in for “threshold”
                        Precision = thresh,
                        // Optional: keep default number of objects (foreground/background)
                        NumberOfObjects = 2
                    };

                    // Set up masking options
                    MaskingOptions maskingOptions = new MaskingOptions
                    {
                        Method = SegmentationMethod.KMeans, // K‑means clustering
                        Decompose = true,                  // produce separate segments
                        Args = args,
                        BackgroundReplacementColor = Color.Transparent,
                        ExportOptions = exportOptions
                    };

                    // Create the masking processor
                    ImageMasking masking = new ImageMasking(image);

                    // Perform decomposition
                    using (MaskingResult maskingResult = masking.Decompose(maskingOptions))
                    {
                        for (int i = 0; i < maskingResult.Length; i++)
                        {
                            // Build a unique output file name that includes the threshold value
                            string outputPath = Path.Combine(
                                outputBaseDir,
                                $"segment_thresh{thresh}_{maskingResult[i].ObjectNumber}.png");

                            // Ensure the directory for this file exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Retrieve the segment image and save it
                            using (Image resultImage = maskingResult[i].GetImage())
                            {
                                resultImage.Save(outputPath);
                            }
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