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
        string inputPath = "Input\\image.jpg";
        string outputPath = "Output\\mask.bin";

        try
        {
            // Input file existence check
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load source image as RasterImage
            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                // Prepare masking arguments (default auto masking)
                var autoArgs = new AutoMaskingArgs();

                // Export options required by masking (use in-memory stream)
                var exportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                };

                // Configure masking options
                var maskingOptions = new MaskingOptions
                {
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    Args = autoArgs,
                    BackgroundReplacementColor = Color.Transparent,
                    ExportOptions = exportOptions
                };

                // Perform masking
                var masking = new ImageMasking(sourceImage);
                using (MaskingResult maskingResult = masking.Decompose(maskingOptions))
                {
                    // Obtain the foreground mask (binary representation)
                    using (RasterImage mask = maskingResult[1].GetMask())
                    {
                        // Save mask as PNG (binary file extension is acceptable)
                        mask.Save(outputPath, new PngOptions
                        {
                            ColorType = PngColorType.Grayscale
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