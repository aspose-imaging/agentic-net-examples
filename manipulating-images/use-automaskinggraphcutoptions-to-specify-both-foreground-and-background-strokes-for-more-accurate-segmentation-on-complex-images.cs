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
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the source image as a raster image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Temporary file for export options (required by the API)
                string tempExportPath = Path.GetTempFileName();

                // First pass – calculate default background/foreground strokes
                var options = new AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = true,
                    FeatheringRadius = (Math.Max(image.Width, image.Height) / 500) + 1,
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new FileCreateSource(tempExportPath, false)
                    },
                    BackgroundReplacementColor = Aspose.Imaging.Color.Transparent
                };

                // Perform masking to obtain default strokes
                var initialResult = new ImageMasking(image).Decompose(options);

                // Retrieve the automatically calculated strokes
                Aspose.Imaging.Point[] backgroundStrokes = options.DefaultBackgroundStrokes;
                Aspose.Imaging.Point[] foregroundStrokes = options.DefaultForegroundStrokes;

                // Second pass – use both background and foreground strokes explicitly
                options.CalculateDefaultStrokes = false;
                options.Args = new AutoMaskingArgs
                {
                    ObjectsPoints = new Aspose.Imaging.Point[][]
                    {
                        backgroundStrokes,   // background points
                        foregroundStrokes    // foreground points
                    }
                };

                var finalResult = new ImageMasking(image).Decompose(options);

                // Save the foreground segment (index 1) to the desired output file
                using (RasterImage resultImage = (RasterImage)finalResult[1].GetImage())
                {
                    resultImage.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }

                // Clean up the temporary export file
                if (File.Exists(tempExportPath))
                {
                    File.Delete(tempExportPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}