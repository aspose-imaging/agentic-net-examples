using System;
using System.IO;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input raster image path
        string inputPath = "input.jpg";
        // Output path for the foreground with transparent background
        string outputPath = "output.png";

        // Export options for the resulting PNG (transparent background)
        var exportOptions = new PngOptions
        {
            ColorType = PngColorType.TruecolorWithAlpha,
            Source = new StreamSource(new MemoryStream())
        };

        // Masking options: GraphCut algorithm, transparent background
        var maskingOptions = new MaskingOptions
        {
            Method = SegmentationMethod.GraphCut,
            Decompose = false,
            Args = new AutoMaskingArgs(),
            BackgroundReplacementColor = Aspose.Imaging.Color.Transparent,
            ExportOptions = exportOptions
        };

        // Load the source image as a RasterImage
        using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
        {
            // Create ImageMasking instance
            var masking = new ImageMasking(image);

            // Perform masking
            using (MaskingResult result = masking.Decompose(maskingOptions))
            {
                // Get the foreground image (object) from the result
                using (Aspose.Imaging.RasterImage foreground = (Aspose.Imaging.RasterImage)result[1].GetImage())
                {
                    // Save the foreground with transparent background
                    foreground.Save(outputPath, exportOptions);
                }
            }
        }
    }
}