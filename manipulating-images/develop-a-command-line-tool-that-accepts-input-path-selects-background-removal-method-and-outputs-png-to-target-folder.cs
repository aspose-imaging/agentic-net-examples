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
            // Hardcoded input and output paths
            string inputPath = "input\\image.jpg";
            string outputPath = "output\\result.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure PNG export options
            var exportOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new StreamSource(new MemoryStream())
            };

            // Prepare masking arguments (no user-defined strokes)
            var maskingArgs = new AutoMaskingArgs();

            // Set up masking options
            var maskingOptions = new MaskingOptions
            {
                Method = SegmentationMethod.GraphCut,
                Decompose = false,
                Args = maskingArgs,
                BackgroundReplacementColor = Color.Transparent,
                ExportOptions = exportOptions
            };

            // Load the source image as a raster image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Perform background removal
                var masking = new ImageMasking(image);
                using (MaskingResult result = masking.Decompose(maskingOptions))
                {
                    // Retrieve the foreground image (masked object)
                    using (RasterImage foreground = (RasterImage)result[1].GetImage())
                    {
                        // Save the result as PNG
                        foreground.Save(outputPath, exportOptions);
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