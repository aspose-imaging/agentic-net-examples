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
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source PNG as a raster image
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Configure user-defined strokes for auto masking
            var userStrokes = new AutoMaskingArgs
            {
                // Example strokes: first array = background points, second = foreground points
                ObjectsPoints = new Point[][]
                {
                    new Point[] { new Point(30, 30), new Point(40, 30) }, // background strokes
                    new Point[] { new Point(120, 120), new Point(130, 130) } // foreground strokes
                }
            };

            // Export options for the masking result (transparent PNG)
            var exportOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new StreamSource(new MemoryStream())
            };

            // Set up auto-masking options with GraphCut method
            var maskingOptions = new AutoMaskingGraphCutOptions
            {
                CalculateDefaultStrokes = false, // using user strokes
                FeatheringRadius = 3,
                Method = SegmentationMethod.GraphCut,
                Decompose = false,
                ExportOptions = exportOptions,
                BackgroundReplacementColor = Color.Transparent,
                Args = userStrokes
            };

            // Perform masking
            using (MaskingResult maskingResult = new ImageMasking(sourceImage).Decompose(maskingOptions))
            {
                // Retrieve the foreground (masked object) image
                using (RasterImage foreground = (RasterImage)maskingResult[1].GetImage())
                {
                    // Align DPI: make horizontal and vertical resolutions equal
                    double maxResolution = Math.Max(foreground.HorizontalResolution, foreground.VerticalResolution);
                    foreground.HorizontalResolution = maxResolution;
                    foreground.VerticalResolution = maxResolution;

                    // Save the aligned foreground as PNG
                    var saveOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha
                    };
                    foreground.Save(outputPath, saveOptions);
                }
            }
        }
    }
}