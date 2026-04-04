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
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Export options that preserve alpha channel
        var exportOptions = new PngOptions
        {
            ColorType = PngColorType.TruecolorWithAlpha,
            Source = new StreamSource(new MemoryStream())
        };

        // Masking options – GraphCut segmentation with transparent background
        var maskingOptions = new MaskingOptions
        {
            Method = SegmentationMethod.GraphCut,
            Decompose = false,
            Args = new AutoMaskingArgs(),
            BackgroundReplacementColor = Color.Transparent,
            ExportOptions = exportOptions
        };

        // Load source image as RasterImage
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Perform masking
            var masking = new ImageMasking(sourceImage);
            using (MaskingResult maskingResult = masking.Decompose(maskingOptions))
            {
                // Get the foreground (masked) image
                using (RasterImage foreground = (RasterImage)maskingResult[1].GetImage())
                {
                    // Save the result preserving transparency
                    foreground.Save(outputPath, exportOptions);
                }
            }
        }
    }
}