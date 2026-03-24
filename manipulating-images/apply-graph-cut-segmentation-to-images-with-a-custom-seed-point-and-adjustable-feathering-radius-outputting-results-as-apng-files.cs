using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hard‑coded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Temporary file for masking export options
        string tempExportPath = Path.GetTempFileName();

        // Load source image as RasterImage
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Configure GraphCut masking with a custom seed point and feathering radius
            var maskingOptions = new Aspose.Imaging.Masking.Options.GraphCutMaskingOptions
            {
                FeatheringRadius = 3, // adjustable
                Method = Aspose.Imaging.Masking.Options.SegmentationMethod.GraphCut,
                Decompose = false,
                ExportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(tempExportPath, false)
                },
                BackgroundReplacementColor = Color.Transparent,
                Args = new Aspose.Imaging.Masking.Options.AutoMaskingArgs
                {
                    ObjectsPoints = new Point[][]
                    {
                        new Point[]
                        {
                            // Custom seed point
                            new Point(100, 100)
                        }
                    }
                }
            };

            // Perform masking
            using (Aspose.Imaging.Masking.Result.MaskingResult maskingResult =
                new Aspose.Imaging.Masking.ImageMasking(sourceImage).Decompose(maskingOptions))
            {
                // Retrieve the foreground (masked) image
                using (RasterImage foreground = (RasterImage)maskingResult[1].GetImage())
                {
                    // Save as APNG
                    var apngOptions = new ApngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        DefaultFrameTime = 200, // milliseconds per frame
                        NumPlays = 0 // infinite loop
                    };
                    foreground.Save(outputPath, apngOptions);
                }
            }
        }

        // Clean up temporary export file
        if (File.Exists(tempExportPath))
        {
            File.Delete(tempExportPath);
        }
    }
}