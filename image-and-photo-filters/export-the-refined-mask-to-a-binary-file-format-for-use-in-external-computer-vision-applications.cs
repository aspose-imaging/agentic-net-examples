using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\temp\source.jpg";
        string outputPath = @"C:\temp\mask.bin";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source raster image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Prepare masking options (automatic segmentation)
                var maskingOptions = new MaskingOptions
                {
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    Args = new AutoMaskingArgs(),
                    BackgroundReplacementColor = Color.Transparent,
                    // Use BMP options – the result will be a binary bitmap suitable for CV pipelines
                    ExportOptions = new BmpOptions()
                };

                // Create the ImageMasking instance
                var masking = new ImageMasking(image);

                // Perform masking and obtain the foreground mask (layer 1)
                using (MaskingResult maskingResult = masking.Decompose(maskingOptions))
                {
                    // The mask is stored as a raster image
                    using (RasterImage mask = maskingResult[1].GetMask())
                    {
                        // Save the mask to a binary file (BMP format written to .bin)
                        mask.Save(outputPath, (BmpOptions)maskingOptions.ExportOptions);
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