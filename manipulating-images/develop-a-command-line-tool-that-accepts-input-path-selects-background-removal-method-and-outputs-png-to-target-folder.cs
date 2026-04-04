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
        string outputPath = "output.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

        // Load the source image as a RasterImage
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Configure export options for PNG with transparency
            var exportOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new StreamSource(new MemoryStream())
            };

            // Set up masking options (GraphCut auto masking, transparent background)
            var maskingOptions = new MaskingOptions
            {
                Method = SegmentationMethod.GraphCut,
                Decompose = false,
                Args = new AutoMaskingArgs(),
                BackgroundReplacementColor = Color.Transparent,
                ExportOptions = exportOptions
            };

            // Perform masking
            using (MaskingResult maskingResult = new ImageMasking(image).Decompose(maskingOptions))
            {
                // Retrieve the foreground image (index 1)
                using (RasterImage foreground = (RasterImage)maskingResult[1].GetImage())
                {
                    // Save the result as PNG
                    foreground.Save(outputPath, exportOptions);
                }
            }
        }
    }
}